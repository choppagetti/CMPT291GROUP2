namespace CarRental.Forms
{
    partial class processReturns
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.transactions = new System.Windows.Forms.DataGridView();
            this.transID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pickupDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.originalReturnDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customerID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.carsID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.carTypeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.carMake = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.carModel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.custID = new System.Windows.Forms.TextBox();
            this.normalRet = new System.Windows.Forms.Button();
            this.availability = new System.Windows.Forms.Button();
            this.returnDate = new System.Windows.Forms.DateTimePicker();
            this.lateRet = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.transactions)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(29, 299);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label1.Size = new System.Drawing.Size(136, 21);
            this.label1.TabIndex = 44;
            this.label1.Text = "RETURNED DATE";
            // 
            // transactions
            // 
            this.transactions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.transactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.transactions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.transID,
            this.pickupDate,
            this.originalReturnDate,
            this.customerID,
            this.carsID,
            this.carTypeID,
            this.carMake,
            this.carModel});
            this.transactions.Location = new System.Drawing.Point(201, 150);
            this.transactions.Name = "transactions";
            this.transactions.RowTemplate.Height = 25;
            this.transactions.Size = new System.Drawing.Size(1073, 471);
            this.transactions.TabIndex = 43;
            this.transactions.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.transactions_CellContentClick);
            // 
            // transID
            // 
            this.transID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.transID.DefaultCellStyle = dataGridViewCellStyle1;
            this.transID.HeaderText = "TRANSACTION ID";
            this.transID.Name = "transID";
            // 
            // pickupDate
            // 
            this.pickupDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.pickupDate.DefaultCellStyle = dataGridViewCellStyle2;
            this.pickupDate.HeaderText = "PICKED UP DATE";
            this.pickupDate.Name = "pickupDate";
            // 
            // originalReturnDate
            // 
            this.originalReturnDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.originalReturnDate.DefaultCellStyle = dataGridViewCellStyle3;
            this.originalReturnDate.HeaderText = "ORIGINAL RETURN DATE";
            this.originalReturnDate.Name = "originalReturnDate";
            // 
            // customerID
            // 
            this.customerID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.customerID.DefaultCellStyle = dataGridViewCellStyle4;
            this.customerID.HeaderText = "CUSTOMER ID";
            this.customerID.Name = "customerID";
            // 
            // carsID
            // 
            this.carsID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.carsID.DefaultCellStyle = dataGridViewCellStyle5;
            this.carsID.HeaderText = "CAR ID";
            this.carsID.Name = "carsID";
            // 
            // carTypeID
            // 
            this.carTypeID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.carTypeID.DefaultCellStyle = dataGridViewCellStyle6;
            this.carTypeID.HeaderText = "CAR TYPE ID";
            this.carTypeID.Name = "carTypeID";
            // 
            // carMake
            // 
            this.carMake.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.carMake.DefaultCellStyle = dataGridViewCellStyle7;
            this.carMake.HeaderText = "MAKE";
            this.carMake.Name = "carMake";
            // 
            // carModel
            // 
            this.carModel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.carModel.DefaultCellStyle = dataGridViewCellStyle8;
            this.carModel.HeaderText = "MODEL";
            this.carModel.Name = "carModel";
            // 
            // custID
            // 
            this.custID.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.custID.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.custID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(172)))), ((int)(((byte)(19)))));
            this.custID.Location = new System.Drawing.Point(487, 74);
            this.custID.Name = "custID";
            this.custID.PlaceholderText = "ENTER CUSTOMER ID";
            this.custID.Size = new System.Drawing.Size(440, 23);
            this.custID.TabIndex = 42;
            this.custID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // normalRet
            // 
            this.normalRet.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.normalRet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.normalRet.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.normalRet.FlatAppearance.BorderSize = 6;
            this.normalRet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.normalRet.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.normalRet.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.normalRet.Location = new System.Drawing.Point(374, 699);
            this.normalRet.Name = "normalRet";
            this.normalRet.Size = new System.Drawing.Size(300, 40);
            this.normalRet.TabIndex = 41;
            this.normalRet.Text = "AUTHORIZE RETURN";
            this.normalRet.UseVisualStyleBackColor = false;
            this.normalRet.Click += new System.EventHandler(this.normalRet_Click);
            // 
            // availability
            // 
            this.availability.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.availability.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.availability.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.availability.FlatAppearance.BorderSize = 6;
            this.availability.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.availability.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.availability.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.availability.Location = new System.Drawing.Point(29, 419);
            this.availability.Name = "availability";
            this.availability.Size = new System.Drawing.Size(140, 40);
            this.availability.TabIndex = 63;
            this.availability.Text = "RUN CHECK";
            this.availability.UseVisualStyleBackColor = false;
            this.availability.Click += new System.EventHandler(this.availability_Click);
            // 
            // returnDate
            // 
            this.returnDate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.returnDate.Location = new System.Drawing.Point(29, 323);
            this.returnDate.Name = "returnDate";
            this.returnDate.Size = new System.Drawing.Size(140, 23);
            this.returnDate.TabIndex = 64;
            this.returnDate.ValueChanged += new System.EventHandler(this.returnDate_ValueChanged);
            // 
            // lateRet
            // 
            this.lateRet.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lateRet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lateRet.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lateRet.FlatAppearance.BorderSize = 6;
            this.lateRet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lateRet.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lateRet.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.lateRet.Location = new System.Drawing.Point(764, 699);
            this.lateRet.Name = "lateRet";
            this.lateRet.Size = new System.Drawing.Size(300, 40);
            this.lateRet.TabIndex = 65;
            this.lateRet.Text = "LATE RETURN";
            this.lateRet.UseVisualStyleBackColor = false;
            this.lateRet.Click += new System.EventHandler(this.lateRet_Click);
            // 
            // processReturns
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LemonChiffon;
            this.ClientSize = new System.Drawing.Size(1306, 821);
            this.Controls.Add(this.lateRet);
            this.Controls.Add(this.returnDate);
            this.Controls.Add(this.availability);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.transactions);
            this.Controls.Add(this.custID);
            this.Controls.Add(this.normalRet);
            this.Name = "processReturns";
            this.Text = "processReturns";
            this.Load += new System.EventHandler(this.processReturns_Load);
            ((System.ComponentModel.ISupportInitialize)(this.transactions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label label1;
        private DataGridView transactions;
        private TextBox custID;
        private Button normalRet;
        private Button availability;
        private DateTimePicker returnDate;
        private Button lateRet;
        private DataGridViewTextBoxColumn transID;
        private DataGridViewTextBoxColumn pickupDate;
        private DataGridViewTextBoxColumn originalReturnDate;
        private DataGridViewTextBoxColumn customerID;
        private DataGridViewTextBoxColumn carsID;
        private DataGridViewTextBoxColumn carTypeID;
        private DataGridViewTextBoxColumn carMake;
        private DataGridViewTextBoxColumn carModel;
    }
}