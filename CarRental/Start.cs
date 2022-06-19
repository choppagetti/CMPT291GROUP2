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
    //----------This is the Start screen for the car rental system where the customer or employee will----------
    //----------be directed to the proper page for their needs                                        ----------
    public partial class Start : Form
    {
        public Database D1;
        public Start()
        {
            InitializeComponent();
            D1 = new Database();
        }

        //------Event for when the Customer button is clicked------
        private void CustLogin_Click(object sender, EventArgs e)
        {
            // Hides this form and calls the first Customer form
            this.Hide();
            CustomerAvail CustForm = new(this);
            CustForm.ShowDialog();

            // Shows this form again once the Customer form is closed
            this.Show();
        }

        //------Event for when the Customer button is clicked------
        private void EmpLogin_Click(object sender, EventArgs e)
        {
            // Hides this form and calls the Employee form
            this.Hide();
            employeeMenuSkeleton empForm = new();
            empForm.ShowDialog();

            // Shows this form again once the Employee form is closed
            this.Show();
        }
    }
}