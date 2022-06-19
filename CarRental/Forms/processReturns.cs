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
    public partial class processReturns : Form
    {
        private bool dateChanged = false;
        public Database daps;
        public processReturns()
        {
            InitializeComponent();
            daps = new Database();//update RentalTrans set ActualRetDate = NULL where TID = '0029'; updating specific entry
        }
        private void processReturns_Load(object sender, EventArgs e)
        {
            returnDate.ValueChanged += new System.EventHandler(returnDate_ValueChanged);
        }

        private void returnDate_ValueChanged(object sender, EventArgs e)
        {
            dateChanged = true;
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        

        private void availability_Click(object sender, EventArgs e)
        {
            
            if (validCustomer(custID.Text) == true && textFieldCheck() == true)
            {
                string cust = custID.Text.Trim();
                string queryTrans = "select TID, PickupDate, ReturnDate, R.CID as transCustID, R.CT_ID as carType, R.CAR_ID as transCarID, Car.Make as carMake, Car.Model as carModel" +
                    " from RentalTrans R, Customer C, Car" +
                    " where R.CID = C.CID and Car.CAR_ID = R.CAR_ID and C.CID =" + "'"  + cust + "'";
                daps.query(queryTrans);
                transactions.Rows.Clear();
                if(daps.myReader.Read() == true)
                {
                    daps.myReader.Close();
                    daps.query(queryTrans);
                    while (daps.myReader.Read())
                    {
                        transactions.Rows.Add(daps.myReader["TID"], daps.myReader["PickupDate"], daps.myReader["ReturnDate"], daps.myReader["transCustID"],daps.myReader["carType"], daps.myReader["transCarID"], daps.myReader["carMake"], daps.myReader["carModel"]);
                    }
                }
                daps.myReader.Close();
            }
            else
            {
                MessageBox.Show("Could not find any transaction history for customer.");
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
        //checks if text fields are filled
        private bool textFieldCheck()
        {
            if (custID.Text.Trim() == "" || dateChanged == false)
            {
                MessageBox.Show("Missing one or more required field(s).", "Error");
                return false;
            }
            else
            {
                return true;
            }
        }

        private void normalRet_Click(object sender, EventArgs e)
        {
            int row = transactions.CurrentCell.RowIndex;
            int col = transactions.CurrentCell.ColumnIndex;
            if(transactions.CurrentCell != null)
            {
                if((checkReturnDate(DateTime.Parse(transactions.Rows[row].Cells[1].Value.ToString().Trim()), returnDate.Value, DateTime.Parse(transactions.Rows[row].Cells[2].Value.ToString().Trim()))) == true)
                {
                    daps.query("update RentalTrans set ActualRetDate =" + "'" + returnDate.Value.ToShortDateString() + "'" + " where TID =" + "'" + transactions.Rows[row].Cells[0].Value.ToString() +"'" +";");
                    daps.myReader.Close();
                }
            }
        }
        private bool checkReturnDate(DateTime pickUp ,DateTime actualReturn, DateTime originalReturn)
        {
            if(actualReturn.Date > originalReturn.Date)
            {
                MessageBox.Show("Customer is late please select LATE RETURN.");
                return false;
            }
            else if(pickUp.Date > actualReturn.Date)
            {
                MessageBox.Show("Please enter a valid RETURNED DATE.");
                return false;
            }
            else
            {
                MessageBox.Show("Customer is good to go.");
                return true;
            }
        }
        private void lateRet_Click(object sender, EventArgs e)
        {
            //check database for laste fee from cspecific car type then apply late fee on top of cost in transaction and update cost in transaction
            decimal lateCost, originalCost, totalCost;
            int row = transactions.CurrentCell.RowIndex;
            int col = transactions.CurrentCell.ColumnIndex;
            string carT = transactions.Rows[row].Cells[5].Value.ToString().Trim();
            string transacID = transactions.Rows[row].Cells[0].Value.ToString().Trim();
            if ((checkLateDate(daps, DateTime.Parse(transactions.Rows[row].Cells[1].Value.ToString().Trim()), returnDate.Value, DateTime.Parse(transactions.Rows[row].Cells[2].Value.ToString().Trim()))) == true)
            {
                daps.myReader.Close();
                daps.query("select distinct LateFee as lateFee" +
                    " from RentalTrans R, CarType CT" +
                    " where R.CT_ID = CT.CT_ID and R.CT_ID =" + "'" + carT + "'");
                daps.myReader.Read();
                lateCost = decimal.Parse(daps.myReader["lateFee"].ToString());
                daps.myReader.Close();

                daps.query("select Cost" +
                    " from RentalTrans R" +
                    " where R.TID =" + "'" + transacID + "'");
                daps.myReader.Read();
                originalCost = decimal.Parse(daps.myReader["Cost"].ToString());
                daps.myReader.Close();
                totalCost = originalCost + lateCost;
                daps.query("update RentalTrans set Cost =" + totalCost + "where TID =" + "'" + transacID + "';");
                daps.myReader.Close();
                MessageBox.Show("Customer Late Fee is " + "$" + lateCost.ToString() + " + original fee ( $" + originalCost.ToString() + " )\n for a total balance remaining of $" + totalCost.ToString());
            }
        }
        private bool checkLateDate(Database daps,DateTime pickUp, DateTime actualReturn, DateTime originalReturn)
        {
            if(actualReturn.Date > originalReturn.Date)
            {
                return true;
            }
            else if(pickUp > actualReturn.Date)
            {
                MessageBox.Show("Please enter a valid RETURNED DATE.");
                return false;
            }
            else
            {
                MessageBox.Show("Customer is not late please choose AUTHORIZE RETURN.");
                return false;
            }
        }
        private void transactions_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = transactions.CurrentCell.RowIndex;
            int col = transactions.CurrentCell.ColumnIndex;
        }

        
    }
}
