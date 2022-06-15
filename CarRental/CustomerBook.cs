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

//----------This screen displays the cars that are available to the user based on their search filters in a grid;----------
//----------the price is calculated in this function and is displayed on the top-right corner of the screen      ----------
namespace CarRental
{
    public partial class CustomerBook : Form
    {
        public Database D3;
        public CustomerAvail customerAvail;
        public Start start;
        public CustomerBook(CustomerAvail customerAvail, Start start)
        {
            InitializeComponent();
            D3 = new Database();
            this.customerAvail = customerAvail;
            this.start = start;

            string CarType = this.customerAvail.CarType.Text.Trim().ToString();
            string CID = this.customerAvail.IdBox.Text.Trim().ToString();
            string PickupDate = this.customerAvail.pickupDate.Text.Trim().ToString();
            string ReturnDate = this.customerAvail.returnDate.Text.Trim().ToString();
            string PickupLoc = this.customerAvail.PickUpLoc.Text.Trim().ToString();
            string ReturnLoc = this.customerAvail.RetLoc.Text.Trim().ToString();

            string UpgradeType;
            // Creates a list of car types taken from the database
            List<string> CarTypes = new List<string>();
            D3.query("select [Type] from CarType CT");
            while (D3.myReader.Read())
            {
                CarTypes.Add(D3.myReader["Type"].ToString().Trim());
            }
            D3.myReader.Close();

            int index = CarTypes.IndexOf(CarType);
            int count = CarTypes.Count(); 

            if (index != (count - 1))
            { UpgradeType = CarTypes[index + 1];}
            else { UpgradeType = CarTypes[index];}

            // Takes the eligible car details from the database (cars that match the car type and pickup branch that aren't linked to a transaction for the selected dates)
            string query1 = "select C.[CAR_ID], CT.[Type], C.[Make], C.Model, C.[Year], C.[Miles], C.[PIN], C.[PlateNo]" +
                         " from Car C, CarType CT, Branch B " +
                         " where C.BID = B.BID and C.CT_ID = CT.CT_ID and B.[Name] = " + "'" + PickupLoc + "'" + " and CT.[Type] = " + "'" + CarType + "'" +
                         " except" +
                         " (select C.[CAR_ID], CT.[Type], C.[Make], C.Model, C.[Year], C.[Miles], C.[PIN], C.[PlateNo] " +
                         " from Car C, CarType CT, Branch B, RentalTrans R" +
                         " where C.BID = B.BID and C.CT_ID = CT.CT_ID and R.CAR_ID = C.CAR_ID and R.CT_ID = CT.CT_ID and R.PickUpBID = B.BID" +
                         " and B.[Name] = " + "'" + PickupLoc + "'" + " and CT.[Type] = " + "'" + CarType + "'" +
                         " and ((convert(smalldatetime, " + "'" + this.customerAvail.pickupDate.Value + "') between R.PickupDate and R.ReturnDate)" +
                         " or (convert(smalldatetime, " + "'" + this.customerAvail.returnDate.Value + "') between R.PickupDate and R.ReturnDate)" +
                         " or (R.PickUpDate > convert(smalldatetime, " + "'" + this.customerAvail.pickupDate.Value + "') and R.ReturnDate < convert(smalldatetime, " + "'" + this.customerAvail.returnDate.Value + "'))))";
            D3.query(query1);
            ValueGrid.Rows.Clear();

            // If the reader returns something, then that means that the customer's search (gold or non-gold) went through
            if (D3.myReader.Read() == true)
            {
                D3.myReader.Close();
                D3.query(query1);
                while (D3.myReader.Read())
                {
                    ValueGrid.Rows.Add(D3.myReader["CAR_ID"].ToString(), D3.myReader["Type"].ToString(), D3.myReader["Make"].ToString(), D3.myReader["Model"].ToString(),
                        D3.myReader["Year"].ToString(), D3.myReader["Miles"].ToString(), D3.myReader["PIN"].ToString(), D3.myReader["PlateNo"].ToString());
                }
                D3.myReader.Close();
            }
            // If it returns nothing, then we can assume that the customer is a gold member that will upgrade and we will show cars of other type
            else
            {
                D3.myReader.Close();
                D3.query("select C.[CAR_ID], CT.[Type], C.[Make], C.Model, C.[Year], C.[Miles], C.[PIN], C.[PlateNo]" +
                         " from Car C, CarType CT, Branch B " +
                         " where C.BID = B.BID and C.CT_ID = CT.CT_ID and B.[Name] = " + "'" + PickupLoc + "'" + " and CT.[Type] = " + "'" + UpgradeType + "'" +
                         " except" +
                         " (select C.[CAR_ID], CT.[Type], C.[Make], C.Model, C.[Year], C.[Miles], C.[PIN], C.[PlateNo] " +
                         " from Car C, CarType CT, Branch B, RentalTrans R" +
                         " where C.BID = B.BID and C.CT_ID = CT.CT_ID and R.CAR_ID = C.CAR_ID and R.CT_ID = CT.CT_ID and R.PickUpBID = B.BID" +
                         " and B.[Name] = " + "'" + PickupLoc + "'" + " and CT.[Type] = " + "'" + UpgradeType + "'" +
                         " and ((convert(smalldatetime, " + "'" + this.customerAvail.pickupDate.Value + "') between R.PickupDate and R.ReturnDate)" +
                         " or (convert(smalldatetime, " + "'" + this.customerAvail.returnDate.Value + "') between R.PickupDate and R.ReturnDate)" +
                         " or (R.PickUpDate > convert(smalldatetime, " + "'" + this.customerAvail.pickupDate.Value + "') and R.ReturnDate < convert(smalldatetime, " + "'" + this.customerAvail.returnDate.Value + "'))))");
                while (D3.myReader.Read())
                {
                    ValueGrid.Rows.Add(D3.myReader["CAR_ID"].ToString(), D3.myReader["Type"].ToString(), D3.myReader["Make"].ToString(), D3.myReader["Model"].ToString(),
                        D3.myReader["Year"].ToString(), D3.myReader["Miles"].ToString(), D3.myReader["PIN"].ToString(), D3.myReader["PlateNo"].ToString());
                }
                D3.myReader.Close();
            }

            PriceLabel.Text = GetPrice(D3, this.customerAvail, CarType).ToString();
            string Cost = PriceLabel.Text;
        }

        //------Function that calculates the car price depending on car type, duration, and customer's membership type------
        private decimal GetPrice(Database D3, CustomerAvail customerAvail, String CT_Name)
        {
            decimal days;
            TimeSpan diff = (customerAvail.returnDate.Value.Date - customerAvail.pickupDate.Value.Date);
            days = diff.Days;

            decimal DailyRate, WklyRate, MthlyRate, Price, BFee;
            bool CustMemb;

            // Gets the customer's membership type (true for gold, false for not gold)
            D3.query("select MembType" +
                     " from Customer" +
                     " where Customer.[CID] = " + "'" + customerAvail.IdBox.Text + "'");
            D3.myReader.Read();
            CustMemb = (bool)D3.myReader["MembType"];
            //MessageBox.Show("Membership type: " + CustMemb.ToString());
            D3.myReader.Close();

            // Gets the car's daily rate
            D3.query("select DRate" +
                         " from CarType" +
                         " where CarType.[Type] = " + "'" + CT_Name + "'");
            D3.myReader.Read();
            DailyRate = (decimal)D3.myReader["DRate"];
            D3.myReader.Close();

            // Gets the car's weekly rate
            D3.query("select WRate" +
                         " from CarType" +
                         " where CarType.[Type] = " + "'" + CT_Name + "'");
            D3.myReader.Read();
            WklyRate = (decimal)D3.myReader["WRate"];
            D3.myReader.Close();

            // Gets the car's monthly rate
            D3.query("select MRate" +
                         " from CarType" +
                         " where CarType.[Type] = " + "'" + CT_Name + "'");
            D3.myReader.Read();
            MthlyRate = (decimal)D3.myReader["MRate"];
            D3.myReader.Close();

            // Gets the car's branch fee
            D3.query("select BranchFee" +
                         " from CarType" +
                         " where CarType.[Type] = " + "'" + CT_Name + "'");
            D3.myReader.Read();
            BFee = (decimal)D3.myReader["BranchFee"];
            D3.myReader.Close();

            // DAILY RATE
            if ((days > 0) && (days < 7))
            {
                // Multiplies the car's daily rate by the number of days
                if ((customerAvail.checkBox.Checked == true) && (customerAvail.PickUpLoc.Text != customerAvail.RetLoc.Text)) // If the car is to be returned at a different location
                {
                    if (CustMemb == true) // If the customer has gold membership
                    {Price = (DailyRate * days);}
                    else // If customer doesn't have gold membership
                    {Price = (DailyRate * days) + BFee;}
                }
                else // If the car is to be returned to the same location
                {Price = (DailyRate * days);}

                return Price;
            }

            // WEEKLY RATE
            else if ((days >= 7) && (days < 30))
            {
                if (days % 7 == 0) // Full weeks
                {
                    if ((customerAvail.checkBox.Checked == true) && (customerAvail.PickUpLoc.Text != customerAvail.RetLoc.Text))
                    {
                        if (CustMemb == true) // If the customer has gold membership
                        {Price = (days / 7) * WklyRate;}
                        else // If customer doesn't have gold membership
                        {Price = ((days / 7) * WklyRate) + BFee;}
                    }
                    else // If returning to same location
                    {Price = (days / 7) * WklyRate;}

                    return Price;
                }
                else // Uneven weeks
                {
                    int weeks = (int)days / 7; // Gets the amount of full weeks
                    int wks_remainder = (int)days % 7; // Gets the amount of remaining days

                    if ((customerAvail.checkBox.Checked == true) && (customerAvail.PickUpLoc.Text != customerAvail.RetLoc.Text))
                    {
                        if (CustMemb == true)
                        {Price = ((decimal)weeks * WklyRate) + ((decimal)wks_remainder * DailyRate);}
                        else
                        {Price = ((decimal)weeks * WklyRate) + ((decimal)wks_remainder * DailyRate) + BFee;}
                    }
                    else
                    {Price = ((decimal)weeks * WklyRate) + ((decimal)wks_remainder * DailyRate);}

                    return Price;
                }
            }

            // MONTHLY RATE
            else
            {
                if (days % 30 == 0) // If full months
                {
                    if ((customerAvail.checkBox.Checked == true) && (customerAvail.PickUpLoc.Text != customerAvail.RetLoc.Text))
                    {
                        if (CustMemb == true)
                        {Price = ((int)days / 30) * MthlyRate;}
                        else
                        {Price = (((int)days / 30) * MthlyRate) + BFee;}
                    }
                    else
                    {Price = ((int)days / 30) * MthlyRate;}

                    return Price;
                }

                else // If uneven months
                {
                    int months = (int)days / 30; // e.g. 64 / 30 = 2
                    int m_remainder = (int)days % 30; // e.g. 64 % 30 = 4

                    if ((m_remainder >= 7) && (m_remainder < 30)) // If the remainder is a week or more
                    {
                        int weeks = (int)m_remainder / 7;
                        int w_remainder = (int)weeks % 7;

                        if (w_remainder == 0) // If the remaining weeks are full weeks
                        {
                            if ((customerAvail.checkBox.Checked == true) && (customerAvail.PickUpLoc.Text != customerAvail.RetLoc.Text))
                            {
                                if (CustMemb == true)
                                {Price = (months * MthlyRate) + (w_remainder * WklyRate);}
                                else
                                {Price = (months * MthlyRate) + (w_remainder * WklyRate) + BFee;}
                            }
                            else
                            {Price = (months * MthlyRate) + (w_remainder * WklyRate);}

                            return Price;
                        }
                        else // If the remaining weeks are uneven
                        {
                            int d_remainder = w_remainder;
                            if ((customerAvail.checkBox.Checked == true) && (customerAvail.PickUpLoc.Text != customerAvail.RetLoc.Text))
                            {
                                if (CustMemb == true)
                                {Price = (months * MthlyRate) + (w_remainder * WklyRate) + (d_remainder * DailyRate);}
                                else
                                {Price = (months * MthlyRate) + (w_remainder * WklyRate) + (d_remainder * DailyRate) + BFee;}
                            }
                            else
                            {Price = (months * MthlyRate) + (w_remainder * WklyRate) + (d_remainder * DailyRate);}
                        }
                        return Price;
                    }

                    else // If the remainder is less than a week
                    {
                        if ((customerAvail.checkBox.Checked == true) && (customerAvail.PickUpLoc.Text != customerAvail.RetLoc.Text))
                        {
                            if (CustMemb == true)
                            {Price = (months * MthlyRate) + (m_remainder * DailyRate);}
                            else
                            {Price = (months * MthlyRate) + (m_remainder * DailyRate) + BFee;}
                        }
                        else
                        {Price = (months * MthlyRate) + (m_remainder * DailyRate);}

                        return Price;
                    }
                }
            }
        }

        private void Home_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void SelectButton_Click_1(object sender, EventArgs e)
        {
            CustomerConfirm customerConfirm = new(this);
            this.Hide();
            customerConfirm.ShowDialog();
        }

        private void ValueGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = ValueGrid.CurrentCell.RowIndex;
            int col = ValueGrid.CurrentCell.ColumnIndex;
            SelectedCar.Text = (string)(ValueGrid.Rows[row].Cells[2].Value.ToString().Trim() + " " + ValueGrid.Rows[row].Cells[3].Value.ToString().Trim());
        }

    }
}
