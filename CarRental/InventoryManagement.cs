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
/*
            // Get the chosen branch name in combo box
            string BranchName = comboBox1.Text.Trim().ToString();

            // Show data of cars in that branch
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
*/
        }
        private void TEST(object sender, EventArgs e)
        {
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
            MessageBox.Show("add");
        }

        private void update_button_Click(object sender, EventArgs e)
        {
            MessageBox.Show("update");
        }

        private void delete_button_Click(object sender, EventArgs e)
        {
            MessageBox.Show("delete");
        }

        private void ValueGrid_CellContentClick(object sender, EventArgs e)
        {
            if (ValueGrid.SelectedRows[0].Cells[0].Value == null)
            {
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                textBox7.Clear();
                textBox8.Clear();
            }
            else
            {
                textBox1.Text = ValueGrid.SelectedRows[0].Cells[0].Value.ToString();
                textBox2.Text = ValueGrid.SelectedRows[0].Cells[1].Value.ToString();
                textBox3.Text = ValueGrid.SelectedRows[0].Cells[2].Value.ToString();
                textBox4.Text = ValueGrid.SelectedRows[0].Cells[3].Value.ToString();
                textBox5.Text = ValueGrid.SelectedRows[0].Cells[4].Value.ToString();
                textBox6.Text = ValueGrid.SelectedRows[0].Cells[5].Value.ToString();
                textBox7.Text = ValueGrid.SelectedRows[0].Cells[6].Value.ToString();
                textBox8.Text = ValueGrid.SelectedRows[0].Cells[7].Value.ToString();
            }


        }

        private void label9_Click_1(object sender, EventArgs e)
        {

        }
    }
}
