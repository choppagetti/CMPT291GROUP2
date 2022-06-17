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
    public partial class employeeMenuSkeleton : Form
    {
        //fields
        private Form activeForm;
        public Database D2;
        public Start start;
        public employeeMenuSkeleton()
        {
            InitializeComponent();
            D2 = new Database();
        }
        private void logo_Load(object sender, EventArgs e)
        {

        }

        private void sideBar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void open_Forms(Form children, object btnSender)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = children;
            children.TopLevel = false;
            children.FormBorderStyle = FormBorderStyle.None;
            children.Dock = DockStyle.Fill;
            this.formsPane.Controls.Add(children);
            this.formsPane.Tag = children;
            children.BringToFront();
            children.Show();
        }

        private void availability_Click(object sender, EventArgs e)
        {
            logoBox.BackColor = ColorTranslator.FromHtml("#601A3E");
            topBar.BackColor = ColorTranslator.FromHtml("#873260");
            availability.BackColor = ColorTranslator.FromHtml("#873260");
            inventory.BackColor = ColorTranslator.FromHtml("#192bc2");
            returns.BackColor = ColorTranslator.FromHtml("#192bc2");
            rentals.BackColor = ColorTranslator.FromHtml("#192bc2");
            reports.BackColor = ColorTranslator.FromHtml("#192bc2");
        }

        private void inventory_Click(object sender, EventArgs e)
        {
            logoBox.BackColor = ColorTranslator.FromHtml("#ff6700");
            topBar.BackColor = ColorTranslator.FromHtml("#F58025");
            inventory.BackColor = ColorTranslator.FromHtml("#F58025");
            availability.BackColor = ColorTranslator.FromHtml("#192bc2");
            returns.BackColor = ColorTranslator.FromHtml("#192bc2");
            rentals.BackColor = ColorTranslator.FromHtml("#192bc2");
            reports.BackColor = ColorTranslator.FromHtml("#192bc2");
        }

        private void returns_Click(object sender, EventArgs e)
        {
            logoBox.BackColor = ColorTranslator.FromHtml("#A30000");
            topBar.BackColor = ColorTranslator.FromHtml("#D10000");
            returns.BackColor = ColorTranslator.FromHtml("#D10000");
            availability.BackColor = ColorTranslator.FromHtml("#192bc2");
            inventory.BackColor = ColorTranslator.FromHtml("#192bc2");
            rentals.BackColor = ColorTranslator.FromHtml("#192bc2");
            reports.BackColor = ColorTranslator.FromHtml("#192bc2");
            open_Forms(new Forms.processReturns(), sender);
        }

        private void reports_Click(object sender, EventArgs e)
        {
            logoBox.BackColor = ColorTranslator.FromHtml("#FE019A");
            topBar.BackColor = ColorTranslator.FromHtml("#FD5DA8");
            reports.BackColor = ColorTranslator.FromHtml("#FD5DA8");
            availability.BackColor = ColorTranslator.FromHtml("#192bc2");
            returns.BackColor = ColorTranslator.FromHtml("#192bc2");
            rentals.BackColor = ColorTranslator.FromHtml("#192bc2");
            inventory.BackColor = ColorTranslator.FromHtml("#192bc2");
        }

        private void rentals_Click(object sender, EventArgs e)
        {
            logoBox.BackColor = ColorTranslator.FromHtml("#03ac13");
            topBar.BackColor = ColorTranslator.FromHtml("#32CD32");
            rentals.BackColor = ColorTranslator.FromHtml("#32CD32");
            availability.BackColor = ColorTranslator.FromHtml("#192bc2");
            returns.BackColor = ColorTranslator.FromHtml("#192bc2");
            inventory.BackColor = ColorTranslator.FromHtml("#192bc2");
            reports.BackColor = ColorTranslator.FromHtml("#192bc2");
            open_Forms(new Forms.processRental(), sender);
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
