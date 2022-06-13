namespace CarRental
{
    partial class CustomerAvail
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Home = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cust_id = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.PickUpLoc = new System.Windows.Forms.ComboBox();
            this.RetLoc = new System.Windows.Forms.ComboBox();
            this.CheckAvail = new System.Windows.Forms.Button();
            this.returnDate = new System.Windows.Forms.DateTimePicker();
            this.pickupDate = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.CarType = new System.Windows.Forms.ComboBox();
            this.return_loc = new System.Windows.Forms.Label();
            this.pickup_loc = new System.Windows.Forms.Label();
            this.retLocReq = new System.Windows.Forms.Label();
            this.checkBox = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.IdBox = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Home
            // 
            this.Home.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Home.Location = new System.Drawing.Point(12, 6);
            this.Home.Name = "Home";
            this.Home.Size = new System.Drawing.Size(103, 35);
            this.Home.TabIndex = 0;
            this.Home.Text = "HOME";
            this.Home.UseVisualStyleBackColor = true;
            this.Home.Click += new System.EventHandler(this.Home_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.cust_id);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.PickUpLoc);
            this.panel1.Controls.Add(this.RetLoc);
            this.panel1.Controls.Add(this.CheckAvail);
            this.panel1.Controls.Add(this.returnDate);
            this.panel1.Controls.Add(this.pickupDate);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.CarType);
            this.panel1.Controls.Add(this.return_loc);
            this.panel1.Controls.Add(this.pickup_loc);
            this.panel1.Controls.Add(this.retLocReq);
            this.panel1.Controls.Add(this.checkBox);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.IdBox);
            this.panel1.Location = new System.Drawing.Point(12, 47);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(925, 472);
            this.panel1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(50, 311);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 31);
            this.label2.TabIndex = 9;
            this.label2.Text = "Car Type:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label11.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label11.Location = new System.Drawing.Point(36, 311);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(24, 31);
            this.label11.TabIndex = 23;
            this.label11.Text = "*";
            // 
            // cust_id
            // 
            this.cust_id.AutoSize = true;
            this.cust_id.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cust_id.Location = new System.Drawing.Point(50, 13);
            this.cust_id.Name = "cust_id";
            this.cust_id.Size = new System.Drawing.Size(145, 31);
            this.cust_id.TabIndex = 0;
            this.cust_id.Text = "Customer ID:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label10.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label10.Location = new System.Drawing.Point(36, 13);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(24, 31);
            this.label10.TabIndex = 22;
            this.label10.Text = "*";
            // 
            // PickUpLoc
            // 
            this.PickUpLoc.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.PickUpLoc.FormattingEnabled = true;
            this.PickUpLoc.Location = new System.Drawing.Point(36, 112);
            this.PickUpLoc.Name = "PickUpLoc";
            this.PickUpLoc.Size = new System.Drawing.Size(322, 39);
            this.PickUpLoc.TabIndex = 21;
            // 
            // RetLoc
            // 
            this.RetLoc.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.RetLoc.FormattingEnabled = true;
            this.RetLoc.Location = new System.Drawing.Point(36, 238);
            this.RetLoc.Name = "RetLoc";
            this.RetLoc.Size = new System.Drawing.Size(322, 39);
            this.RetLoc.TabIndex = 20;
            // 
            // CheckAvail
            // 
            this.CheckAvail.BackColor = System.Drawing.SystemColors.ControlLight;
            this.CheckAvail.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.CheckAvail.Location = new System.Drawing.Point(638, 399);
            this.CheckAvail.Name = "CheckAvail";
            this.CheckAvail.Size = new System.Drawing.Size(239, 53);
            this.CheckAvail.TabIndex = 19;
            this.CheckAvail.Text = "Check Availability";
            this.CheckAvail.UseVisualStyleBackColor = false;
            this.CheckAvail.Click += new System.EventHandler(this.CheckAvail_Click);
            // 
            // returnDate
            // 
            this.returnDate.CalendarFont = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.returnDate.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.returnDate.Location = new System.Drawing.Point(500, 239);
            this.returnDate.Name = "returnDate";
            this.returnDate.Size = new System.Drawing.Size(377, 38);
            this.returnDate.TabIndex = 18;
            // 
            // pickupDate
            // 
            this.pickupDate.CalendarFont = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.pickupDate.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.pickupDate.Location = new System.Drawing.Point(501, 113);
            this.pickupDate.Name = "pickupDate";
            this.pickupDate.Size = new System.Drawing.Size(377, 38);
            this.pickupDate.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(514, 205);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(140, 31);
            this.label8.TabIndex = 15;
            this.label8.Text = "Return Date:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label9.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label9.Location = new System.Drawing.Point(500, 205);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(24, 31);
            this.label9.TabIndex = 16;
            this.label9.Text = "*";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(514, 79);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(150, 31);
            this.label6.TabIndex = 13;
            this.label6.Text = "Pick-up Date:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label7.Location = new System.Drawing.Point(500, 79);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(24, 31);
            this.label7.TabIndex = 14;
            this.label7.Text = "*";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(707, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(171, 31);
            this.label4.TabIndex = 11;
            this.label4.Text = "Required Fields";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label5.Location = new System.Drawing.Point(690, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 31);
            this.label5.TabIndex = 12;
            this.label5.Text = "*";
            // 
            // CarType
            // 
            this.CarType.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CarType.FormattingEnabled = true;
            this.CarType.Location = new System.Drawing.Point(35, 345);
            this.CarType.Name = "CarType";
            this.CarType.Size = new System.Drawing.Size(843, 39);
            this.CarType.TabIndex = 10;
            // 
            // return_loc
            // 
            this.return_loc.AutoSize = true;
            this.return_loc.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.return_loc.Location = new System.Drawing.Point(50, 205);
            this.return_loc.Name = "return_loc";
            this.return_loc.Size = new System.Drawing.Size(179, 31);
            this.return_loc.TabIndex = 6;
            this.return_loc.Text = "Return Location:";
            // 
            // pickup_loc
            // 
            this.pickup_loc.AutoSize = true;
            this.pickup_loc.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.pickup_loc.Location = new System.Drawing.Point(50, 79);
            this.pickup_loc.Name = "pickup_loc";
            this.pickup_loc.Size = new System.Drawing.Size(189, 31);
            this.pickup_loc.TabIndex = 2;
            this.pickup_loc.Text = "Pick-up Location:";
            // 
            // retLocReq
            // 
            this.retLocReq.AutoSize = true;
            this.retLocReq.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.retLocReq.ForeColor = System.Drawing.SystemColors.Desktop;
            this.retLocReq.Location = new System.Drawing.Point(36, 205);
            this.retLocReq.Name = "retLocReq";
            this.retLocReq.Size = new System.Drawing.Size(24, 31);
            this.retLocReq.TabIndex = 7;
            this.retLocReq.Text = "*";
            // 
            // checkBox
            // 
            this.checkBox.AutoSize = true;
            this.checkBox.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBox.Location = new System.Drawing.Point(35, 157);
            this.checkBox.Name = "checkBox";
            this.checkBox.Size = new System.Drawing.Size(328, 35);
            this.checkBox.TabIndex = 5;
            this.checkBox.Text = "Return at a different location";
            this.checkBox.UseVisualStyleBackColor = true;
            this.checkBox.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged_1);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label3.Location = new System.Drawing.Point(36, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 31);
            this.label3.TabIndex = 3;
            this.label3.Text = "*";
            // 
            // IdBox
            // 
            this.IdBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.IdBox.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.IdBox.Location = new System.Drawing.Point(212, 13);
            this.IdBox.Name = "IdBox";
            this.IdBox.Size = new System.Drawing.Size(146, 38);
            this.IdBox.TabIndex = 1;
            // 
            // CustomerAvail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(949, 531);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Home);
            this.Name = "CustomerAvail";
            this.Text = "Customer Booking";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Button Home;
        private Panel panel1;
        private Label return_loc;
        private Label pickup_loc;
        private Label retLocReq;
        private Label label3;
        private Label cust_id;
        private Label label2;
        private Label label4;
        private Label label5;
        private Button CheckAvail;
        private Label label8;
        private Label label9;
        private Label label6;
        private Label label7;
        private Label label11;
        private Label label10;
        public ComboBox CarType;
        public DateTimePicker returnDate;
        public DateTimePicker pickupDate;
        public ComboBox PickUpLoc;
        public ComboBox RetLoc;
        public CheckBox checkBox;
        public TextBox IdBox;
    }
}