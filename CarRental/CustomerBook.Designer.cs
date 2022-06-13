namespace CarRental
{
    partial class CustomerBook
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.SelectButton = new System.Windows.Forms.Button();
            this.ValueGrid = new System.Windows.Forms.DataGridView();
            this.Home = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.DollarLabel = new System.Windows.Forms.Label();
            this.SelectedCar = new System.Windows.Forms.Label();
            this.selectedLabel = new System.Windows.Forms.Label();
            this.PriceLabel = new System.Windows.Forms.Label();
            this.IDcol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TypeCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MakeCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ModelCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.YearCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MilesCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PINCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlateNoCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ValueGrid)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Controls.Add(this.SelectButton);
            this.panel1.Controls.Add(this.ValueGrid);
            this.panel1.Location = new System.Drawing.Point(12, 51);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1051, 604);
            this.panel1.TabIndex = 3;
            // 
            // SelectButton
            // 
            this.SelectButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.SelectButton.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.SelectButton.Location = new System.Drawing.Point(897, 542);
            this.SelectButton.Name = "SelectButton";
            this.SelectButton.Size = new System.Drawing.Size(137, 45);
            this.SelectButton.TabIndex = 13;
            this.SelectButton.Text = "Select";
            this.SelectButton.UseVisualStyleBackColor = false;
            this.SelectButton.Click += new System.EventHandler(this.SelectButton_Click_1);
            // 
            // ValueGrid
            // 
            this.ValueGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ValueGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDcol,
            this.TypeCol,
            this.MakeCol,
            this.ModelCol,
            this.YearCol,
            this.MilesCol,
            this.PINCol,
            this.PlateNoCol});
            this.ValueGrid.Location = new System.Drawing.Point(0, 55);
            this.ValueGrid.Name = "ValueGrid";
            this.ValueGrid.RowHeadersWidth = 51;
            this.ValueGrid.RowTemplate.Height = 29;
            this.ValueGrid.Size = new System.Drawing.Size(1051, 469);
            this.ValueGrid.TabIndex = 12;
            this.ValueGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ValueGrid_CellContentClick);
            // 
            // Home
            // 
            this.Home.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Home.Location = new System.Drawing.Point(12, 10);
            this.Home.Name = "Home";
            this.Home.Size = new System.Drawing.Size(103, 35);
            this.Home.TabIndex = 2;
            this.Home.Text = "HOME";
            this.Home.UseVisualStyleBackColor = true;
            this.Home.Click += new System.EventHandler(this.Home_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel4.Controls.Add(this.DollarLabel);
            this.panel4.Controls.Add(this.SelectedCar);
            this.panel4.Controls.Add(this.selectedLabel);
            this.panel4.Controls.Add(this.PriceLabel);
            this.panel4.Location = new System.Drawing.Point(12, 51);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1051, 57);
            this.panel4.TabIndex = 4;
            // 
            // DollarLabel
            // 
            this.DollarLabel.AutoSize = true;
            this.DollarLabel.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.DollarLabel.Location = new System.Drawing.Point(778, 9);
            this.DollarLabel.Name = "DollarLabel";
            this.DollarLabel.Size = new System.Drawing.Size(27, 31);
            this.DollarLabel.TabIndex = 9;
            this.DollarLabel.Text = "$";
            // 
            // SelectedCar
            // 
            this.SelectedCar.AutoSize = true;
            this.SelectedCar.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.SelectedCar.Location = new System.Drawing.Point(162, 9);
            this.SelectedCar.Name = "SelectedCar";
            this.SelectedCar.Size = new System.Drawing.Size(118, 31);
            this.SelectedCar.TabIndex = 8;
            this.SelectedCar.Text = "Car Name";
            // 
            // selectedLabel
            // 
            this.selectedLabel.AutoSize = true;
            this.selectedLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.selectedLabel.Location = new System.Drawing.Point(17, 9);
            this.selectedLabel.Name = "selectedLabel";
            this.selectedLabel.Size = new System.Drawing.Size(156, 31);
            this.selectedLabel.TabIndex = 7;
            this.selectedLabel.Text = "Selected Car: ";
            // 
            // PriceLabel
            // 
            this.PriceLabel.AutoSize = true;
            this.PriceLabel.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.PriceLabel.Location = new System.Drawing.Point(828, 9);
            this.PriceLabel.Name = "PriceLabel";
            this.PriceLabel.Size = new System.Drawing.Size(67, 31);
            this.PriceLabel.TabIndex = 6;
            this.PriceLabel.Text = "Price";
            // 
            // IDcol
            // 
            this.IDcol.HeaderText = "Car ID";
            this.IDcol.MinimumWidth = 6;
            this.IDcol.Name = "IDcol";
            this.IDcol.Width = 125;
            // 
            // TypeCol
            // 
            this.TypeCol.HeaderText = "Type";
            this.TypeCol.MinimumWidth = 6;
            this.TypeCol.Name = "TypeCol";
            this.TypeCol.Width = 125;
            // 
            // MakeCol
            // 
            this.MakeCol.HeaderText = "Make";
            this.MakeCol.MinimumWidth = 6;
            this.MakeCol.Name = "MakeCol";
            this.MakeCol.Width = 125;
            // 
            // ModelCol
            // 
            this.ModelCol.HeaderText = "Model";
            this.ModelCol.MinimumWidth = 6;
            this.ModelCol.Name = "ModelCol";
            this.ModelCol.Width = 125;
            // 
            // YearCol
            // 
            this.YearCol.HeaderText = "Year";
            this.YearCol.MinimumWidth = 6;
            this.YearCol.Name = "YearCol";
            this.YearCol.Width = 125;
            // 
            // MilesCol
            // 
            this.MilesCol.HeaderText = "Miles";
            this.MilesCol.MinimumWidth = 6;
            this.MilesCol.Name = "MilesCol";
            this.MilesCol.Width = 125;
            // 
            // PINCol
            // 
            this.PINCol.HeaderText = "VIN";
            this.PINCol.MinimumWidth = 6;
            this.PINCol.Name = "PINCol";
            this.PINCol.Width = 125;
            // 
            // PlateNoCol
            // 
            this.PlateNoCol.HeaderText = "Plate Number";
            this.PlateNoCol.MinimumWidth = 6;
            this.PlateNoCol.Name = "PlateNoCol";
            this.PlateNoCol.Width = 125;
            // 
            // CustomerBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1075, 667);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Home);
            this.Name = "CustomerBook";
            this.Text = "Customer Booking";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ValueGrid)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Button Home;
        private Panel panel4;
        private Label PriceLabel;
        private Label selectedLabel;
        private Label SelectedCar;
        private Label DollarLabel;
        private Button SelectButton;
        public DataGridView ValueGrid;
        private DataGridViewTextBoxColumn IDcol;
        private DataGridViewTextBoxColumn TypeCol;
        private DataGridViewTextBoxColumn MakeCol;
        private DataGridViewTextBoxColumn ModelCol;
        private DataGridViewTextBoxColumn YearCol;
        private DataGridViewTextBoxColumn MilesCol;
        private DataGridViewTextBoxColumn PINCol;
        private DataGridViewTextBoxColumn PlateNoCol;
    }
}