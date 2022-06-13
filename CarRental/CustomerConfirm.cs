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

//----------Code for the final screen in the customer side; shows their booking details in a small pop-up form----------
namespace CarRental
{
    public partial class CustomerConfirm : Form
    {
        public Database D4;
        CustomerBook customerBook;
        public CustomerConfirm(CustomerBook customerBook)
        {
            InitializeComponent();
            D4 = new Database();
            this.customerBook = customerBook;

            IDText.Text = this.customerBook.customerAvail.IdBox.Text.Trim();
            PickUpLocText.Text = this.customerBook.customerAvail.PickUpLoc.Text.Trim();

            if (this.customerBook.customerAvail.RetLoc.Text.Trim() == "")
            { ReturnLocText.Text = PickUpLocText.Text; }
            else
            { ReturnLocText.Text = this.customerBook.customerAvail.RetLoc.Text.Trim(); }

            PickUpDateText.Text = this.customerBook.customerAvail.pickupDate.Text.Trim();
            ReturnDateText.Text = this.customerBook.customerAvail.returnDate.Text.Trim();

            int row = this.customerBook.ValueGrid.CurrentCell.RowIndex;
            int col = this.customerBook.ValueGrid.CurrentCell.ColumnIndex;
            CarNameText.Text = (string)(this.customerBook.ValueGrid.Rows[row].Cells[2].Value.ToString().Trim() + " " + this.customerBook.ValueGrid.Rows[row].Cells[3].Value.ToString().Trim());
            CarTypeText.Text = (string)(this.customerBook.ValueGrid.Rows[row].Cells[1].Value.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
