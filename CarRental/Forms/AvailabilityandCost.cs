using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRental.Forms
{
    public partial class AvailabilityandCost : Form
    {
        public Database daps;
        public AvailabilityandCost()
        {
            daps = new Database();
            InitializeComponent();
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

        private void availability_Click(object sender, EventArgs e)
        {
            string carT = carTypes.Text.Trim();
            string branchP = pickupBranch.Text.Trim();
  
            decimal cost;
            if(((textFieldCheck()) == true) && ((dateValidity(returnDate.Value, pickupDate.Value)) == true) && ((checkDate(daps, pickupDate.Value,returnDate.Value,carTypes.Text.ToString(),pickupBranch.Text.ToString())) == true))
            {
                cost = getPriceRegular(daps, pickupDate.Value, returnDate.Value, carTypes.Text.ToString(),pickupBranch.Text.ToString(),returnBranch.Text.ToString());
                string queryCars = "select Car_ID, C.Year as years, Miles, Make, Model, B.Name as names" +
                    " from Car C, CarType CT, Branch B" +
                    " where C.CT_ID = CT.CT_ID and C.BID = B.BID and CT.Type = " + "'" + carT + "'" + "and B.Name = " + "'" + branchP + "'";
                daps.query(queryCars);
                inventory.Rows.Clear();

                if (daps.myReader.Read() == true)
                {
                    daps.myReader.Close();
                    daps.query(queryCars);
                    while (daps.myReader.Read())
                    {
                         inventory.Rows.Add(daps.myReader["Car_ID"], daps.myReader["years"], daps.myReader["Miles"], daps.myReader["Make"], daps.myReader["Model"], daps.myReader["names"], cost.ToString());
                    }
                   
                }
                daps.myReader.Close();
            }
            else
            {
                MessageBox.Show("No Hits.");
            }
        }
        //checks if text fields are filled
        private bool textFieldCheck()
        {
            if (pickupBranch.Text.Trim() == "" || returnBranch.Text.Trim() == "" || carTypes.Text.Trim() == "")
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






    }

}
