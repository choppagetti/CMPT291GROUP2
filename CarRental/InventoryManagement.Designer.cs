namespace CarRental
{
    partial class InventoryManagement
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.ValueGrid = new System.Windows.Forms.DataGridView();
            this.CAR_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PIN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TYPE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PLATE_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MODEL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MAKE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MILES = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.YEAR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.add_button = new System.Windows.Forms.Button();
            this.update_button = new System.Windows.Forms.Button();
            this.delete_button = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.page_name = new System.Windows.Forms.Label();
            this.logout_button = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ValueGrid)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox1.Location = new System.Drawing.Point(21, 45);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(189, 39);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Gainsboro;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(75, 140);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "CAR ID";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Gainsboro;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(90, 217);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 32);
            this.label2.TabIndex = 2;
            this.label2.Text = "PIN";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Gainsboro;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(85, 300);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 32);
            this.label3.TabIndex = 3;
            this.label3.Text = "TYPE";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(56, 253);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 32);
            this.label4.TabIndex = 4;
            this.label4.Text = "PLATE NO.";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Gainsboro;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(72, 464);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 32);
            this.label5.TabIndex = 5;
            this.label5.Text = "MODEL";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Gainsboro;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(78, 548);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 32);
            this.label6.TabIndex = 6;
            this.label6.Text = "MAKE";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Gainsboro;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(78, 626);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 32);
            this.label7.TabIndex = 7;
            this.label7.Text = "MILES";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Gainsboro;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(83, 706);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 32);
            this.label8.TabIndex = 8;
            this.label8.Text = "YEAR";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox2.Location = new System.Drawing.Point(21, 254);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(189, 39);
            this.textBox2.TabIndex = 9;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox3.Location = new System.Drawing.Point(21, 336);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(189, 39);
            this.textBox3.TabIndex = 10;
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // textBox4
            // 
            this.textBox4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox4.Location = new System.Drawing.Point(21, 418);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(189, 39);
            this.textBox4.TabIndex = 11;
            this.textBox4.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // textBox5
            // 
            this.textBox5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox5.Location = new System.Drawing.Point(21, 500);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(189, 39);
            this.textBox5.TabIndex = 12;
            this.textBox5.TextChanged += new System.EventHandler(this.textBox5_TextChanged);
            // 
            // textBox6
            // 
            this.textBox6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox6.Location = new System.Drawing.Point(21, 584);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(189, 39);
            this.textBox6.TabIndex = 13;
            this.textBox6.TextChanged += new System.EventHandler(this.textBox6_TextChanged);
            // 
            // textBox7
            // 
            this.textBox7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox7.Location = new System.Drawing.Point(21, 662);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(189, 39);
            this.textBox7.TabIndex = 14;
            this.textBox7.TextChanged += new System.EventHandler(this.textBox7_TextChanged);
            // 
            // textBox8
            // 
            this.textBox8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox8.Location = new System.Drawing.Point(21, 742);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(189, 39);
            this.textBox8.TabIndex = 15;
            this.textBox8.TextChanged += new System.EventHandler(this.textBox8_TextChanged);
            // 
            // ValueGrid
            // 
            this.ValueGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ValueGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CAR_ID,
            this.PIN,
            this.TYPE,
            this.PLATE_NO,
            this.MODEL,
            this.MAKE,
            this.MILES,
            this.YEAR});
            this.ValueGrid.Location = new System.Drawing.Point(253, 256);
            this.ValueGrid.Name = "ValueGrid";
            this.ValueGrid.RowHeadersWidth = 62;
            this.ValueGrid.RowTemplate.Height = 33;
            this.ValueGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ValueGrid.Size = new System.Drawing.Size(1260, 437);
            this.ValueGrid.TabIndex = 16;
            this.ValueGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ValueGrid_CellContentClick);
            this.ValueGrid.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.ValueGrid_CellContentClick);
            this.ValueGrid.Click += new System.EventHandler(this.ValueGrid_CellContentClick);
            // 
            // CAR_ID
            // 
            this.CAR_ID.HeaderText = "CAR ID";
            this.CAR_ID.MinimumWidth = 8;
            this.CAR_ID.Name = "CAR_ID";
            this.CAR_ID.Width = 150;
            // 
            // PIN
            // 
            this.PIN.HeaderText = "PIN";
            this.PIN.MinimumWidth = 8;
            this.PIN.Name = "PIN";
            this.PIN.Width = 150;
            // 
            // TYPE
            // 
            this.TYPE.HeaderText = "TYPE";
            this.TYPE.MinimumWidth = 8;
            this.TYPE.Name = "TYPE";
            this.TYPE.Width = 150;
            // 
            // PLATE_NO
            // 
            this.PLATE_NO.HeaderText = "PLATE NO.";
            this.PLATE_NO.MinimumWidth = 8;
            this.PLATE_NO.Name = "PLATE_NO";
            this.PLATE_NO.Width = 150;
            // 
            // MODEL
            // 
            this.MODEL.HeaderText = "MODEL";
            this.MODEL.MinimumWidth = 8;
            this.MODEL.Name = "MODEL";
            this.MODEL.Width = 150;
            // 
            // MAKE
            // 
            this.MAKE.HeaderText = "MAKE";
            this.MAKE.MinimumWidth = 8;
            this.MAKE.Name = "MAKE";
            this.MAKE.Width = 150;
            // 
            // MILES
            // 
            this.MILES.HeaderText = "MILES";
            this.MILES.MinimumWidth = 8;
            this.MILES.Name = "MILES";
            this.MILES.Width = 150;
            // 
            // YEAR
            // 
            this.YEAR.HeaderText = "YEAR";
            this.YEAR.MinimumWidth = 8;
            this.YEAR.Name = "YEAR";
            this.YEAR.Width = 150;
            // 
            // add_button
            // 
            this.add_button.BackColor = System.Drawing.Color.LightSteelBlue;
            this.add_button.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.add_button.Location = new System.Drawing.Point(313, 723);
            this.add_button.Name = "add_button";
            this.add_button.Size = new System.Drawing.Size(185, 50);
            this.add_button.TabIndex = 17;
            this.add_button.Text = "ADD";
            this.add_button.UseVisualStyleBackColor = false;
            this.add_button.Click += new System.EventHandler(this.button1_Click);
            // 
            // update_button
            // 
            this.update_button.BackColor = System.Drawing.Color.LightSteelBlue;
            this.update_button.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.update_button.Location = new System.Drawing.Point(808, 723);
            this.update_button.Name = "update_button";
            this.update_button.Size = new System.Drawing.Size(185, 50);
            this.update_button.TabIndex = 18;
            this.update_button.Text = "UPDATE";
            this.update_button.UseVisualStyleBackColor = false;
            this.update_button.Click += new System.EventHandler(this.update_button_Click);
            // 
            // delete_button
            // 
            this.delete_button.BackColor = System.Drawing.Color.LightSteelBlue;
            this.delete_button.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.delete_button.Location = new System.Drawing.Point(1284, 723);
            this.delete_button.Name = "delete_button";
            this.delete_button.Size = new System.Drawing.Size(185, 50);
            this.delete_button.TabIndex = 19;
            this.delete_button.Text = "DELETE";
            this.delete_button.UseVisualStyleBackColor = false;
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(747, 175);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(326, 40);
            this.comboBox1.TabIndex = 20;
            this.comboBox1.TextChanged += new System.EventHandler(this.TEST);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel1.Controls.Add(this.page_name);
            this.panel1.Controls.Add(this.logout_button);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(-5, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1701, 130);
            this.panel1.TabIndex = 21;
            // 
            // page_name
            // 
            this.page_name.AutoSize = true;
            this.page_name.Font = new System.Drawing.Font("Segoe UI", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.page_name.Location = new System.Drawing.Point(573, 37);
            this.page_name.Name = "page_name";
            this.page_name.Size = new System.Drawing.Size(671, 70);
            this.page_name.TabIndex = 24;
            this.page_name.Text = "INVENTORY MANAGEMENT";
            this.page_name.Click += new System.EventHandler(this.label9_Click);
            // 
            // logout_button
            // 
            this.logout_button.Location = new System.Drawing.Point(17, 12);
            this.logout_button.Name = "logout_button";
            this.logout_button.Size = new System.Drawing.Size(112, 34);
            this.logout_button.TabIndex = 23;
            this.logout_button.Text = "LOG OUT";
            this.logout_button.UseVisualStyleBackColor = true;
            this.logout_button.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel2.Location = new System.Drawing.Point(117, 130);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(233, 675);
            this.panel2.TabIndex = 22;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Gainsboro;
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.textBox1);
            this.panel3.Location = new System.Drawing.Point(0, 130);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(230, 684);
            this.panel3.TabIndex = 22;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(643, 179);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(99, 32);
            this.label9.TabIndex = 23;
            this.label9.Text = "Branch: ";
            // 
            // InventoryManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1538, 802);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.delete_button);
            this.Controls.Add(this.update_button);
            this.Controls.Add(this.add_button);
            this.Controls.Add(this.ValueGrid);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel3);
            this.Name = "InventoryManagement";
            this.Text = "Form1";
            this.TextChanged += new System.EventHandler(this.TEST);
            this.Click += new System.EventHandler(this.ValueGrid_CellContentClick);
            ((System.ComponentModel.ISupportInitialize)(this.ValueGrid)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox textBox1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox5;
        private TextBox textBox6;
        private TextBox textBox7;
        private TextBox textBox8;
        private DataGridView ValueGrid;
        private Button add_button;
        private Button update_button;
        private Button delete_button;
        private ComboBox comboBox1;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Button logout_button;
        private Label page_name;
        private DataGridViewTextBoxColumn CAR_ID;
        private DataGridViewTextBoxColumn PIN;
        private DataGridViewTextBoxColumn TYPE;
        private DataGridViewTextBoxColumn PLATE_NO;
        private DataGridViewTextBoxColumn MODEL;
        private DataGridViewTextBoxColumn MAKE;
        private DataGridViewTextBoxColumn MILES;
        private DataGridViewTextBoxColumn YEAR;
        private Label label9;
    }
}