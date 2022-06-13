namespace CarRental
{
    partial class Start
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
            this.CustLogin = new System.Windows.Forms.Button();
            this.EmpLogin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CustLogin
            // 
            this.CustLogin.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.CustLogin.Location = new System.Drawing.Point(55, 61);
            this.CustLogin.Name = "CustLogin";
            this.CustLogin.Size = new System.Drawing.Size(199, 57);
            this.CustLogin.TabIndex = 0;
            this.CustLogin.Text = "Customer";
            this.CustLogin.UseVisualStyleBackColor = true;
            this.CustLogin.Click += new System.EventHandler(this.CustLogin_Click);
            // 
            // EmpLogin
            // 
            this.EmpLogin.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.EmpLogin.Location = new System.Drawing.Point(296, 61);
            this.EmpLogin.Name = "EmpLogin";
            this.EmpLogin.Size = new System.Drawing.Size(203, 57);
            this.EmpLogin.TabIndex = 1;
            this.EmpLogin.Text = "Employee";
            this.EmpLogin.UseVisualStyleBackColor = true;
            // 
            // Start
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 185);
            this.Controls.Add(this.EmpLogin);
            this.Controls.Add(this.CustLogin);
            this.Name = "Start";
            this.Text = "Welcome";
            this.ResumeLayout(false);

        }

        #endregion

        private Button CustLogin;
        private Button EmpLogin;
    }
}