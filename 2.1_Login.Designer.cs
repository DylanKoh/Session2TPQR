namespace Session2
{
    partial class Login
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.loginBtn = new System.Windows.Forms.Button();
            this.createBtn = new System.Windows.Forms.Button();
            this.userIDBox = new System.Windows.Forms.TextBox();
            this.passwordBox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(278, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(447, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sponsorship Management Login";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(94, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "User ID: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(77, 200);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Password: ";
            // 
            // loginBtn
            // 
            this.loginBtn.Location = new System.Drawing.Point(415, 284);
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.Size = new System.Drawing.Size(144, 53);
            this.loginBtn.TabIndex = 3;
            this.loginBtn.Text = "Login";
            this.loginBtn.UseVisualStyleBackColor = true;
            this.loginBtn.Click += new System.EventHandler(this.loginBtn_Click);
            // 
            // createBtn
            // 
            this.createBtn.Location = new System.Drawing.Point(355, 343);
            this.createBtn.Name = "createBtn";
            this.createBtn.Size = new System.Drawing.Size(261, 59);
            this.createBtn.TabIndex = 4;
            this.createBtn.Text = "Create New Sponsor Account";
            this.createBtn.UseVisualStyleBackColor = true;
            this.createBtn.Click += new System.EventHandler(this.createBtn_Click);
            // 
            // userIDBox
            // 
            this.userIDBox.Location = new System.Drawing.Point(204, 142);
            this.userIDBox.Name = "userIDBox";
            this.userIDBox.Size = new System.Drawing.Size(652, 32);
            this.userIDBox.TabIndex = 5;
            // 
            // passwordBox
            // 
            this.passwordBox.Location = new System.Drawing.Point(204, 197);
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.PasswordChar = '*';
            this.passwordBox.Size = new System.Drawing.Size(652, 32);
            this.passwordBox.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Maroon;
            this.panel1.Controls.Add(this.label6);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1034, 83);
            this.panel1.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 16F);
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.Location = new System.Drawing.Point(376, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(263, 64);
            this.label6.TabIndex = 1;
            this.label6.Text = "ASEAN Skills 2020\r\n26-28 Jul 2020";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1034, 425);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.passwordBox);
            this.Controls.Add(this.userIDBox);
            this.Controls.Add(this.createBtn);
            this.Controls.Add(this.loginBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Login";
            this.Text = "ASEAN Skills 2020 - Login";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button loginBtn;
        private System.Windows.Forms.Button createBtn;
        private System.Windows.Forms.TextBox userIDBox;
        private System.Windows.Forms.TextBox passwordBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
    }
}

