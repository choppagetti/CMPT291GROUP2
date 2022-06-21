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

namespace CarRental
{
    //----------This screen lets the user choose their pickup and return branches + dates and car type;   ----------
    //----------it also error-checks their input and doesn't allow them to go through with their selection----------
    //----------if their search filters don't return anything from the database                           ----------
    public partial class CustomerAvail : Form
    {
        public Database D2;
        public Start start;
        public CustomerAvail(Start start)
        {
            InitializeComponent();
            D2 = new Database();
            this.start = start;

            // Fills in the Car Type combo box and list with car type values from the database
            D2.query("select [Type] from CarType");
            while (D2.myReader.Read())
            { CarType.Items.Add(D2.myReader["Type"].ToString().Trim());}
            D2.myReader.Close();

            // Fills in the Pick-up and Return Location combo boxes and list with Branch name values from the database
            D2.query("select [Name] from Branch");
            while (D2.myReader.Read())
            {
             PickUpLoc.Items.Add(D2.myReader["Name"].ToString().Trim());
             RetLoc.Items.Add(D2.myReader["Name"].ToString().Trim());
            }
            D2.myReader.Close();

            // Initially sets the "Return Location" section to False (invisible) until user ticks the checkbox
            retLocReq.Visible = false;
            return_loc.Visible = false;
            RetLoc.Visible = false;

            RetLoc.Text = PickUpLoc.Text;
        }

        //------Event for when the Home button is clicked------
        private void Home_Click(object sender, EventArgs e)
        {
            // Closes the form and returns to the inital form (Start)
            this.DialogResult = DialogResult.OK;
        }

        private void CheckAvail_Click(object sender, EventArgs e)
        {
            // Ensures user fills in the required fields
            // If the checkBox isn't checked, then we don't need a value for the Return Location
            if (!checkBox.Checked)
            {
                if (IdBox.Text.Trim() == "" || PickUpLoc.Text.Trim() == "" || CarType.Text.Trim() == "")
                {
                    MessageBox.Show("Missing one or more required field(s).", "Error");
                    return;
                }
            }
            // Else, we will need a value for the Return Location
            else
            {
                if (IdBox.Text.Trim() == "" || PickUpLoc.Text.Trim() == "" || RetLoc.Text.Trim() == "" || CarType.Text.Trim() == "")
                {
                    MessageBox.Show("Missing one or more required field(s).", "Error");
                    return;
                }
            }

            List<string> CarTypes = new List<string>();
            List<string> Branches = new List<string>();

            // Fills in the Car Types list with car type values from the database
            D2.query("select [Type] from CarType");
            while (D2.myReader.Read())
            {CarTypes.Add(D2.myReader["Type"].ToString().Trim());}
            D2.myReader.Close();

            // Ensures the user enters a valid car type into the combo box
            if (!CarTypes.Contains(CarType.Text.Trim()))
            {
                MessageBox.Show("Please choose a valid Car Type.", "Error");
                return;
            }

            // Fills in the Branches list with Branch name values from the database
            D2.query("select [Name] from Branch");
            while (D2.myReader.Read())
            {Branches.Add(D2.myReader["Name"].ToString().Trim());}
            D2.myReader.Close();

            // Ensures the user enters a valid pick-up location into the combo box
            if (!Branches.Contains(PickUpLoc.Text.Trim()))
            {
                MessageBox.Show("Please choose a valid Pick-Up Location.", "Error");
                return;
            }

            // Ensures the user enters a valid return location into the combo box
            if ((checkBox.Checked == true) && (!Branches.Contains(RetLoc.Text.Trim())))
            {
                MessageBox.Show("Please choose a valid Return Location.", "Error");
                return;
            }

            // Takes all of the customer IDs from the database and adds them to a list
            List<string> CustID = new List<string>();
            D2.query("select CID from Customer");
            while (D2.myReader.Read())
            {CustID.Add(D2.myReader["CID"].ToString().Trim());}
            D2.myReader.Close();

            // If the customer ID entered is not in the database, error message is thrown
            if (!CustID.Contains(IdBox.Text.Trim()))
            {   MessageBox.Show("Customer ID could not be found in the system. Please enter a valid Customer ID.", "Error");
                return;
            }

            // Ensures user chooses a valid return date compared to the pickup date
            int diff = (returnDate.Value.CompareTo(pickupDate.Value));
            if (diff < 0)
            {
                MessageBox.Show("Please enter a valid return date (at least 1 day after the pick-up date).", "Error");
                return;
            }

            // Gets the customer's membership type (true for gold, false for not gold)
            D2.query("select MembType" +
                     " from Customer" +
                     " where Customer.[CID] = " + "'" + IdBox.Text + "'");
            D2.myReader.Read();
            bool CustMemb = (bool)D2.myReader["MembType"];
            //MessageBox.Show("Membership type: " + CustMemb.ToString());
            D2.myReader.Close();
            
            // If the customer is not a gold member
            if (CustMemb == false)
            {
                if (CheckCar(D2, CarType.Text.Trim(), PickUpLoc.Text.Trim()) == false) // If there are no car records for their search filters
                {
                    MessageBox.Show("No available cars for your search. Please try another search option.", "No Cars Available");
                    return;
                }
                else // If there are car records matching their search filters
                {
                    D2.myReader.Close();
                    if (CheckDate(D2, pickupDate.Value, returnDate.Value, CarType.Text.Trim(), PickUpLoc.Text.Trim()) == false)
                    {
                        MessageBox.Show("No cars available for selected dates. Please try another search option.", "No Cars Available");
                        return;
                    }
                    D2.myReader.Close();
                }
            }
            // If customer is a gold member
            else
            {
                // If there are no car records for their search filters
                if (CheckCar(D2, CarType.Text.Trim(), PickUpLoc.Text.Trim()) == false)
                {
                    MessageBox.Show("No available cars for your search. You are eligible for a free upgrade for other car types.", "No Cars Available");
                    D2.myReader.Close();

                    // This function will check for other cars of other car types for upgrading, but not if they have chosen the highest car type which is Luxury
                    if ((CheckDate_Gold(D2, pickupDate.Value, returnDate.Value, CarType.Text.Trim(), PickUpLoc.Text.Trim()) == false) || CarType.Text.Trim() == "Luxury")
                    {
                        MessageBox.Show("No available cars for upgrading. Please try another search option.", "No Cars Available");
                        return;
                    }
                    D2.myReader.Close();
                }
                // If there are car records matching their search filters
                else
                {
                    D2.myReader.Close();
                    if (CheckDate(D2, pickupDate.Value, returnDate.Value, CarType.Text.Trim(), PickUpLoc.Text.Trim()) == false)
                    {
                        MessageBox.Show("No cars available for selected dates. Please try another search option.", "No Cars Available");
                        return;
                    }
                    D2.myReader.Close();
                }
            }

            // Creates a new form to display the available cars when this button is pressed
            CustomerBook customerBook = new(this, this.start);
            this.Hide();
            customerBook.ShowDialog();
            this.start.Hide();
    }

        //------Function that checks if a car is present in the selected branch and car type------
        private bool CheckCar (Database D2, String CT, String Loc)
        {
            bool avail = true;
            // This query searches for a car ID present in the selected branch and car type tables
            D2.query("select Car.[CAR_ID]" +
                     " from Car, CarType, Branch" +
                     " where Car.[CT_ID] = CarType.[CT_ID] and Car.[BID] = Branch.[BID] and Branch.[Name] = " + "'" + Loc + "'" +
                     " and CarType.[Type] = " + "'" + CT + "'");
            //MessageBox.Show("CheckCar command: " + D2.myCommand.CommandText);
            if (D2.myReader.Read() == false) // If the reader doesn't return any results
            {avail = false;}
            D2.myReader.Close();
            return avail;
        }

        //------Function that checks if the selected car type has availability for the selected dates------
        private bool CheckDate (Database D2, DateTime PickupD, DateTime ReturnD, String CT, String Loc)
        {
            bool avail_date = true;

            D2.query("select Car.[Car_ID]" +
                     " from Car, CarType, Branch, RentalTrans" +
                     " where Car.[CT_ID] = CarType.[CT_ID] and Car.[BID] = Branch.[BID] and Car.[CAR_ID] = RentalTrans.[CAR_ID]" +
                     " and CarType.[CT_ID] = RentalTrans.[CT_ID] and RentalTrans.[PickUpBID] = Branch.[BID] and CarType.[Type] = " + "'" + CT + "'");
            // Means it's not linked to a transaction therefore free
            if (D2.myReader.Read() == false)
            {
                avail_date = true;
                D2.myReader.Close();
            }
            // If it's linked to a transaction, check if the dates conflict
            else
            {
                D2.myReader.Close();

                // Query: (cars - cars with transactions whose dates overlap with the specified dates)
                D2.query("select C.CAR_ID, C.Make, C.Model" +
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

                if (D2.myReader.Read() == true)
                {
                    D2.myReader.Close();
                    avail_date = true;
                }
                else
                {avail_date = false;}
                D2.myReader.Close();
            }
            return avail_date;
        }

        //------Function that checks if the higher car types for gold members are available for the selected dates------
        private bool CheckDate_Gold (Database D2, DateTime PickupD, DateTime ReturnD, String CT, String Loc)
        {
            bool avail_date = true;

            // If Luxury is chosen, this will immediately return false as Luxury is the highest car type available
            if (CT == "Luxury")
            { return avail_date = false; }

            // Will check for car types higher than Sedan
            if (CT == "Sedan")
            {
                D2.query("select C.[Car_ID]" +
                     " from Car C, CarType CT, Branch B, RentalTrans RT" +
                     " where C.[CT_ID] = CT.[CT_ID] and C.[BID] = B.[BID] and C.[CAR_ID] = RT.[CAR_ID]" +
                     " and CT.[CT_ID] = RT.[CT_ID] and RT.[PickUpBID] = B.[BID] and (CT.[Type] = 'SUV' or CT.[Type] = 'Minivan' or CT.[Type] = 'Luxury')");
            }
            // Will check for car types higher than SUV
            else if (CT == "SUV")
            {
                D2.query("select C.[Car_ID]" +
                     " from Car C, CarType CT, Branch B, RentalTrans RT" +
                     " where C.[CT_ID] = CT.[CT_ID] and C.[BID] = B.[BID] and C.[CAR_ID] = RT.[CAR_ID]" +
                     " and CT.[CT_ID] = RT.[CT_ID] and RT.[PickUpBID] = B.[BID] and (CT.[Type] = 'Minivan' or CT.[Type] = 'Luxury')");
            }
            // Will check for car types higher than Minivan
            else if (CT == "Minivan")
            {
                D2.query("select C.[Car_ID]" +
                     " from Car C, CarType CT, Branch B, RentalTrans RT" +
                     " where C.[CT_ID] = CT.[CT_ID] and C.[BID] = B.[BID] and C.[CAR_ID] = RT.[CAR_ID]" +
                     " and CT.[CT_ID] = RT.[CT_ID] and RT.[PickUpBID] = B.[BID] and CT.[Type] = 'Luxury'");
            }

            if (D2.myReader.Read() == false) // Means it's not linked to a transaction therefore free
            {
                avail_date = true;
                D2.myReader.Close();
            }
            else // If it's linked to a transaction, check if the dates conflict
            {
                D2.myReader.Close();

                // If Luxury is chosen, this will immediately return false as Luxury is the highest car type available
                if (CT == "Luxury")
                {return avail_date = false;}

                // Query: (cars - cars with transactions whose dates overlap with the specified dates)
                // Will check for car types higher than Sedan
                else if (CT == "Sedan")
                {
                    D2.query("select C.CAR_ID, C.Make, C.Model" +
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
                    D2.query("select C.CAR_ID, C.Make, C.Model" +
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
                    D2.query("select C.CAR_ID, C.Make, C.Model" +
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
                // If results are returned
                if (D2.myReader.Read() == true)
                {
                    D2.myReader.Close();
                    avail_date = true;
                }
                else
                {avail_date = false;}
                D2.myReader.Close();
            }
            return avail_date;
        }

        //------Event for when the checkbox is interacted with------
        private void checkBox_CheckedChanged_1(object sender, EventArgs e)
        {
            // If the checkbox is ticked, this will display the labels and combo box for the Return Location
            if (checkBox.Checked)
            {
                retLocReq.Visible = true;
                return_loc.Visible = true;
                RetLoc.Visible = true;

                // The Return Location defaults to the same location selected in the Pick-Up Location combo box
                RetLoc.Text = PickUpLoc.Text;
            }

            // If the checkbox is unticked, this will hide the labels and combo box for the Return Location
            // The Return Location will default back to the same location as the Pick-Up Location
            else
            {
                RetLoc.Text = PickUpLoc.Text;
                retLocReq.Visible = false;
                return_loc.Visible = false;
                RetLoc.Visible = false;
            }
        }

    }
}
