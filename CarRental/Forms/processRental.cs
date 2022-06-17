using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CarRental.Forms
{
    public partial class processRental : Form

    {
        public Database daps;

        public processRental()
        {
            InitializeComponent();
            daps = new Database();

            //getting branches from database for drop down
            daps.query("select [Name] from Branch");
            while (daps.myReader.Read())
            {
                pickupBranch.Items.Add(daps.myReader["Name"].ToString());
                returnBranch.Items.Add(daps.myReader["Name"].ToString());
            }
            daps.myReader.Close();

            //gettng types of cars from database
            daps.query("select [Type] from CarType");
            while (daps.myReader.Read())
            {
                carTypes.Items.Add(daps.myReader["Type"].ToString());
            }
            daps.myReader.Close();

        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void processRental_Load(object sender, EventArgs e)
        {

        }

        private void availability_Click(object sender, EventArgs e)
        {
            bool member = false;
            textFieldCheck();
            dateValidity(returnDate.Value, pickupDate.Value);
            if (validCustomer(custID.Text) == true)
            {
                member = memberStatusCheck(custID.Text);
                if ((checkCarAvail(daps, carTypes.Text.Trim(), pickupBranch.Text.Trim()) == false))
                {
                    MessageBox.Show("No Cars Available. Please change branch location and or car type");
                }
                else if ((checkDate(daps, pickupDate.Value, returnDate.Value, carTypes.Text.Trim(), pickupBranch.Text.Trim()) == false))
                {
                    MessageBox.Show("No Cars Available. Please change pickup date and or return date");
                }
                else if ((checkDate_Gold(daps, pickupDate.Value, returnDate.Value, carTypes.Text.Trim(), pickupBranch.Text.Trim())) == true && member == true)
                {
                    MessageBox.Show("Customer is a Gold DAPS Member and qualifies for an upgrade. Select UPGRADE to continue.");
                }
                else
                {
                    MessageBox.Show("damn");
                }
            }           
        }
        //checks if text fields are filled
        private bool textFieldCheck()
        {
            if (custID.Text.Trim() == "" || pickupBranch.Text.Trim() == "" || returnBranch.Text.Trim() == "" || carTypes.Text.Trim() == "")
            {
                MessageBox.Show("Missing one or more required field(s).", "Error");
                return false;
            }
            else
            {
                return true;
            }
        }
        // Checks the validity of the dates in the boxes
        private bool dateValidity(DateTime returnD, DateTime pickD)
        {
            if( returnD.CompareTo(pickD) < 0)
            {
                MessageBox.Show("Please enter a valid return date (at least 1 day after the pick-up date).", "Error");
                return false;
            }
            else
            {
                return true;
            }

        }
        // approves the valid customer ids
        private bool validCustomer(string cid)
        {
            List<string> customerIDs = new List<string>();
            daps.query("select CID from Customer");
            while (daps.myReader.Read())
            { customerIDs.Add(daps.myReader["CID"].ToString()); }
            daps.myReader.Close();
            
            if (customerIDs.Contains(cid))
            {
                return true;
            }
            else
            {
                MessageBox.Show("Customer ID could not be found in the system.", "Error");
                return false;
            }
        }
        private bool memberStatusCheck(string cid)
        {
            daps.query("select MembType" +
                     " from Customer" +
                     " where Customer.[CID] = " + "'" + cid + "'");
            daps.myReader.Read();
            bool memb = (bool)daps.myReader["MembType"];
            daps.myReader.Close();
            return memb;
        }
        private bool checkCarAvail(Database daps, String CT, String Loc)
        {
            bool avail = true;
            // This query searches for a car ID present in the selected branch and car type tables
            daps.query("select Car.[CAR_ID]" +
                     " from Car, CarType, Branch" +
                     " where Car.[CT_ID] = CarType.[CT_ID] and Car.[BID] = Branch.[BID] and Branch.[Name] = " + "'" + Loc + "'" +
                     " and CarType.[Type] = " + "'" + CT + "'");
            //MessageBox.Show("CheckCar command: " + D2.myCommand.CommandText);
            if (daps.myReader.Read() == false) // If the reader doesn't return any results
            { avail = false; }
            daps.myReader.Close();
            return avail;
        }
        private bool checkDate(Database daps, DateTime PickupD, DateTime ReturnD, String CT, String Loc)
        {
            bool avail_date = true;

            daps.query("select Car.[Car_ID]" +
                     " from Car, CarType, Branch, RentalTrans" +
                     " where Car.[CT_ID] = CarType.[CT_ID] and Car.[BID] = Branch.[BID] and Car.[CAR_ID] = RentalTrans.[CAR_ID]" +
                     " and CarType.[CT_ID] = RentalTrans.[CT_ID] and RentalTrans.[PickUpBID] = Branch.[BID] and CarType.[Type] = " + "'" + CT + "'");
            if (daps.myReader.Read() == false) // Means it's not linked to a transaction therefore free
            {
                //MessageBox.Show("If for CheckDate");
                avail_date = true;
                //MessageBox.Show("Not linked to a transaction");
                daps.myReader.Close();
            }
            else // If it's linked to a transaction, check if the dates conflict
            {
                daps.myReader.Close();
                //MessageBox.Show("Linked to a transaction");
                // Query: (cars - cars with transactions whose dates overlap with the specified dates)
                daps.query("select C.CAR_ID, C.Make, C.Model" +
                         " from Car C, CarType CT, Branch B " +
                         " where C.BID = B.BID and C.CT_ID = CT.CT_ID and B.[Name] = " + "'" + Loc + "'" + " and CT.[Type] = " + "'" + CT + "'" +
                         " except" +
                         " (select C.CAR_ID, C.Make, C.Model " +
                         " from Car C, CarType CT, Branch B, RentalTrans R" +
                         " where C.BID = B.BID and C.CT_ID = CT.CT_ID and R.CAR_ID = C.CAR_ID and R.CT_ID = CT.CT_ID and R.PickUpBID = B.BID" +
                         " and B.[Name] = " + "'" + Loc + "'" + " and CT.[Type] = " + "'" + CT + "'" +
                         " and ((convert(smalldatetime, " + "'" + PickupD + "') between R.PickupDate and R.ReturnDate)" +
                         " or (convert(smalldatetime, " + "'" + ReturnD + "') between R.PickupDate and R.ReturnDate)" +
                         " or (R.PickUpDate > convert(smalldatetime, " + "'" + PickupD + "') and R.ReturnDate < convert(smalldatetime, " + "'" + ReturnD + "'))))");

                if (daps.myReader.Read() == true)
                {
                    daps.myReader.Close();
                    avail_date = true;
                }
                else
                { avail_date = false; }
                daps.myReader.Close();
            }
            return avail_date;
        }
        //------Function that checks if the higher car types for gold members are available for the selected dates------
        private bool checkDate_Gold(Database daps, DateTime PickupD, DateTime ReturnD, string CT, string Loc)
        {
            bool avail_date = true;

            if (CT == "Luxury")
            { return avail_date = false; }

            // Will check for car types higher than Sedan
            if (CT == "Sedan")
            {
                daps.query("select C.[Car_ID]" +
                     " from Car C, CarType CT, Branch B, RentalTrans RT" +
                     " where C.[CT_ID] = CT.[CT_ID] and C.[BID] = B.[BID] and C.[CAR_ID] = RT.[CAR_ID]" +
                     " and CT.[CT_ID] = RT.[CT_ID] and RT.[PickUpBID] = B.[BID] and (CT.[Type] = 'SUV' or CT.[Type] = 'Minivan' or CT.[Type] = 'Luxury')");
            }
            // Will check for car types higher than SUV
            else if (CT == "SUV")
            {
                daps.query("select C.[Car_ID]" +
                     " from Car C, CarType CT, Branch B, RentalTrans RT" +
                     " where C.[CT_ID] = CT.[CT_ID] and C.[BID] = B.[BID] and C.[CAR_ID] = RT.[CAR_ID]" +
                     " and CT.[CT_ID] = RT.[CT_ID] and RT.[PickUpBID] = B.[BID] and (CT.[Type] = 'Minivan' or CT.[Type] = 'Luxury')");
            }
            // Will check for car types higher than Minivan
            else if (CT == "Minivan")
            {
                daps.query("select C.[Car_ID]" +
                     " from Car C, CarType CT, Branch B, RentalTrans RT" +
                     " where C.[CT_ID] = CT.[CT_ID] and C.[BID] = B.[BID] and C.[CAR_ID] = RT.[CAR_ID]" +
                     " and CT.[CT_ID] = RT.[CT_ID] and RT.[PickUpBID] = B.[BID] and CT.[Type] = 'Luxury'");
            }

            if (daps.myReader.Read() == false) // Means it's not linked to a transaction therefore free
            {
                avail_date = true;
                daps.myReader.Close();
            }
            else // If it's linked to a transaction, check if the dates conflict
            {
                daps.myReader.Close();

                // If they are looking for a Luxury car at this point, then the function will return false as it is the highest car type already
                if (CT == "Luxury")
                { return avail_date = false; }

                // Query: (cars - cars with transactions whose dates overlap with the specified dates)
                // Will check for car types higher than Sedan
                else if (CT == "Sedan")
                {
                    daps.query("select C.CAR_ID, C.Make, C.Model" +
                         " from Car C, CarType CT, Branch B " +
                         " where C.BID = B.BID and C.CT_ID = CT.CT_ID and B.[Name] = " + "'" + Loc + "'" + " and (CT.[Type] = 'SUV' or CT.[Type] = 'Minivan' or CT.[Type] = 'Luxury')" +
                         " except" +
                         " (select C.CAR_ID, C.Make, C.Model " +
                         " from Car C, CarType CT, Branch B, RentalTrans R" +
                         " where C.BID = B.BID and C.CT_ID = CT.CT_ID and R.CAR_ID = C.CAR_ID and R.CT_ID = CT.CT_ID and R.PickUpBID = B.BID" +
                         " and B.[Name] = " + "'" + Loc + "'" + " and (CT.[Type] = 'SUV' or CT.[Type] = 'Minivan' or CT.[Type] = 'Luxury')" +
                         " and ((convert(smalldatetime, " + "'" + PickupD + "') between R.PickupDate and R.ReturnDate)" +
                         " or (convert(smalldatetime, " + "'" + ReturnD + "') between R.PickupDate and R.ReturnDate)" +
                         " or (R.PickUpDate > convert(smalldatetime, " + "'" + PickupD + "') and R.ReturnDate < convert(smalldatetime, " + "'" + ReturnD + "'))))");
                }

                // Will check for car types higher than SUV
                else if (CT == "SUV")
                {
                    daps.query("select C.CAR_ID, C.Make, C.Model" +
                         " from Car C, CarType CT, Branch B " +
                         " where C.BID = B.BID and C.CT_ID = CT.CT_ID and B.[Name] = " + "'" + Loc + "'" + " and (CT.[Type] = 'Minivan' or CT.[Type] = 'Luxury')" +
                         " except" +
                         " (select C.CAR_ID, C.Make, C.Model " +
                         " from Car C, CarType CT, Branch B, RentalTrans R" +
                         " where C.BID = B.BID and C.CT_ID = CT.CT_ID and R.CAR_ID = C.CAR_ID and R.CT_ID = CT.CT_ID and R.PickUpBID = B.BID" +
                         " and B.[Name] = " + "'" + Loc + "'" + " and (CT.[Type] = 'Minivan' or CT.[Type] = 'Luxury')" +
                         " and ((convert(smalldatetime, " + "'" + PickupD + "') between R.PickupDate and R.ReturnDate)" +
                         " or (convert(smalldatetime, " + "'" + ReturnD + "') between R.PickupDate and R.ReturnDate)" +
                         " or (R.PickUpDate > convert(smalldatetime, " + "'" + PickupD + "') and R.ReturnDate < convert(smalldatetime, " + "'" + ReturnD + "'))))");
                }
                else if (CT == "Minivan")
                {
                    daps.query("select C.CAR_ID, C.Make, C.Model" +
                         " from Car C, CarType CT, Branch B " +
                         " where C.BID = B.BID and C.CT_ID = CT.CT_ID and B.[Name] = " + "'" + Loc + "'" + " and CT.[Type] = 'Luxury'" +
                         " except" +
                         " (select C.CAR_ID, C.Make, C.Model " +
                         " from Car C, CarType CT, Branch B, RentalTrans R" +
                         " where C.BID = B.BID and C.CT_ID = CT.CT_ID and R.CAR_ID = C.CAR_ID and R.CT_ID = CT.CT_ID and R.PickUpBID = B.BID" +
                         " and B.[Name] = " + "'" + Loc + "'" + " and CT.[Type] = 'Luxury'" +
                         " and ((convert(smalldatetime, " + "'" + PickupD + "') between R.PickupDate and R.ReturnDate)" +
                         " or (convert(smalldatetime, " + "'" + ReturnD + "') between R.PickupDate and R.ReturnDate)" +
                         " or (R.PickUpDate > convert(smalldatetime, " + "'" + PickupD + "') and R.ReturnDate < convert(smalldatetime, " + "'" + ReturnD + "'))))");
                }

                if (daps.myReader.Read() == true)
                {
                    daps.myReader.Close();
                    avail_date = true;
                }
                else
                { avail_date = false; }
                daps.myReader.Close();
            }
            return avail_date;
        }











    }
}
