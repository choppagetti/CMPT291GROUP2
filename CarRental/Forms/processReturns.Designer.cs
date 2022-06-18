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
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.custID = new System.Windows.Forms.TextBox();
            this.normalRet = new System.Windows.Forms.Button();
            this.carIDRental = new System.Windows.Forms.Label();
            this.branches = new System.Windows.Forms.ComboBox();
            this.transID = new System.Windows.Forms.TextBox();
            this.availability = new System.Windows.Forms.Button();
            this.returnDate = new System.Windows.Forms.DateTimePicker();
            this.lateRet = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(39, 341);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label1.Size = new System.Drawing.Size(117, 21);
            this.label1.TabIndex = 44;
            this.label1.Text = "RETURN DATE";
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(201, 150);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(1073, 471);
            this.dataGridView1.TabIndex = 43;
            // 
            // custID
            // 
            this.custID.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.custID.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.custID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(172)))), ((int)(((byte)(19)))));
            this.custID.Location = new System.Drawing.Point(281, 71);
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
            this.normalRet.Location = new System.Drawing.Point(352, 699);
            this.normalRet.Name = "normalRet";
            this.normalRet.Size = new System.Drawing.Size(300, 40);
            this.normalRet.TabIndex = 41;
            this.normalRet.Text = "AUTHORIZE RETURN";
            this.normalRet.UseVisualStyleBackColor = false;
            // 
            // carIDRental
            // 
            this.carIDRental.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.carIDRental.AutoSize = true;
            this.carIDRental.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.carIDRental.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.carIDRental.Location = new System.Drawing.Point(30, 263);
            this.carIDRental.Name = "carIDRental";
            this.carIDRental.Size = new System.Drawing.Size(139, 21);
            this.carIDRental.TabIndex = 39;
            this.carIDRental.Text = "RETURN BRANCH";
            // 
            // branches
            // 
            this.branches.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.branches.FormattingEnabled = true;
            this.branches.Location = new System.Drawing.Point(29, 287);
            this.branches.Name = "branches";
            this.branches.Size = new System.Drawing.Size(140, 23);
            this.branches.TabIndex = 59;
            // 
            // transID
            // 
            this.transID.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.transID.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.transID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(172)))), ((int)(((byte)(19)))));
            this.transID.Location = new System.Drawing.Point(790, 71);
            this.transID.Name = "transID";
            this.transID.PlaceholderText = "ENTER TRANSACTION ID";
            this.transID.Size = new System.Drawing.Size(440, 23);
            this.transID.TabIndex = 62;
            this.transID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // availability
            // 
            this.availability.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.availability.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.availability.FlatAppearance.BorderSize = 6;
            this.availability.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.availability.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.availability.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.availability.Location = new System.Drawing.Point(29, 461);
            this.availability.Name = "availability";
            this.availability.Size = new System.Drawing.Size(140, 40);
            this.availability.TabIndex = 63;
            this.availability.Text = "RUN CHECK";
            this.availability.UseVisualStyleBackColor = false;
            // 
            // returnDate
            // 
            this.returnDate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.returnDate.Location = new System.Drawing.Point(29, 365);
            this.returnDate.Name = "returnDate";
            this.returnDate.Size = new System.Drawing.Size(140, 23);
            this.returnDate.TabIndex = 64;
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
            this.lateRet.Location = new System.Drawing.Point(790, 699);
            this.lateRet.Name = "lateRet";
            this.lateRet.Size = new System.Drawing.Size(300, 40);
            this.lateRet.TabIndex = 65;
            this.lateRet.Text = "LATE RETURN";
            this.lateRet.UseVisualStyleBackColor = false;
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
            this.Controls.Add(this.transID);
            this.Controls.Add(this.branches);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.custID);
            this.Controls.Add(this.normalRet);
            this.Controls.Add(this.carIDRental);
            this.Name = "processReturns";
            this.Text = "processReturns";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label label1;
        private DataGridView dataGridView1;
        private TextBox custID;
        private Button normalRet;
        private Label carIDRental;
        private ComboBox branches;
        private TextBox transID;
        private Button availability;
        private DateTimePicker returnDate;
        private Button lateRet;
    }
}