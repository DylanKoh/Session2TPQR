namespace Session2
{
    partial class ManagerMain
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
            this.backBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.viewPackageBtn = new System.Windows.Forms.Button();
            this.addPackageBtn = new System.Windows.Forms.Button();
            this.approveBookingsBtn = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // backBtn
            // 
            this.backBtn.Location = new System.Drawing.Point(12, 12);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(116, 49);
            this.backBtn.TabIndex = 0;
            this.backBtn.Text = "Back";
            this.backBtn.UseVisualStyleBackColor = true;
            this.backBtn.Click += new System.EventHandler(this.backBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(275, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(408, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "Sponsor Manager Main Menu";
            // 
            // viewPackageBtn
            // 
            this.viewPackageBtn.Location = new System.Drawing.Point(225, 123);
            this.viewPackageBtn.Name = "viewPackageBtn";
            this.viewPackageBtn.Size = new System.Drawing.Size(225, 92);
            this.viewPackageBtn.TabIndex = 2;
            this.viewPackageBtn.Text = "View Sponsorship Packages";
            this.viewPackageBtn.UseVisualStyleBackColor = true;
            this.viewPackageBtn.Click += new System.EventHandler(this.viewPackageBtn_Click);
            // 
            // addPackageBtn
            // 
            this.addPackageBtn.Location = new System.Drawing.Point(490, 123);
            this.addPackageBtn.Name = "addPackageBtn";
            this.addPackageBtn.Size = new System.Drawing.Size(225, 92);
            this.addPackageBtn.TabIndex = 3;
            this.addPackageBtn.Text = "Add Sponsorship Packages";
            this.addPackageBtn.UseVisualStyleBackColor = true;
            this.addPackageBtn.Click += new System.EventHandler(this.addPackageBtn_Click);
            // 
            // approveBookingsBtn
            // 
            this.approveBookingsBtn.Location = new System.Drawing.Point(225, 251);
            this.approveBookingsBtn.Name = "approveBookingsBtn";
            this.approveBookingsBtn.Size = new System.Drawing.Size(225, 92);
            this.approveBookingsBtn.TabIndex = 4;
            this.approveBookingsBtn.Text = "Approve Sponsorship Bookings";
            this.approveBookingsBtn.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(490, 251);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(225, 92);
            this.button4.TabIndex = 5;
            this.button4.Text = "View Sponsorship Summary";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // ManagerMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(969, 537);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.approveBookingsBtn);
            this.Controls.Add(this.addPackageBtn);
            this.Controls.Add(this.viewPackageBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.backBtn);
            this.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "ManagerMain";
            this.Text = "ASEAN Skills 2020 - Sponsor Manager Main Menu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button backBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button viewPackageBtn;
        private System.Windows.Forms.Button addPackageBtn;
        private System.Windows.Forms.Button approveBookingsBtn;
        private System.Windows.Forms.Button button4;
    }
}