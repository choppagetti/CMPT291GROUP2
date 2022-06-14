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
    public partial class Reports : Form
    {
        public Database D2;
        public Reports()
        {
            InitializeComponent();
            D2 = new Database();
        }

        private void EmpRepButt_Click(object sender, EventArgs e)
        {
            if (EmpFilterBox.Text == "Most Sold (Units)")
            {
                D2.query("select EFName");
                while (D2.myReader.Read())
                {
                    EmpRepTable.Rows.Add(D2.myReader["EFName"].ToString(), ELName)
                }
                D2.myReader.Close();
            }

        }

        private void CustRepButt_Click(object sender, EventArgs e)
        {

        }

        private void BranchRepButt_Click(object sender, EventArgs e)
        {

        }

        private void CustomRepButt_Click(object sender, EventArgs e)
        {
            //CustomRepTable.Columns.Clear();
            //CustomRepTable.Columns.Add("BID", "Filip");
            //CustomRepTable.Columns.Add("Name", "Report");
            //CustomRepTable.Columns.Add("Email", "291");
        }
    }
}
