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
            this.CARID_textBox = new System.Windows.Forms.TextBox();
            this.CARID_label = new System.Windows.Forms.Label();
            this.PIN_label = new System.Windows.Forms.Label();
            this.TYPE_label = new System.Windows.Forms.Label();
            this.PLATENO_label = new System.Windows.Forms.Label();
            this.MODEL_label = new System.Windows.Forms.Label();
            this.MAKE_label = new System.Windows.Forms.Label();
            this.MILES_label = new System.Windows.Forms.Label();
            this.YEAR_label = new System.Windows.Forms.Label();
            this.PIN_textBox = new System.Windows.Forms.TextBox();
            this.TYPE_textBox = new System.Windows.Forms.TextBox();
            this.PLATENO_textBox = new System.Windows.Forms.TextBox();
            this.MODEL_textBox = new System.Windows.Forms.TextBox();
            this.MAKE_textBox = new System.Windows.Forms.TextBox();
            this.MILES_textBox = new System.Windows.Forms.TextBox();
            this.YEAR_textBox = new System.Windows.Forms.TextBox();
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
            this.headerBackground = new System.Windows.Forms.Panel();
            this.page_name = new System.Windows.Forms.Label();
            this.logout_button = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.sidebarBackground = new System.Windows.Forms.Panel();
            this.Branch_label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ValueGrid)).BeginInit();
            this.headerBackground.SuspendLayout();
            this.sidebarBackground.SuspendLayout();
            this.SuspendLayout();
            // 
            // CARID_textBox
            // 
            this.CARID_textBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CARID_textBox.Location = new System.Drawing.Point(21, 45);
            this.CARID_textBox.Name = "CARID_textBox";
            this.CARID_textBox.ReadOnly = true;
            this.CARID_textBox.Size = new System.Drawing.Size(189, 39);
            this.CARID_textBox.TabIndex = 0;
            this.CARID_textBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // CARID_label
            // 
            this.CARID_label.AutoSize = true;
            this.CARID_label.BackColor = System.Drawing.Color.Gainsboro;
            this.CARID_label.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CARID_label.Location = new System.Drawing.Point(75, 140);
            this.CARID_label.Name = "CARID_label";
            this.CARID_label.Size = new System.Drawing.Size(88, 32);
            this.CARID_label.TabIndex = 1;
            this.CARID_label.Text = "CAR ID";
            this.CARID_label.Click += new System.EventHandler(this.label1_Click);
            // 
            // PIN_label
            // 
            this.PIN_label.AutoSize = true;
            this.PIN_label.BackColor = System.Drawing.Color.Gainsboro;
            this.PIN_label.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.PIN_label.Location = new System.Drawing.Point(90, 217);
            this.PIN_label.Name = "PIN_label";
            this.PIN_label.Size = new System.Drawing.Size(51, 32);
            this.PIN_label.TabIndex = 2;
            this.PIN_label.Text = "PIN";
            this.PIN_label.Click += new System.EventHandler(this.label2_Click);
            // 
            // TYPE_label
            // 
            this.TYPE_label.AutoSize = true;
            this.TYPE_label.BackColor = System.Drawing.Color.Gainsboro;
            this.TYPE_label.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TYPE_label.Location = new System.Drawing.Point(85, 300);
            this.TYPE_label.Name = "TYPE_label";
            this.TYPE_label.Size = new System.Drawing.Size(65, 32);
            this.TYPE_label.TabIndex = 3;
            this.TYPE_label.Text = "TYPE";
            this.TYPE_label.Click += new System.EventHandler(this.label3_Click);
            // 
            // PLATENO_label
            // 
            this.PLATENO_label.AutoSize = true;
            this.PLATENO_label.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.PLATENO_label.Location = new System.Drawing.Point(56, 253);
            this.PLATENO_label.Name = "PLATENO_label";
            this.PLATENO_label.Size = new System.Drawing.Size(125, 32);
            this.PLATENO_label.TabIndex = 4;
            this.PLATENO_label.Text = "PLATE NO.";
            this.PLATENO_label.Click += new System.EventHandler(this.label4_Click);
            // 
            // MODEL_label
            // 
            this.MODEL_label.AutoSize = true;
            this.MODEL_label.BackColor = System.Drawing.Color.Gainsboro;
            this.MODEL_label.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MODEL_label.Location = new System.Drawing.Point(72, 464);
            this.MODEL_label.Name = "MODEL_label";
            this.MODEL_label.Size = new System.Drawing.Size(94, 32);
            this.MODEL_label.TabIndex = 5;
            this.MODEL_label.Text = "MODEL";
            this.MODEL_label.Click += new System.EventHandler(this.label5_Click);
            // 
            // MAKE_label
            // 
            this.MAKE_label.AutoSize = true;
            this.MAKE_label.BackColor = System.Drawing.Color.Gainsboro;
            this.MAKE_label.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MAKE_label.Location = new System.Drawing.Point(78, 548);
            this.MAKE_label.Name = "MAKE_label";
            this.MAKE_label.Size = new System.Drawing.Size(77, 32);
            this.MAKE_label.TabIndex = 6;
            this.MAKE_label.Text = "MAKE";
            this.MAKE_label.Click += new System.EventHandler(this.label6_Click);
            // 
            // MILES_label
            // 
            this.MILES_label.AutoSize = true;
            this.MILES_label.BackColor = System.Drawing.Color.Gainsboro;
            this.MILES_label.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MILES_label.Location = new System.Drawing.Point(78, 626);
            this.MILES_label.Name = "MILES_label";
            this.MILES_label.Size = new System.Drawing.Size(78, 32);
            this.MILES_label.TabIndex = 7;
            this.MILES_label.Text = "MILES";
            this.MILES_label.Click += new System.EventHandler(this.label7_Click);
            // 
            // YEAR_label
            // 
            this.YEAR_label.AutoSize = true;
            this.YEAR_label.BackColor = System.Drawing.Color.Gainsboro;
            this.YEAR_label.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.YEAR_label.Location = new System.Drawing.Point(83, 706);
            this.YEAR_label.Name = "YEAR_label";
            this.YEAR_label.Size = new System.Drawing.Size(68, 32);
            this.YEAR_label.TabIndex = 8;
            this.YEAR_label.Text = "YEAR";
            this.YEAR_label.Click += new System.EventHandler(this.label8_Click);
            // 
            // PIN_textBox
            // 
            this.PIN_textBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.PIN_textBox.Location = new System.Drawing.Point(21, 254);
            this.PIN_textBox.Name = "PIN_textBox";
            this.PIN_textBox.Size = new System.Drawing.Size(189, 39);
            this.PIN_textBox.TabIndex = 9;
            this.PIN_textBox.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // TYPE_textBox
            // 
            this.TYPE_textBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TYPE_textBox.Location = new System.Drawing.Point(21, 336);
            this.TYPE_textBox.Name = "TYPE_textBox";
            this.TYPE_textBox.Size = new System.Drawing.Size(189, 39);
            this.TYPE_textBox.TabIndex = 10;
            this.TYPE_textBox.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // PLATENO_textBox
            // 
            this.PLATENO_textBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.PLATENO_textBox.Location = new System.Drawing.Point(21, 418);
            this.PLATENO_textBox.Name = "PLATENO_textBox";
            this.PLATENO_textBox.Size = new System.Drawing.Size(189, 39);
            this.PLATENO_textBox.TabIndex = 11;
            this.PLATENO_textBox.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // MODEL_textBox
            // 
            this.MODEL_textBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MODEL_textBox.Location = new System.Drawing.Point(21, 500);
            this.MODEL_textBox.Name = "MODEL_textBox";
            this.MODEL_textBox.Size = new System.Drawing.Size(189, 39);
            this.MODEL_textBox.TabIndex = 12;
            this.MODEL_textBox.TextChanged += new System.EventHandler(this.textBox5_TextChanged);
            // 
            // MAKE_textBox
            // 
            this.MAKE_textBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MAKE_textBox.Location = new System.Drawing.Point(21, 584);
            this.MAKE_textBox.Name = "MAKE_textBox";
            this.MAKE_textBox.Size = new System.Drawing.Size(189, 39);
            this.MAKE_textBox.TabIndex = 13;
            this.MAKE_textBox.TextChanged += new System.EventHandler(this.textBox6_TextChanged);
            // 
            // MILES_textBox
            // 
            this.MILES_textBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MILES_textBox.Location = new System.Drawing.Point(21, 662);
            this.MILES_textBox.Name = "MILES_textBox";
            this.MILES_textBox.Size = new System.Drawing.Size(189, 39);
            this.MILES_textBox.TabIndex = 14;
            this.MILES_textBox.TextChanged += new System.EventHandler(this.textBox7_TextChanged);
            // 
            // YEAR_textBox
            // 
            this.YEAR_textBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.YEAR_textBox.Location = new System.Drawing.Point(21, 742);
            this.YEAR_textBox.Name = "YEAR_textBox";
            this.YEAR_textBox.Size = new System.Drawing.Size(189, 39);
            this.YEAR_textBox.TabIndex = 15;
            this.YEAR_textBox.TextChanged += new System.EventHandler(this.textBox8_TextChanged);
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
            this.ValueGrid.Location = new System.Drawing.Point(256, 256);
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
            this.add_button.Location = new System.Drawing.Point(316, 723);
            this.add_button.Name = "add_button";
            this.add_button.Size = new System.Drawing.Size(185, 50);
            this.add_button.TabIndex = 17;
            this.add_button.Text = "ADD";
            this.add_button.UseVisualStyleBackColor = false;
            this.add_button.Click += new System.EventHandler(this.add_button_Click);
            // 
            // update_button
            // 
            this.update_button.BackColor = System.Drawing.Color.LightSteelBlue;
            this.update_button.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.update_button.Location = new System.Drawing.Point(811, 723);
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
            this.delete_button.Location = new System.Drawing.Point(1287, 723);
            this.delete_button.Name = "delete_button";
            this.delete_button.Size = new System.Drawing.Size(185, 50);
            this.delete_button.TabIndex = 19;
            this.delete_button.Text = "DELETE";
            this.delete_button.UseVisualStyleBackColor = false;
            this.delete_button.Click += new System.EventHandler(this.delete_button_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(762, 168);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(326, 46);
            this.comboBox1.TabIndex = 20;
            this.comboBox1.TextChanged += new System.EventHandler(this.TEST);
            // 
            // headerBackground
            // 
            this.headerBackground.BackColor = System.Drawing.Color.LightSteelBlue;
            this.headerBackground.Controls.Add(this.page_name);
            this.headerBackground.Controls.Add(this.logout_button);
            this.headerBackground.Controls.Add(this.panel2);
            this.headerBackground.Location = new System.Drawing.Point(-5, 0);
            this.headerBackground.Name = "headerBackground";
            this.headerBackground.Size = new System.Drawing.Size(1701, 130);
            this.headerBackground.TabIndex = 21;
            // 
            // page_name
            // 
            this.page_name.AutoSize = true;
            this.page_name.Font = new System.Drawing.Font("Segoe UI", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.page_name.Location = new System.Drawing.Point(507, 37);
            this.page_name.Name = "page_name";
            this.page_name.Size = new System.Drawing.Size(782, 70);
            this.page_name.TabIndex = 24;
            this.page_name.Text = "CAR INVENTORY MANAGEMENT";
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
            // sidebarBackground
            // 
            this.sidebarBackground.BackColor = System.Drawing.Color.Gainsboro;
            this.sidebarBackground.Controls.Add(this.PLATENO_label);
            this.sidebarBackground.Controls.Add(this.CARID_textBox);
            this.sidebarBackground.Location = new System.Drawing.Point(0, 130);
            this.sidebarBackground.Name = "sidebarBackground";
            this.sidebarBackground.Size = new System.Drawing.Size(232, 684);
            this.sidebarBackground.TabIndex = 22;
            // 
            // Branch_label
            // 
            this.Branch_label.AutoSize = true;
            this.Branch_label.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Branch_label.Location = new System.Drawing.Point(642, 171);
            this.Branch_label.Name = "Branch_label";
            this.Branch_label.Size = new System.Drawing.Size(116, 38);
            this.Branch_label.TabIndex = 23;
            this.Branch_label.Text = "Branch: ";
            this.Branch_label.Click += new System.EventHandler(this.label9_Click_1);
            // 
            // InventoryManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1540, 802);
            this.Controls.Add(this.Branch_label);
            this.Controls.Add(this.headerBackground);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.delete_button);
            this.Controls.Add(this.update_button);
            this.Controls.Add(this.add_button);
            this.Controls.Add(this.ValueGrid);
            this.Controls.Add(this.YEAR_textBox);
            this.Controls.Add(this.MILES_textBox);
            this.Controls.Add(this.MAKE_textBox);
            this.Controls.Add(this.MODEL_textBox);
            this.Controls.Add(this.PLATENO_textBox);
            this.Controls.Add(this.TYPE_textBox);
            this.Controls.Add(this.PIN_textBox);
            this.Controls.Add(this.YEAR_label);
            this.Controls.Add(this.MILES_label);
            this.Controls.Add(this.MAKE_label);
            this.Controls.Add(this.MODEL_label);
            this.Controls.Add(this.TYPE_label);
            this.Controls.Add(this.PIN_label);
            this.Controls.Add(this.CARID_label);
            this.Controls.Add(this.sidebarBackground);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "InventoryManagement";
            this.Text = "Form1";
            this.TextChanged += new System.EventHandler(this.TEST);
            this.Click += new System.EventHandler(this.ValueGrid_CellContentClick);
            ((System.ComponentModel.ISupportInitialize)(this.ValueGrid)).EndInit();
            this.headerBackground.ResumeLayout(false);
            this.headerBackground.PerformLayout();
            this.sidebarBackground.ResumeLayout(false);
            this.sidebarBackground.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox CARID_textBox;
        private Label CARID_label;
        private Label PIN_label;
        private Label TYPE_label;
        private Label PLATENO_label;
        private Label MODEL_label;
        private Label MAKE_label;
        private Label MILES_label;
        private Label YEAR_label;
        private TextBox PIN_textBox;
        private TextBox TYPE_textBox;
        private TextBox PLATENO_textBox;
        private TextBox MODEL_textBox;
        private TextBox MAKE_textBox;
        private TextBox MILES_textBox;
        private TextBox YEAR_textBox;
        private DataGridView ValueGrid;
        private Button add_button;
        private Button update_button;
        private Button delete_button;
        private ComboBox comboBox1;
        private Panel headerBackground;
        private Panel panel2;
        private Panel sidebarBackground;
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
        private Label Branch_label;
    }
}