namespace CarRental.Forms
{
    partial class processRental
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.authorizeTransac = new System.Windows.Forms.Button();
            this.custID = new System.Windows.Forms.TextBox();
            this.inventory = new System.Windows.Forms.DataGridView();
            this.memberShip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.carID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.carType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.makeC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.carModel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BranchID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costTot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pickupBranch = new System.Windows.Forms.ComboBox();
            this.returnBranch = new System.Windows.Forms.ComboBox();
            this.upgradeTransac = new System.Windows.Forms.Button();
            this.pickupDate = new System.Windows.Forms.DateTimePicker();
            this.returnDate = new System.Windows.Forms.DateTimePicker();
            this.availability = new System.Windows.Forms.Button();
            this.carTypes = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.inventory)).BeginInit();
            this.SuspendLayout();
            // 
            // authorizeTransac
            // 
            this.authorizeTransac.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.authorizeTransac.BackColor = System.Drawing.Color.Chartreuse;
            this.authorizeTransac.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(172)))), ((int)(((byte)(19)))));
            this.authorizeTransac.FlatAppearance.BorderSize = 6;
            this.authorizeTransac.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.authorizeTransac.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.authorizeTransac.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.authorizeTransac.Location = new System.Drawing.Point(334, 744);
            this.authorizeTransac.Name = "authorizeTransac";
            this.authorizeTransac.Size = new System.Drawing.Size(300, 40);
            this.authorizeTransac.TabIndex = 22;
            this.authorizeTransac.Text = "AUTHORIZE";
            this.authorizeTransac.UseVisualStyleBackColor = false;
            this.authorizeTransac.Click += new System.EventHandler(this.authorizeTransac_Click);
            // 
            // custID
            // 
            this.custID.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.custID.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.custID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(172)))), ((int)(((byte)(19)))));
            this.custID.Location = new System.Drawing.Point(440, 28);
            this.custID.Name = "custID";
            this.custID.PlaceholderText = "ENTER CUSTOMER ID";
            this.custID.Size = new System.Drawing.Size(600, 23);
            this.custID.TabIndex = 24;
            this.custID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // inventory
            // 
            this.inventory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.inventory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.memberShip,
            this.carID,
            this.carType,
            this.makeC,
            this.carModel,
            this.BranchID,
            this.costTot});
            this.inventory.Location = new System.Drawing.Point(195, 68);
            this.inventory.Name = "inventory";
            this.inventory.RowTemplate.Height = 25;
            this.inventory.Size = new System.Drawing.Size(1073, 658);
            this.inventory.TabIndex = 25;
            this.inventory.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.inventory_CellContentClick);
            // 
            // memberShip
            // 
            this.memberShip.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.memberShip.DefaultCellStyle = dataGridViewCellStyle1;
            this.memberShip.HeaderText = "MEMBER STATUS";
            this.memberShip.Name = "memberShip";
            // 
            // carID
            // 
            this.carID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.carID.DefaultCellStyle = dataGridViewCellStyle2;
            this.carID.HeaderText = "CAR ID";
            this.carID.Name = "carID";
            // 
            // carType
            // 
            this.carType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.carType.DefaultCellStyle = dataGridViewCellStyle3;
            this.carType.HeaderText = "CAR TYPE";
            this.carType.Name = "carType";
            // 
            // makeC
            // 
            this.makeC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.makeC.DefaultCellStyle = dataGridViewCellStyle4;
            this.makeC.HeaderText = "MAKE";
            this.makeC.Name = "makeC";
            // 
            // carModel
            // 
            this.carModel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.carModel.DefaultCellStyle = dataGridViewCellStyle5;
            this.carModel.HeaderText = "MODEL";
            this.carModel.Name = "carModel";
            // 
            // BranchID
            // 
            this.BranchID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.BranchID.DefaultCellStyle = dataGridViewCellStyle6;
            this.BranchID.HeaderText = "BRANCH";
            this.BranchID.Name = "BranchID";
            // 
            // costTot
            // 
            this.costTot.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.costTot.DefaultCellStyle = dataGridViewCellStyle7;
            this.costTot.HeaderText = "TOTAL COST";
            this.costTot.Name = "costTot";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.LimeGreen;
            this.label1.Location = new System.Drawing.Point(39, 194);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 21);
            this.label1.TabIndex = 26;
            this.label1.Text = "PICKUP DATE";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.LimeGreen;
            this.label2.Location = new System.Drawing.Point(33, 287);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 21);
            this.label2.TabIndex = 28;
            this.label2.Text = "RETURN DATE";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.LimeGreen;
            this.label3.Location = new System.Drawing.Point(29, 384);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 21);
            this.label3.TabIndex = 30;
            this.label3.Text = "PICKUP BRANCH";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.LimeGreen;
            this.label4.Location = new System.Drawing.Point(22, 481);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(139, 21);
            this.label4.TabIndex = 32;
            this.label4.Text = "RETURN BRANCH";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.Color.LimeGreen;
            this.label5.Location = new System.Drawing.Point(51, 118);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 21);
            this.label5.TabIndex = 34;
            this.label5.Text = "CAR TYPE";
            // 
            // pickupBranch
            // 
            this.pickupBranch.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pickupBranch.FormattingEnabled = true;
            this.pickupBranch.Location = new System.Drawing.Point(22, 408);
            this.pickupBranch.Name = "pickupBranch";
            this.pickupBranch.Size = new System.Drawing.Size(140, 23);
            this.pickupBranch.TabIndex = 36;
            // 
            // returnBranch
            // 
            this.returnBranch.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.returnBranch.FormattingEnabled = true;
            this.returnBranch.Location = new System.Drawing.Point(22, 505);
            this.returnBranch.Name = "returnBranch";
            this.returnBranch.Size = new System.Drawing.Size(140, 23);
            this.returnBranch.TabIndex = 37;
            // 
            // upgradeTransac
            // 
            this.upgradeTransac.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.upgradeTransac.BackColor = System.Drawing.Color.Chartreuse;
            this.upgradeTransac.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(172)))), ((int)(((byte)(19)))));
            this.upgradeTransac.FlatAppearance.BorderSize = 6;
            this.upgradeTransac.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.upgradeTransac.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.upgradeTransac.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.upgradeTransac.Location = new System.Drawing.Point(831, 744);
            this.upgradeTransac.Name = "upgradeTransac";
            this.upgradeTransac.Size = new System.Drawing.Size(300, 40);
            this.upgradeTransac.TabIndex = 38;
            this.upgradeTransac.Text = "UPGRADE";
            this.upgradeTransac.UseVisualStyleBackColor = false;
            this.upgradeTransac.Click += new System.EventHandler(this.upgradeTransac_Click);
            // 
            // pickupDate
            // 
            this.pickupDate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pickupDate.Location = new System.Drawing.Point(22, 218);
            this.pickupDate.Name = "pickupDate";
            this.pickupDate.Size = new System.Drawing.Size(140, 23);
            this.pickupDate.TabIndex = 39;
            this.pickupDate.Value = new System.DateTime(2022, 6, 18, 17, 44, 37, 0);
            // 
            // returnDate
            // 
            this.returnDate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.returnDate.Location = new System.Drawing.Point(22, 311);
            this.returnDate.Name = "returnDate";
            this.returnDate.Size = new System.Drawing.Size(140, 23);
            this.returnDate.TabIndex = 40;
            // 
            // availability
            // 
            this.availability.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.availability.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(172)))), ((int)(((byte)(19)))));
            this.availability.FlatAppearance.BorderColor = System.Drawing.Color.Chartreuse;
            this.availability.FlatAppearance.BorderSize = 6;
            this.availability.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.availability.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.availability.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.availability.Location = new System.Drawing.Point(22, 606);
            this.availability.Name = "availability";
            this.availability.Size = new System.Drawing.Size(140, 40);
            this.availability.TabIndex = 41;
            this.availability.Text = "RUN CHECK";
            this.availability.UseVisualStyleBackColor = false;
            this.availability.Click += new System.EventHandler(this.availability_Click);
            // 
            // carTypes
            // 
            this.carTypes.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.carTypes.FormattingEnabled = true;
            this.carTypes.Location = new System.Drawing.Point(22, 142);
            this.carTypes.Name = "carTypes";
            this.carTypes.Size = new System.Drawing.Size(140, 23);
            this.carTypes.TabIndex = 42;
            // 
            // processRental
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LemonChiffon;
            this.ClientSize = new System.Drawing.Size(1306, 821);
            this.Controls.Add(this.carTypes);
            this.Controls.Add(this.availability);
            this.Controls.Add(this.returnDate);
            this.Controls.Add(this.pickupDate);
            this.Controls.Add(this.upgradeTransac);
            this.Controls.Add(this.returnBranch);
            this.Controls.Add(this.pickupBranch);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.inventory);
            this.Controls.Add(this.custID);
            this.Controls.Add(this.authorizeTransac);
            this.Name = "processRental";
            this.Text = "processRental";
            this.Load += new System.EventHandler(this.processRental_Load);
            ((System.ComponentModel.ISupportInitialize)(this.inventory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Button authorizeTransac;
        private TextBox custID;
        private DataGridView inventory;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private ComboBox pickupBranch;
        private ComboBox returnBranch;
        private Button upgradeTransac;
        private DateTimePicker pickupDate;
        private DateTimePicker returnDate;
        private Button availability;
        private ComboBox carTypes;
        private DataGridViewTextBoxColumn memberShip;
        private DataGridViewTextBoxColumn carID;
        private DataGridViewTextBoxColumn carType;
        private DataGridViewTextBoxColumn makeC;
        private DataGridViewTextBoxColumn carModel;
        private DataGridViewTextBoxColumn BranchID;
        private DataGridViewTextBoxColumn costTot;
    }
}