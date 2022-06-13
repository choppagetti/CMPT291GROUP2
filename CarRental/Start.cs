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
    public partial class Start : Form
    {
        public Database D1;
        public Start()
        {
            InitializeComponent();
            D1 = new Database();
        }

        private void CustLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            CustomerAvail CustForm = new(this);
            CustForm.ShowDialog();
            this.Show();
        }
    }
}