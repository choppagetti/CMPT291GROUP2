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

            // The following block adds all the names of branches to a combo box
            D.query("select [Name] from Branch");
            while (D.myReader.Read())
            { BRANCH_comboBox.Items.Add(D.myReader["Name"].ToString()); }
            D.myReader.Close();

            // The following block adds all the car types to a combo box
            D.query("select [Type] from CarType");
            while (D.myReader.Read())
            { TYPE_comboBox.Items.Add(D.myReader["Type"].ToString().Trim()); }
            D.myReader.Close();

        }
        private void TEST(object sender, EventArgs e)
        {
            // The following block clears all user input textboxes 
            CARID_textBox.Clear();
            PIN_textBox.Clear();
            TYPE_comboBox.SelectedIndex = -1;
            PLATENO_textBox.Clear();
            MODEL_textBox.Clear();
            MAKE_textBox.Clear();
            MILES_textBox.Clear();
            YEAR_textBox.Clear();
            CARID_textBox.ReadOnly = false; // Allows user to edit CAR ID textbox

            // The following block shows all of the branch's cars when user selects a branch name in combo box
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

        // This function is not needed but I can't seem to delete it since it has 2 references
        private void ValueGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show(ValueGrid.SelectedRows[0].Cells[1].Value.ToString());
        }

        private void add_button_Click(object sender, EventArgs e)
        {
            // The following block takes all user inputs and error checks 
            string CARID = CARID_textBox.Text;
            if (CARID == "") { MessageBox.Show("Please fill out CAR ID to add a new car to the inventory.", "Missing field"); return; }
            string PIN = PIN_textBox.Text;
            if (PIN == "") { MessageBox.Show("Please fill out PIN to add a new car to the inventory.", "Missing field"); return; }
            string TYPE = TYPE_comboBox.Text;
            if (TYPE == "") { MessageBox.Show("Please select TYPE to add a new car to the inventory.", "Missing field"); return; }
            string PLATENO = PLATENO_textBox.Text;
            if (PLATENO == "") { MessageBox.Show("Please fill out PLATE NO. to add a new car to the inventory.", "Missing field"); return; }
            string MODEL = MODEL_textBox.Text;
            if (MODEL == "") { MessageBox.Show("Please fill out MODEL to add a new car to the inventory.", "Missing field"); return; }
            string MAKE = MAKE_textBox.Text;
            if (MAKE == "") { MessageBox.Show("Please fill out MAKE to add a new car to the inventory.", "Missing field"); return; }
            string MILES = MILES_textBox.Text;
            if (MILES == "") { MessageBox.Show("Please fill out MILES to add a new car to the inventory.", "Missing field"); return; }
            string YEAR = YEAR_textBox.Text;
            if (YEAR == "") { MessageBox.Show("Please fill out YEAR to add a new car to the inventory.", "Missing field"); return; }
            string BRANCH = BRANCH_comboBox.Text;
            if (BRANCH == "") { MessageBox.Show("Please select branch name to add a new car to the inventory.", "Missing field"); return; }
            else
            {
                // The following block checks to see if given CAR ID already exists in database
                List<string> CarIDs = new List<string>();
                D.query("select [CAR_ID] from Car");
                while (D.myReader.Read())
                { CarIDs.Add(D.myReader["CAR_ID"].ToString()); }
                D.myReader.Close();

                // The following block shows an error message if CAR ID already exists
                if (CarIDs.Contains(CARID))
                {
                    MessageBox.Show("Unable to add. Car ID already exists in the system.", "Error");
                    return;
                }

                if (TYPE == "") { return; } // avoids reading car type if empty
                // The following block gets the CT_ID of the car
                string getTypeID = "select CT.[CT_ID]" +
                    " from CarType CT " +
                    " where CT.[Type] = " + "'" + TYPE + "'";
                D.query(getTypeID);
                D.myReader.Read();
                string TypeID = D.myReader["CT_ID"].ToString();
                D.myReader.Close();

                if (BRANCH == "") { return; } // avoids reading branch if empty
                // The following block gets the BID of the car
                string getBID = "select B.[BID]" +
                    " from Branch B" +
                    " where B.[Name] = " + "'" + BRANCH + "'";
                D.query(getBID);
                D.myReader.Read();
                string BID = D.myReader["BID"].ToString();
                D.myReader.Close();

                // The following block occurs when all error checks are passed
                string message = "Are you sure you want to add a new car to the inventory?";
                string title = "Add CAR ID: " + CARID;
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Yes) 
                {
                    // The following block adds the new car details to database 
                    string addQuery = "insert into Car " +
                        "values ('" + CARID + "', '" + PIN + "', '" + PLATENO + "','" + MODEL + "', " +
                        "'" + MAKE + "', '" + MILES + "', '" + YEAR + "', '" + BID + "', '" + TypeID + "') ";
                    D.insert(addQuery);

                    // Calls the two functions to update the information on the gridview automatically
                    this.TEST(sender, e);
                    this.TEST(sender, e);
                    this.ValueGrid_CellContentClick(sender, e);
                }
            }

        }

        private void update_button_Click(object sender, EventArgs e)
        {   
            string CARID   = CARID_textBox.Text; // Get CAR ID

            if (CARID != "") // Checks if user clicked on a car in table
            {
                // The following block checks to see if given CAR ID already exists in database
                List<string> CarIDs = new List<string>();
                D.query("select [CAR_ID] from Car");
                while (D.myReader.Read())
                { CarIDs.Add(D.myReader["CAR_ID"].ToString()); }
                D.myReader.Close();

                // The following block shows an error message if CAR ID already exists
                if (!CarIDs.Contains(CARID))
                {
                    MessageBox.Show("Unable to update. Car ID can not be found in the system. Please click on an existing car in the table.", "Error");
                    return;
                }

                // The following block takes all user inputs to update
                string PIN     = PIN_textBox.Text;
                if (PIN == "") { MessageBox.Show("Please fill out PIN.", "Missing field"); return; }
                string PLATENO = PLATENO_textBox.Text;
                if (PLATENO == "") { MessageBox.Show("Please fill out PLATE NO.", "Missing field"); return; }
                string TYPE    = TYPE_comboBox.Text;
                string MODEL   = MODEL_textBox.Text;
                string MAKE    = MAKE_textBox.Text;
                string MILES   = MILES_textBox.Text;
                string YEAR    = YEAR_textBox.Text;

                // The following block gets the CT_ID of the car
                string getTypeID = "select CT.[CT_ID]" +
                    " from CarType CT " +
                    " where CT.[Type] = " + "'" + TYPE + "'";
                D.query(getTypeID);
                D.myReader.Read();
                string TypeID = D.myReader["CT_ID"].ToString();
                D.myReader.Close();

                // The following block gets the BID of the car
                string getBID = "select B.[BID]" +
                    " from Car C, Branch B" +
                    " where C.BID = B.BID and C.[CAR_ID] = " + "'" + CARID + "'";
                D.query(getBID);
                D.myReader.Read();
                string BID = D.myReader["BID"].ToString();
                D.myReader.Close();

                // The following block displays a message box to allow updating a car's details
                string message = "Are you sure you want to change this car's details?";
                string title = "Update CAR ID: " + CARID;
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Yes)
                {
                    // The following block updates the car details in database 
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

                    // Calls the two functions to update the information on the gridview automatically
                    this.TEST(sender, e);
                    this.ValueGrid_CellContentClick(sender, e);
                }
            }
            // Shows an error message if user did not click on a car in the table
            else { MessageBox.Show("Please click on an existing car in the table"); }
        }

        private void delete_button_Click(object sender, EventArgs e)
        {
            string CARID = CARID_textBox.Text; // Get CAR ID

            if (CARID != "") // Checks if user clicked on a car in table
            {
                // The following block checks to see if given CAR ID already exists in database
                List<string> CarIDs = new List<string>();
                D.query("select [CAR_ID] from Car");
                while (D.myReader.Read())
                { CarIDs.Add(D.myReader["CAR_ID"].ToString()); }
                D.myReader.Close();

                // The following block shows an error message if CAR ID already exists
                if (!CarIDs.Contains(CARID))
                {
                    MessageBox.Show("Unable to delete. Car ID can not be found in the system.", "Error");
                    return;
                }

                // The following block displays a message box to allow deleting a car's details
                string message = "Are you sure you want to delete this car?";
                string title = "Delete CAR ID: " + CARID;
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Yes)
                {
                    // The following block deletes the selected car in database 
                    D.insert("delete from Car where CAR_ID = '" + CARID + "'");
                    this.TEST(sender, e);
                }
            }
            // Shows an error message if user did not click on a car in the table
            else { MessageBox.Show("Please click on an existing car in the table"); }
        }

        private void ValueGrid_CellContentClick(object sender, EventArgs e)
        {
            // The following block clears all user input textboxes if user clicks on a null value on the table
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
                CARID_textBox.ReadOnly = false; // Allows user to edit CAR ID textbox
            }
            else
            {
                // The following block shows the details on the textboxes if a car in table is selected
                CARID_textBox.Text   = ValueGrid.SelectedRows[0].Cells[0].Value.ToString().Trim();
                PIN_textBox.Text     = ValueGrid.SelectedRows[0].Cells[1].Value.ToString().Trim();
                TYPE_comboBox.Text   = ValueGrid.SelectedRows[0].Cells[2].Value.ToString().Trim();
                PLATENO_textBox.Text = ValueGrid.SelectedRows[0].Cells[3].Value.ToString().Trim();
                MODEL_textBox.Text   = ValueGrid.SelectedRows[0].Cells[4].Value.ToString().Trim();
                MAKE_textBox.Text    = ValueGrid.SelectedRows[0].Cells[5].Value.ToString().Trim();
                MILES_textBox.Text   = ValueGrid.SelectedRows[0].Cells[6].Value.ToString().Trim();
                YEAR_textBox.Text    = ValueGrid.SelectedRows[0].Cells[7].Value.ToString().Trim();
                CARID_textBox.ReadOnly = true; // Prevents user to edit CAR ID textbox
            }
        }
    }
}
