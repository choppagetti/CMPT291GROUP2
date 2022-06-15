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
            D = new Database();

            this.StartPosition = FormStartPosition.CenterScreen;
            D.query("select [Name] from Branch");
            while (D.myReader.Read())
            { comboBox1.Items.Add(D.myReader["Name"].ToString()); }
            D.myReader.Close();

        }
        private void TEST(object sender, EventArgs e)
        {
            CARID_textBox.Clear();
            PIN_textBox.Clear();
            TYPE_textBox.Clear();
            PLATENO_textBox.Clear();
            MODEL_textBox.Clear();
            MAKE_textBox.Clear();
            MILES_textBox.Clear();
            YEAR_textBox.Clear();
            string BranchName = comboBox1.Text.Trim().ToString();
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
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void ValueGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show(ValueGrid.SelectedRows[0].Cells[1].Value.ToString());
        }

        private void add_button_Click(object sender, EventArgs e)
        {
            string CARID = CARID_textBox.Text;
            MessageBox.Show(CARID);
        }

        private void update_button_Click(object sender, EventArgs e)
        {
            MessageBox.Show("update");
        }

        private void delete_button_Click(object sender, EventArgs e)
        {
            string CARID = CARID_textBox.Text;
            if (CARID != "")
            {
                //MessageBox.Show("delete" + CARID);
                string message = "Are you sure you want to delete this car?";
                string title = "Delete CAR ID: " + CARID;
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Yes)
                {
                    D.insert("delete from Car where CAR_ID = '"+CARID+"'");
                    this.TEST(sender, e);
                }
                else
                {
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Please click on a car in the table");
            }
        }

        private void ValueGrid_CellContentClick(object sender, EventArgs e)
        {
            if (ValueGrid.SelectedRows[0].Cells[0].Value == null)
            {
                CARID_textBox.Clear();
                PIN_textBox.Clear();
                TYPE_textBox.Clear();
                PLATENO_textBox.Clear();
                MODEL_textBox.Clear();
                MAKE_textBox.Clear();
                MILES_textBox.Clear();
                YEAR_textBox.Clear();
            }
            else
            {
                CARID_textBox.Text   = ValueGrid.SelectedRows[0].Cells[0].Value.ToString();
                PIN_textBox.Text     = ValueGrid.SelectedRows[0].Cells[1].Value.ToString();
                TYPE_textBox.Text    = ValueGrid.SelectedRows[0].Cells[2].Value.ToString();
                PLATENO_textBox.Text = ValueGrid.SelectedRows[0].Cells[3].Value.ToString();
                MODEL_textBox.Text   = ValueGrid.SelectedRows[0].Cells[4].Value.ToString();
                MAKE_textBox.Text    = ValueGrid.SelectedRows[0].Cells[5].Value.ToString();
                MILES_textBox.Text   = ValueGrid.SelectedRows[0].Cells[6].Value.ToString();
                YEAR_textBox.Text    = ValueGrid.SelectedRows[0].Cells[7].Value.ToString();
            }
        }

        private void label9_Click_1(object sender, EventArgs e)
        {

        }
    }
}
