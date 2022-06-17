using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRental
{
    public partial class InventoryManagement : Form
    {
        public Database D;
        public InventoryManagement()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen; 
            D = new Database();

            // Query for the branch name combo box
            D.query("select [Name] from Branch");
            while (D.myReader.Read())
            { BRANCH_comboBox.Items.Add(D.myReader["Name"].ToString()); }
            D.myReader.Close();

            // Query for the car type combo box
            D.query("select [Type] from CarType");
            while (D.myReader.Read())
            { TYPE_comboBox.Items.Add(D.myReader["Type"].ToString().Trim()); }
            D.myReader.Close();

        }
        private void TEST(object sender, EventArgs e)
        {
            CARID_textBox.Clear();
            PIN_textBox.Clear();
            TYPE_comboBox.SelectedIndex = -1;
            PLATENO_textBox.Clear();
            MODEL_textBox.Clear();
            MAKE_textBox.Clear();
            MILES_textBox.Clear();
            YEAR_textBox.Clear();
            CARID_textBox.ReadOnly = false;
            string BranchName = BRANCH_comboBox.Text.Trim().ToString();
            string query1 = "select C.[CAR_ID], C.[PIN], CT.[Type], C.[PlateNo], C.Model, C.[Make], C.[Miles], C.[Year]" +
                         " from Car C, CarType CT, Branch B " +
                         " where C.BID = B.BID and C.CT_ID = CT.CT_ID and B.[Name] = " + "'" + BranchName + "'";

            D.query(query1);
            ValueGrid.Rows.Clear();
            while (D.myReader.Read())
            {
                ValueGrid.Rows.Add(D.myReader["CAR_ID"].ToString(), D.myReader["PIN"].ToString(), D.myReader["Type"].ToString(), D.myReader["PlateNo"].ToString(),
                     D.myReader["Model"].ToString(), D.myReader["Make"].ToString(), D.myReader["Miles"].ToString(), D.myReader["Year"].ToString());
            }
            D.myReader.Close();
        }

        private void ValueGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show(ValueGrid.SelectedRows[0].Cells[1].Value.ToString());
        }

        private void add_button_Click(object sender, EventArgs e)
        {
            string CARID   = CARID_textBox.Text;
            if (CARID == "") { MessageBox.Show("Please fill out CAR ID to add a new car to the inventory.", "Missing field"); }
            string PIN     = PIN_textBox.Text;
            if (PIN == "") { MessageBox.Show("Please fill out PIN to add a new car to the inventory.", "Missing field"); }
            string PLATENO = PLATENO_textBox.Text;
            if (PLATENO == "") { MessageBox.Show("Please fill out PLATE NO. to add a new car to the inventory.", "Missing field"); }
            string TYPE    = TYPE_comboBox.Text;
            if (TYPE == "") { MessageBox.Show("Please select TYPE to add a new car to the inventory.", "Missing field"); }
            string MODEL   = MODEL_textBox.Text;
            string MAKE    = MAKE_textBox.Text;
            string MILES   = MILES_textBox.Text;
            string YEAR    = YEAR_textBox.Text;
            string BRANCH  = BRANCH_comboBox.Text;
            if (BRANCH == "") { MessageBox.Show("Please select branch name to add a new car to the inventory.", "Missing field"); }
            else
            {
                // Checks to see if given CAR ID already exists in database
                List<string> CarIDs = new List<string>();
                D.query("select [CAR_ID] from Car");
                while (D.myReader.Read())
                { CarIDs.Add(D.myReader["CAR_ID"].ToString()); }
                D.myReader.Close();

                if (CarIDs.Contains(CARID))
                {
                    MessageBox.Show("Unable to add. Car ID already exists in the system.", "Error");
                    return;
                }

                string message = "Are you sure you want to add a new car to the inventory?";
                string title = "Add CAR ID: " + CARID;
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Yes) 
                {
                    MessageBox.Show("ADDED");
                    //string addQuery = ;
                    //D.insert(addQuery);
                    //this.TEST(sender, e);
                    //this.ValueGrid_CellContentClick(sender, e);
                }
            }

        }

        private void update_button_Click(object sender, EventArgs e)
        {   
            string CARID   = CARID_textBox.Text;

            if (CARID != "") // Checks if user clicked on a car in table
            {
                List<string> CarIDs = new List<string>();
                D.query("select [CAR_ID] from Car");
                while (D.myReader.Read())
                { CarIDs.Add(D.myReader["CAR_ID"].ToString()); }
                D.myReader.Close();

                if (!CarIDs.Contains(CARID))
                {
                    MessageBox.Show("Unable to update. Car ID can not be found in the system. Please click on an existing car in the table.", "Error");
                    return;
                }

                string PIN     = PIN_textBox.Text;
                string PLATENO = PLATENO_textBox.Text;
                string TYPE    = TYPE_comboBox.Text;
                string MODEL   = MODEL_textBox.Text;
                string MAKE    = MAKE_textBox.Text;
                string MILES   = MILES_textBox.Text;
                string YEAR    = YEAR_textBox.Text;

                // Gets the CT_ID of the car
                string getTypeID = "select CT.[CT_ID]" +
                    " from CarType CT " +
                    " where CT.[Type] = " + "'" + TYPE + "'";
                D.query(getTypeID);
                D.myReader.Read();
                string TypeID = D.myReader["CT_ID"].ToString();
                D.myReader.Close();
                
                
                // Gets the BID of the car
                string getBID = "select B.[BID]" +
                    " from Car C, Branch B" +
                    " where C.BID = B.BID and C.[CAR_ID] = " + "'" + CARID + "'";
                D.query(getBID);
                D.myReader.Read();
                string BID = D.myReader["BID"].ToString();
                D.myReader.Close();

                // Display message box to allow update
                string message = "Are you sure you want to change this car's details?";
                string title = "Update CAR ID: " + CARID;
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Yes)
                {
                    string updateQuery = "update Car set PIN = '" + PIN + "', " +
                        "PlateNO = '" + PLATENO + "', " +
                        "Model = '" + MODEL + "', " +
                        "Make = '" + MAKE + "', " +
                        "Miles = '" + MILES + "', " +
                        "Year = '" + YEAR + "', " +
                        "BID = '" + BID + "', " +
                        "CT_ID = '" + TypeID + "'" +
                        "where CAR_ID = '" + CARID + "'";
                    D.insert(updateQuery);
                    this.TEST(sender, e);
                    this.ValueGrid_CellContentClick(sender, e);
                }
            }
            else { MessageBox.Show("Please click on an existing car in the table"); }
        }

        private void delete_button_Click(object sender, EventArgs e)
        {
            string CARID = CARID_textBox.Text;
            if (CARID != "")
            {
                List<string> CarIDs = new List<string>();
                D.query("select [CAR_ID] from Car");
                while (D.myReader.Read())
                { CarIDs.Add(D.myReader["CAR_ID"].ToString()); }
                D.myReader.Close();

                if (!CarIDs.Contains(CARID))
                {
                    MessageBox.Show("Unable to delete. Car ID can not be found in the system.", "Error");
                    return;
                }

                string message = "Are you sure you want to delete this car?";
                string title = "Delete CAR ID: " + CARID;
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Yes)
                {
                    D.insert("delete from Car where CAR_ID = '" + CARID + "'");
                    this.TEST(sender, e);
                }
            }
            else
            { MessageBox.Show("Please click on an existing car in the table"); }
        }

        private void ValueGrid_CellContentClick(object sender, EventArgs e)
        {
            if (ValueGrid.SelectedRows[0].Cells[0].Value == null)
            {
                CARID_textBox.Clear();
                PIN_textBox.Clear();
                TYPE_comboBox.SelectedIndex = -1;
                PLATENO_textBox.Clear();
                MODEL_textBox.Clear();
                MAKE_textBox.Clear();
                MILES_textBox.Clear();
                YEAR_textBox.Clear();
                CARID_textBox.ReadOnly = false;
            }
            else
            {
                CARID_textBox.Text   = ValueGrid.SelectedRows[0].Cells[0].Value.ToString().Trim();
                PIN_textBox.Text     = ValueGrid.SelectedRows[0].Cells[1].Value.ToString().Trim();
                TYPE_comboBox.Text = ValueGrid.SelectedRows[0].Cells[2].Value.ToString().Trim();
                PLATENO_textBox.Text = ValueGrid.SelectedRows[0].Cells[3].Value.ToString().Trim();
                MODEL_textBox.Text   = ValueGrid.SelectedRows[0].Cells[4].Value.ToString().Trim();
                MAKE_textBox.Text    = ValueGrid.SelectedRows[0].Cells[5].Value.ToString().Trim();
                MILES_textBox.Text   = ValueGrid.SelectedRows[0].Cells[6].Value.ToString().Trim();
                YEAR_textBox.Text    = ValueGrid.SelectedRows[0].Cells[7].Value.ToString().Trim();
                CARID_textBox.ReadOnly = true;
            }
        }
    }
}
