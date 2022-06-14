namespace CarRental
{
    partial class employeeMenuSkeleton
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.sideBar = new System.Windows.Forms.Panel();
            this.reports = new System.Windows.Forms.Button();
            this.returns = new System.Windows.Forms.Button();
            this.rentals = new System.Windows.Forms.Button();
            this.inventory = new System.Windows.Forms.Button();
            this.availability = new System.Windows.Forms.Button();
            this.logoBox = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.topBar = new System.Windows.Forms.Panel();
            this.empName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.formsPane = new System.Windows.Forms.Panel();
            this.sideBar.SuspendLayout();
            this.logoBox.SuspendLayout();
            this.topBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // sideBar
            // 
            this.sideBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(43)))), ((int)(((byte)(194)))));
            this.sideBar.Controls.Add(this.reports);
            this.sideBar.Controls.Add(this.returns);
            this.sideBar.Controls.Add(this.rentals);
            this.sideBar.Controls.Add(this.inventory);
            this.sideBar.Controls.Add(this.availability);
            this.sideBar.Controls.Add(this.logoBox);
            this.sideBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.sideBar.Location = new System.Drawing.Point(0, 0);
            this.sideBar.Name = "sideBar";
            this.sideBar.Size = new System.Drawing.Size(230, 976);
            this.sideBar.TabIndex = 0;
            this.sideBar.Paint += new System.Windows.Forms.PaintEventHandler(this.sideBar_Paint);
            // 
            // reports
            // 
            this.reports.Dock = System.Windows.Forms.DockStyle.Top;
            this.reports.FlatAppearance.BorderSize = 0;
            this.reports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.reports.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.reports.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.reports.Location = new System.Drawing.Point(0, 500);
            this.reports.Name = "reports";
            this.reports.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.reports.Size = new System.Drawing.Size(230, 95);
            this.reports.TabIndex = 5;
            this.reports.Text = "Reports";
            this.reports.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.reports.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.reports.UseVisualStyleBackColor = true;
            this.reports.Click += new System.EventHandler(this.reports_Click);
            // 
            // returns
            // 
            this.returns.Dock = System.Windows.Forms.DockStyle.Top;
            this.returns.FlatAppearance.BorderSize = 0;
            this.returns.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.returns.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.returns.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.returns.Location = new System.Drawing.Point(0, 405);
            this.returns.Name = "returns";
            this.returns.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.returns.Size = new System.Drawing.Size(230, 95);
            this.returns.TabIndex = 4;
            this.returns.Text = "Process Returns";
            this.returns.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.returns.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.returns.UseVisualStyleBackColor = true;
            this.returns.Click += new System.EventHandler(this.returns_Click);
            // 
            // rentals
            // 
            this.rentals.Dock = System.Windows.Forms.DockStyle.Top;
            this.rentals.FlatAppearance.BorderSize = 0;
            this.rentals.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rentals.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.rentals.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.rentals.Location = new System.Drawing.Point(0, 310);
            this.rentals.Name = "rentals";
            this.rentals.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.rentals.Size = new System.Drawing.Size(230, 95);
            this.rentals.TabIndex = 3;
            this.rentals.Text = "Process Rentals";
            this.rentals.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rentals.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.rentals.UseVisualStyleBackColor = true;
            this.rentals.Click += new System.EventHandler(this.rentals_Click);
            // 
            // inventory
            // 
            this.inventory.Dock = System.Windows.Forms.DockStyle.Top;
            this.inventory.FlatAppearance.BorderSize = 0;
            this.inventory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.inventory.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.inventory.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.inventory.Location = new System.Drawing.Point(0, 215);
            this.inventory.Name = "inventory";
            this.inventory.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.inventory.Size = new System.Drawing.Size(230, 95);
            this.inventory.TabIndex = 2;
            this.inventory.Text = "Inventory Management";
            this.inventory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.inventory.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.inventory.UseVisualStyleBackColor = true;
            this.inventory.Click += new System.EventHandler(this.inventory_Click);
            // 
            // availability
            // 
            this.availability.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(43)))), ((int)(((byte)(194)))));
            this.availability.Dock = System.Windows.Forms.DockStyle.Top;
            this.availability.FlatAppearance.BorderSize = 0;
            this.availability.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.availability.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.availability.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.availability.Location = new System.Drawing.Point(0, 120);
            this.availability.Name = "availability";
            this.availability.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.availability.Size = new System.Drawing.Size(230, 95);
            this.availability.TabIndex = 1;
            this.availability.Text = "Availability and Cost";
            this.availability.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.availability.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.availability.UseVisualStyleBackColor = false;
            this.availability.Click += new System.EventHandler(this.availability_Click);
            // 
            // logoBox
            // 
            this.logoBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(52)))), ((int)(((byte)(166)))));
            this.logoBox.Controls.Add(this.button1);
            this.logoBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.logoBox.Location = new System.Drawing.Point(0, 0);
            this.logoBox.Name = "logoBox";
            this.logoBox.Size = new System.Drawing.Size(230, 120);
            this.logoBox.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = global::CarRental.Properties.Resources.carLogo;
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(193, 97);
            this.button1.TabIndex = 2;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // topBar
            // 
            this.topBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(43)))), ((int)(((byte)(194)))));
            this.topBar.Controls.Add(this.empName);
            this.topBar.Controls.Add(this.label1);
            this.topBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.topBar.Location = new System.Drawing.Point(230, 0);
            this.topBar.Name = "topBar";
            this.topBar.Size = new System.Drawing.Size(1702, 120);
            this.topBar.TabIndex = 1;
            // 
            // empName
            // 
            this.empName.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.empName.AutoSize = true;
            this.empName.Font = new System.Drawing.Font("Vivaldi", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.empName.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.empName.Location = new System.Drawing.Point(1537, 80);
            this.empName.Name = "empName";
            this.empName.Size = new System.Drawing.Size(140, 22);
            this.empName.TabIndex = 0;
            this.empName.Text = "Employee Name";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label1.Location = new System.Drawing.Point(689, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(464, 77);
            this.label1.TabIndex = 0;
            this.label1.Text = "Branch Name";
            // 
            // formsPane
            // 
            this.formsPane.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formsPane.Location = new System.Drawing.Point(230, 120);
            this.formsPane.Name = "formsPane";
            this.formsPane.Size = new System.Drawing.Size(1702, 856);
            this.formsPane.TabIndex = 2;
            // 
            // employeeMenuSkeleton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1932, 976);
            this.Controls.Add(this.formsPane);
            this.Controls.Add(this.topBar);
            this.Controls.Add(this.sideBar);
            this.Name = "employeeMenuSkeleton";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.logo_Load);
            this.sideBar.ResumeLayout(false);
            this.logoBox.ResumeLayout(false);
            this.topBar.ResumeLayout(false);
            this.topBar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel sideBar;
        private Panel logoBox;
        private Button reports;
        private Button returns;
        private Button rentals;
        private Button inventory;
        private Button availability;
        private Panel topBar;
        private Label empName;
        private Label label1;
        private Button button1;
        private Panel formsPane;
    }
}