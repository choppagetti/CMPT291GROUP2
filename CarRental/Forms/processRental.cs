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
                if ((checkCarAvail(daps, carTypes.Text.Trim(), pickupBranch.Text.Trim()) == false) && (checkDate(daps, pickupDate.Value, returnDate.Value, carTypes.Text.Trim(), pickupBranch.Text.Trim()) == false))
                {
                    if ((checkDate_Gold(daps, pickupDate.Value, returnDate.Value, carTypes.Text.Trim(), pickupBranch.Text.Trim())) == true && member == true)
                    {
                        MessageBox.Show("Customer is a Gold DAPS Member and qualifies for an upgrade. Select UPGRADE to continue.");
                    }
                    else
                    {
                        MessageBox.Show("No Cars Available. Please change branch location and or car type");
                    }
                }
                else if ((checkCarAvail(daps, carTypes.Text.Trim(), pickupBranch.Text.Trim()) == true) && (checkDate(daps, pickupDate.Value, returnDate.Value, carTypes.Text.Trim(), pickupBranch.Text.Trim()) == true))
                {
                    MessageBox.Show("Cars Available.");
                    decimal totalVal = getPriceRegular(daps, pickupDate.Value, returnDate.Value, carTypes.Text.Trim(), pickupBranch.Text.Trim(), returnBranch.Text.Trim());
                    availableList(daps, member, pickupDate.Value, returnDate.Value, carTypes.Text.Trim(), pickupBranch.Text.Trim(), totalVal);
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
            if (returnD.CompareTo(pickD) < 0)
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
        //finds all avaiable cars for specified options
        private bool availableList(Database daps, bool member, DateTime pickupDate, DateTime returnDate, String carType, String branchLoc, decimal price)
        {
            string statusMember;
            if (member == true)
            {
                statusMember = "Gold";
            }
            else
            {
                statusMember = "Regular";
            }
            // Takes the eligible car details from the database (cars that match the car type and pickup branch that aren't linked to a transaction for the selected dates)
            string query1 = "select C.[CAR_ID], CT.[Type],C.[Make], C.[Model], B.[Name]" +
                         " from Car C, CarType CT, Branch B " +
                         " where C.BID = B.BID and C.CT_ID = CT.CT_ID and B.[Name] = " + "'" + branchLoc + "'" + " and CT.[Type] = " + "'" + carType + "'" +
                         " except" +
                         " (select C.[CAR_ID], CT.[Type], C.[Make], C.[Model], B.[Name]  " +
                         " from Car C, CarType CT, Branch B, RentalTrans R" +
                         " where C.BID = B.BID and C.CT_ID = CT.CT_ID and R.CAR_ID = C.CAR_ID and R.CT_ID = CT.CT_ID and R.PickUpBID = B.BID" +
                         " and B.[Name] = " + "'" + branchLoc + "'" + " and CT.[Type] = " + "'" + carType + "'" +
                         " and ((convert(smalldatetime, " + "'" + pickupDate + "') between R.PickupDate and R.ReturnDate)" +
                         " or (convert(smalldatetime, " + "'" + returnDate + "') between R.PickupDate and R.ReturnDate)" +
                         " or (R.PickUpDate > convert(smalldatetime, " + "'" + pickupDate + "') and R.ReturnDate < convert(smalldatetime, " + "'" + returnDate + "'))))";
            daps.query(query1);
            inventory.Rows.Clear();

            // If the reader returns something, then that means that the customer's initial search (gold or non-gold) went through
            if (daps.myReader.Read() == true)
            {
                daps.myReader.Close();
                daps.query(query1);
                while (daps.myReader.Read())
                {
                    inventory.Rows.Add(statusMember, daps.myReader["CAR_ID"].ToString(), daps.myReader["Type"].ToString(), daps.myReader["Make"].ToString(), daps.myReader["Model"].ToString(),
                        daps.myReader["Name"].ToString(), price.ToString());
                }
                daps.myReader.Close();
            }
            return true;

        }
        private decimal getPriceRegular(Database daps, DateTime pickDate, DateTime returnDate, String carType, String pickupBranch, String returnBranch)
        {
            decimal duration, dRate, wRate, mRate, price, bFee;
            TimeSpan diff = (returnDate.Date - pickDate.Date);
            duration = diff.Days;

            // Gets the car's daily rate
            daps.query("select DRate" +
                         " from CarType" +
                         " where CarType.[Type] = " + "'" + carType + "'");
            daps.myReader.Read();
            dRate = (decimal)daps.myReader["DRate"];
            daps.myReader.Close();

            // Gets the car's weekly rate
            daps.query("select WRate" +
                         " from CarType" +
                         " where CarType.[Type] = " + "'" + carType + "'");
            daps.myReader.Read();
            wRate = (decimal)daps.myReader["WRate"];
            daps.myReader.Close();

            // Gets the car's monthly rate
            daps.query("select MRate" +
                         " from CarType" +
                         " where CarType.[Type] = " + "'" + carType + "'");
            daps.myReader.Read();
            mRate = (decimal)daps.myReader["MRate"];
            daps.myReader.Close();

            // Gets the car's branch fee
            daps.query("select BranchFee" +
                         " from CarType" +
                         " where CarType.[Type] = " + "'" + carType + "'");
            daps.myReader.Read();
            bFee = (decimal)daps.myReader["BranchFee"];
            daps.myReader.Close();

            // DAILY RATE
            if ((duration > 0) && (duration < 7))
            {
                // Multiplies the car's daily rate by the number of days
                if ((pickupBranch != returnBranch)) // If the car is to be returned at a different location
                {
                    price = (dRate * duration) + bFee;
                }
                else // If the car is to be returned to the same location
                { price = (dRate * duration); }

                return price;
            }
            // WEEKLY RATE
            else if ((duration >= 7) && (duration < 30))
            {
                if (duration % 7 == 0) // Full weeks
                {
                    if ((pickupBranch != returnBranch))
                    {
                        price = ((duration / 7) * wRate) + bFee;
                    }
                    else // If returning to same location
                    { price = (duration / 7) * wRate; }

                    return price;
                }
                else // Uneven weeks
                {
                    int weeks = (int)duration / 7; // Gets the amount of full weeks
                    int wks_remainder = (int)duration % 7; // Gets the amount of remaining days

                    if ((pickupBranch != returnBranch))
                    {
                        price = ((decimal)weeks * wRate) + ((decimal)wks_remainder * dRate) + bFee;
                    }
                    else
                    { price = ((decimal)weeks * wRate) + ((decimal)wks_remainder * dRate); }

                    return price;
                }
            }
            // MONTHLY RATE
            else
            {
                if (duration % 30 == 0) // If full months
                {
                    if ((pickupBranch != returnBranch))
                    {
                        price = (((int)duration / 30) * mRate) + bFee;
                    }
                    else
                    { price = ((int)duration / 30) * mRate; }

                    return price;
                }

                else // If uneven months
                {
                    int months = (int)duration / 30; // e.g. 64 / 30 = 2
                    int m_remainder = (int)duration % 30; // e.g. 64 % 30 = 4

                    if ((m_remainder >= 7) && (m_remainder < 30)) // If the remainder is a week or more
                    {
                        int weeks = (int)m_remainder / 7;
                        int w_remainder = (int)weeks % 7;

                        if (w_remainder == 0) // If the remaining weeks are full weeks
                        {
                            if ((pickupBranch != returnBranch))
                            {
                                price = (months * mRate) + (w_remainder * wRate) + bFee;
                            }
                            else
                            { price = (months * mRate) + (w_remainder * wRate); }

                            return price;
                        }
                        else // If the remaining weeks are uneven
                        {
                            int d_remainder = w_remainder;
                            if ((pickupBranch != returnBranch))
                            {
                                price = (months * mRate) + (w_remainder * wRate) + (d_remainder * dRate) + bFee;
                            }
                            else
                            { price = (months * mRate) + (w_remainder * wRate) + (d_remainder * dRate); }
                        }
                        return price;
                    }

                    else // If the remainder is less than a week
                    {
                        if ((pickupBranch != returnBranch))
                        {
                            price = (months * mRate) + (m_remainder * dRate) + bFee;
                        }
                        else
                        { price = (months * mRate) + (m_remainder * dRate); }

                        return price;
                    }
                }
            }
        }
        private void upgradeTransac_Click(object sender, EventArgs e)
        {
            if ((checkCarAvail(daps, carTypes.Text.Trim(), pickupBranch.Text.Trim()) == false) && (checkDate(daps, pickupDate.Value, returnDate.Value, carTypes.Text.Trim(), pickupBranch.Text.Trim()) == false))
            {

                inventory.Rows.Clear();
                string carT = carTypes.Text.Trim();
                DateTime pickUP = pickupDate.Value;
                DateTime returnD = returnDate.Value;
                string branchLoc = pickupBranch.Text.Trim();
                if (((validCustomer(custID.Text.Trim())) == true) && ((memberStatusCheck(custID.Text.Trim())) == true) && ((checkDate_Gold(daps, pickupDate.Value, returnDate.Value, carTypes.Text.Trim(), pickupBranch.Text.Trim())) == true))
                {
                    string statusMember = "Gold";
                    decimal totalPrice = getPriceGold(daps, pickUP, returnD, carT, branchLoc, returnBranch.Text.Trim());
                    if (carT == "Sedan")
                    {
                        daps.query("select C.[CAR_ID], CT.[Type],C.[Make], C.[Model], B.[Name]" +
                                 " from Car C, CarType CT, Branch B " +
                                 " where C.BID = B.BID and C.CT_ID = CT.CT_ID and B.[Name] = " + "'" + branchLoc + "'" + " and (CT.[Type] = 'SUV' or CT.[Type] = 'Minivan' or CT.[Type] = 'Luxury')" +
                                 " except" +
                                 " (select C.[CAR_ID], CT.[Type],C.[Make], C.[Model], B.[Name] " +
                                 " from Car C, CarType CT, Branch B, RentalTrans R" +
                                 " where C.BID = B.BID and C.CT_ID = CT.CT_ID and R.CAR_ID = C.CAR_ID and R.CT_ID = CT.CT_ID and R.PickUpBID = B.BID" +
                                 " and B.[Name] = " + "'" + branchLoc + "'" + " and (CT.[Type] = 'SUV' or CT.[Type] = 'Minivan' or CT.[Type] = 'Luxury')" +
                                 " and ((convert(smalldatetime, " + "'" + pickUP + "') between R.PickupDate and R.ReturnDate)" +
                                 " or (convert(smalldatetime, " + "'" + returnD + "') between R.PickupDate and R.ReturnDate)" +
                                 " or (R.PickUpDate > convert(smalldatetime, " + "'" + pickUP + "') and R.ReturnDate < convert(smalldatetime, " + "'" + returnD + "'))))");
                    }
                    else if (carT == "SUV")
                    {
                        daps.query("select C.[CAR_ID], CT.[Type],C.[Make], C.[Model], B.[Name]" +
                                 " from Car C, CarType CT, Branch B " +
                                 " where C.BID = B.BID and C.CT_ID = CT.CT_ID and B.[Name] = " + "'" + branchLoc + "'" + " and (CT.[Type] = 'Minivan' or CT.[Type] = 'Luxury')" +
                                 " except" +
                                 " (select C.[CAR_ID], CT.[Type],C.[Make], C.[Model], B.[Name] " +
                                 " from Car C, CarType CT, Branch B, RentalTrans R" +
                                 " where C.BID = B.BID and C.CT_ID = CT.CT_ID and R.CAR_ID = C.CAR_ID and R.CT_ID = CT.CT_ID and R.PickUpBID = B.BID" +
                                 " and B.[Name] = " + "'" + branchLoc + "'" + " and (CT.[Type] = 'Minivan' or CT.[Type] = 'Luxury')" +
                                 " and ((convert(smalldatetime, " + "'" + pickUP + "') between R.PickupDate and R.ReturnDate)" +
                                 " or (convert(smalldatetime, " + "'" + returnD + "') between R.PickupDate and R.ReturnDate)" +
                                 " or (R.PickUpDate > convert(smalldatetime, " + "'" + pickUP + "') and R.ReturnDate < convert(smalldatetime, " + "'" + returnD + "'))))");
                    }
                    else if (carT == "Minivan")
                    {
                        daps.query("select C.[CAR_ID], CT.[Type],C.[Make], C.[Model], B.[Name]" +
                                 " from Car C, CarType CT, Branch B " +
                                 " where C.BID = B.BID and C.CT_ID = CT.CT_ID and B.[Name] = " + "'" + branchLoc + "'" + " and CT.[Type] = 'Luxury'" +
                                 " except" +
                                 " (select C.[CAR_ID], CT.[Type],C.[Make], C.[Model], B.[Name] " +
                                 " from Car C, CarType CT, Branch B, RentalTrans R" +
                                 " where C.BID = B.BID and C.CT_ID = CT.CT_ID and R.CAR_ID = C.CAR_ID and R.CT_ID = CT.CT_ID and R.PickUpBID = B.BID" +
                                 " and B.[Name] = " + "'" + branchLoc + "'" + " and CT.[Type] = 'Luxury'" +
                                 " and ((convert(smalldatetime, " + "'" + pickUP + "') between R.PickupDate and R.ReturnDate)" +
                                 " or (convert(smalldatetime, " + "'" + returnD + "') between R.PickupDate and R.ReturnDate)" +
                                 " or (R.PickUpDate > convert(smalldatetime, " + "'" + pickUP + "') and R.ReturnDate < convert(smalldatetime, " + "'" + returnD + "'))))");
                    }
                    while (daps.myReader.Read())
                    {
                        inventory.Rows.Add(statusMember, daps.myReader["CAR_ID"].ToString(), daps.myReader["Type"].ToString(), daps.myReader["Make"].ToString(), daps.myReader["Model"].ToString(),
                            daps.myReader["Name"].ToString(), totalPrice.ToString());
                    }
                    daps.myReader.Close();
                }
                else
                {
                    MessageBox.Show("Customer is not a valid GOLD DAPS MEMBER.");
                }
            }
            else
            {
                MessageBox.Show("Cannot Upgrade.");
            }
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
        
        private decimal getPriceGold(Database daps, DateTime pickDate, DateTime returnDate, String carType, String pickupBranch, String returnBranch)
        {
            decimal duration, dRate, wRate, mRate, price, bFee;
            TimeSpan diff = (returnDate.Date - pickDate.Date);
            duration = diff.Days;

            // Gets the car's daily rate
            daps.query("select DRate" +
                         " from CarType" +
                         " where CarType.[Type] = " + "'" + carType + "'");
            daps.myReader.Read();
            dRate = (decimal)daps.myReader["DRate"];
            daps.myReader.Close();

            // Gets the car's weekly rate
            daps.query("select WRate" +
                         " from CarType" +
                         " where CarType.[Type] = " + "'" + carType + "'");
            daps.myReader.Read();
            wRate = (decimal)daps.myReader["WRate"];
            daps.myReader.Close();

            // Gets the car's monthly rate
            daps.query("select MRate" +
                         " from CarType" +
                         " where CarType.[Type] = " + "'" + carType + "'");
            daps.myReader.Read();
            mRate = (decimal)daps.myReader["MRate"];
            daps.myReader.Close();

            // Gets the car's branch fee
            daps.query("select BranchFee" +
                         " from CarType" +
                         " where CarType.[Type] = " + "'" + carType + "'");
            daps.myReader.Read();
            bFee = (decimal)daps.myReader["BranchFee"];
            daps.myReader.Close();
            // DAILY RATE
            if ((duration > 0) && (duration < 7))
            {
                price = (dRate * duration);
                return price;
            }
            // WEEKLY RATE
            else if ((duration >= 7) && (duration < 30))
            {
                if (duration % 7 == 0) // Full weeks
                {
                    price = (duration / 7) * wRate;
                    return price;
                }
                else // Uneven weeks
                {
                    int weeks = (int)duration / 7; // Gets the amount of full weeks
                    int wks_remainder = (int)duration % 7; // Gets the amount of remaining days
                    price = ((decimal)weeks * wRate) + ((decimal)wks_remainder * dRate);
                    return price;
                }
            }
            // MONTHLY RATE
            else
            {
                if (duration % 30 == 0) // If full months
                {
                    price = ((int)duration / 30) * mRate;
                    return price;
                }

                else // If uneven months
                {
                    int months = (int)duration / 30; // e.g. 64 / 30 = 2
                    int m_remainder = (int)duration % 30; // e.g. 64 % 30 = 4

                    if ((m_remainder >= 7) && (m_remainder < 30)) // If the remainder is a week or more
                    {
                        int weeks = (int)m_remainder / 7;
                        int w_remainder = (int)weeks % 7;

                        if (w_remainder == 0) // If the remaining weeks are full weeks
                        {
                            price = (months * mRate) + (w_remainder * wRate);
                            return price;
                        }
                        else // If the remaining weeks are uneven
                        {
                            int d_remainder = w_remainder;
                            price = (months * mRate) + (w_remainder * wRate) + (d_remainder * dRate);
                        }
                        return price;
                    }

                    else // If the remainder is less than a week
                    {
                        price = (months * mRate) + (m_remainder * dRate);
                        return price;
                    }
                }
            }
        }
        private void inventory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = inventory.CurrentCell.RowIndex;
            int col = inventory.CurrentCell.ColumnIndex;

        }
        private void authorizeTransac_Click(object sender, EventArgs e)
        { 
            string carFull, transacIDString, customerID,pickUpD, returnD, pickUpBrID, returnBrID, carsID, typeID;
            decimal price, transacID;
            if(inventory.CurrentCell != null)
            {
                int row = inventory.CurrentCell.RowIndex;
                int col = inventory.CurrentCell.ColumnIndex;
                carFull = (string)(inventory.Rows[row].Cells[1].Value.ToString().Trim() + " " + inventory.Rows[row].Cells[6].Value);

                daps.query("select max([TID]) as trans" +
                         " from RentalTrans");
                daps.myReader.Read();
                transacID = Int32.Parse(daps.myReader["trans"].ToString());
                transacID += 1;
                transacIDString = transacID.ToString();
                daps.myReader.Close();

                pickUpD= pickupDate.Value.ToShortDateString();
                returnD = returnDate.Value.ToShortDateString();
                customerID = custID.Text.ToString().Trim();
                daps.query("select BID as bID" +
                         " from Branch B" +
                         " where B.[Name] = " + "'" + pickupBranch.Text.Trim() + "'");
                daps.myReader.Read();
                pickUpBrID = (daps.myReader["bID"].ToString());
                daps.myReader.Close();

                daps.query("select BID as rBID" +
                         " from Branch B" +
                         " where B.[Name] = " + "'" + returnBranch.Text.Trim() + "'");
                daps.myReader.Read();
                returnBrID = (daps.myReader["rBID"].ToString());
                daps.myReader.Close();

                carsID = (string)(inventory.Rows[row].Cells[1].Value.ToString().Trim());

                daps.query("select CT_ID as types" +
                         " from CarType CT" +
                         " where CT.[Type] = " + "'" + inventory.Rows[row].Cells[2].Value.ToString().Trim() + "'");
                daps.myReader.Read();
                typeID = daps.myReader["types"].ToString();
                daps.myReader.Close();
                price = decimal.Parse(inventory.Rows[row].Cells[6].Value.ToString());
                daps.query("insert into RentalTrans values(" + "'00" + transacIDString + "'," + "'" + pickUpD + "'," + "'" + returnD + "'," + "'" + DBNull.Value + "'," + "'" + price + "'," + "'" + customerID + "'," + "'" + pickUpBrID + "'," + "'" + returnBrID + "'," + "'" + carsID + "'," + "'" + typeID + "');"); // actual return date is set to 1900-01-01 00:00:00
                daps.myReader.Read();
                daps.myReader.Close();
                MessageBox.Show("00" + transacIDString + " pickup: " + pickUpD + " return: " + returnD + " custID: " + customerID + "  pickup Branch: " + pickUpBrID + "  return branch:" + returnBrID + " car ID: " + carsID + " " + " type ID: " + typeID);
            }
            else
            {
                MessageBox.Show("Please select an item from the list.");
            }
        }

    }
}
