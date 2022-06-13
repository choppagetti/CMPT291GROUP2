namespace CarRental
{
    partial class CustomerConfirm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerConfirm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.CarNameText = new System.Windows.Forms.Label();
            this.CarTypeText = new System.Windows.Forms.Label();
            this.ReturnDateText = new System.Windows.Forms.Label();
            this.PickUpDateText = new System.Windows.Forms.Label();
            this.ReturnLocText = new System.Windows.Forms.Label();
            this.PickUpLocText = new System.Windows.Forms.Label();
            this.IDText = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(22, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Customer ID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(22, 170);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(189, 31);
            this.label2.TabIndex = 1;
            this.label2.Text = "Pick-up Location:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(22, 201);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(179, 31);
            this.label3.TabIndex = 2;
            this.label3.Text = "Return Location:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(22, 260);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 31);
            this.label4.TabIndex = 3;
            this.label4.Text = "Pick-up Date:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(22, 291);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(140, 31);
            this.label5.TabIndex = 4;
            this.label5.Text = "Return Date:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(22, 358);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 31);
            this.label6.TabIndex = 5;
            this.label6.Text = "Car Type:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(22, 389);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(120, 31);
            this.label7.TabIndex = 6;
            this.label7.Text = "Car Name:";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button1.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(183, 454);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(134, 48);
            this.button1.TabIndex = 7;
            this.button1.Text = "Confirm";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.CarNameText);
            this.panel1.Controls.Add(this.CarTypeText);
            this.panel1.Controls.Add(this.ReturnDateText);
            this.panel1.Controls.Add(this.PickUpDateText);
            this.panel1.Controls.Add(this.ReturnLocText);
            this.panel1.Controls.Add(this.PickUpLocText);
            this.panel1.Controls.Add(this.IDText);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(504, 518);
            this.panel1.TabIndex = 8;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(207, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(94, 94);
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // CarNameText
            // 
            this.CarNameText.AutoSize = true;
            this.CarNameText.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.CarNameText.Location = new System.Drawing.Point(148, 389);
            this.CarNameText.Name = "CarNameText";
            this.CarNameText.Size = new System.Drawing.Size(169, 31);
            this.CarNameText.TabIndex = 15;
            this.CarNameText.Text = "Car Name Text";
            // 
            // CarTypeText
            // 
            this.CarTypeText.AutoSize = true;
            this.CarTypeText.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.CarTypeText.Location = new System.Drawing.Point(148, 358);
            this.CarTypeText.Name = "CarTypeText";
            this.CarTypeText.Size = new System.Drawing.Size(156, 31);
            this.CarTypeText.TabIndex = 14;
            this.CarTypeText.Text = "Car Type Text";
            // 
            // ReturnDateText
            // 
            this.ReturnDateText.AutoSize = true;
            this.ReturnDateText.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ReturnDateText.Location = new System.Drawing.Point(173, 291);
            this.ReturnDateText.Name = "ReturnDateText";
            this.ReturnDateText.Size = new System.Drawing.Size(193, 31);
            this.ReturnDateText.TabIndex = 13;
            this.ReturnDateText.Text = "Return Date Text";
            // 
            // PickUpDateText
            // 
            this.PickUpDateText.AutoSize = true;
            this.PickUpDateText.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.PickUpDateText.Location = new System.Drawing.Point(173, 260);
            this.PickUpDateText.Name = "PickUpDateText";
            this.PickUpDateText.Size = new System.Drawing.Size(202, 31);
            this.PickUpDateText.TabIndex = 12;
            this.PickUpDateText.Text = "Pick-up Date Text";
            // 
            // ReturnLocText
            // 
            this.ReturnLocText.AutoSize = true;
            this.ReturnLocText.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ReturnLocText.Location = new System.Drawing.Point(207, 201);
            this.ReturnLocText.Name = "ReturnLocText";
            this.ReturnLocText.Size = new System.Drawing.Size(186, 31);
            this.ReturnLocText.TabIndex = 11;
            this.ReturnLocText.Text = "Return Loc. Text";
            // 
            // PickUpLocText
            // 
            this.PickUpLocText.AutoSize = true;
            this.PickUpLocText.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.PickUpLocText.Location = new System.Drawing.Point(207, 170);
            this.PickUpLocText.Name = "PickUpLocText";
            this.PickUpLocText.Size = new System.Drawing.Size(198, 31);
            this.PickUpLocText.TabIndex = 10;
            this.PickUpLocText.Text = "Pick-Up Loc. Text";
            // 
            // IDText
            // 
            this.IDText.AutoSize = true;
            this.IDText.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.IDText.Location = new System.Drawing.Point(173, 110);
            this.IDText.Name = "IDText";
            this.IDText.Size = new System.Drawing.Size(89, 31);
            this.IDText.TabIndex = 9;
            this.IDText.Text = "ID Text";
            // 
            // CustomerConfirm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 542);
            this.Controls.Add(this.panel1);
            this.Name = "CustomerConfirm";
            this.Text = "Confirmation";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Button button1;
        private Panel panel1;
        private Label CarNameText;
        private Label CarTypeText;
        private Label ReturnDateText;
        private Label PickUpDateText;
        private Label ReturnLocText;
        private Label PickUpLocText;
        private Label IDText;
        private PictureBox pictureBox1;
    }
}