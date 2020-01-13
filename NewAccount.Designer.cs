namespace Session2
{
    partial class NewAccount
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.companyNameBox = new System.Windows.Forms.TextBox();
            this.userIDBox = new System.Windows.Forms.TextBox();
            this.passwordBox = new System.Windows.Forms.TextBox();
            this.rePasswordBox = new System.Windows.Forms.TextBox();
            this.createBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // backBtn
            // 
            this.backBtn.Location = new System.Drawing.Point(12, 12);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(109, 49);
            this.backBtn.TabIndex = 0;
            this.backBtn.Text = "Back";
            this.backBtn.UseVisualStyleBackColor = true;
            this.backBtn.Click += new System.EventHandler(this.backBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(233, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(434, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "New Sponsor Account Creation";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(106, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(187, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Company Name: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(70, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(223, 25);
            this.label3.TabIndex = 3;
            this.label3.Text = "User ID (For Login): ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(172, 215);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 25);
            this.label4.TabIndex = 4;
            this.label4.Text = "Password: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(75, 266);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(218, 25);
            this.label5.TabIndex = 5;
            this.label5.Text = "Re-Enter Password: ";
            // 
            // companyNameBox
            // 
            this.companyNameBox.Location = new System.Drawing.Point(299, 115);
            this.companyNameBox.Name = "companyNameBox";
            this.companyNameBox.Size = new System.Drawing.Size(433, 32);
            this.companyNameBox.TabIndex = 6;
            // 
            // userIDBox
            // 
            this.userIDBox.Location = new System.Drawing.Point(299, 164);
            this.userIDBox.Name = "userIDBox";
            this.userIDBox.Size = new System.Drawing.Size(433, 32);
            this.userIDBox.TabIndex = 7;
            // 
            // passwordBox
            // 
            this.passwordBox.Location = new System.Drawing.Point(299, 212);
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.PasswordChar = '*';
            this.passwordBox.Size = new System.Drawing.Size(433, 32);
            this.passwordBox.TabIndex = 8;
            // 
            // rePasswordBox
            // 
            this.rePasswordBox.Location = new System.Drawing.Point(299, 263);
            this.rePasswordBox.Name = "rePasswordBox";
            this.rePasswordBox.PasswordChar = '*';
            this.rePasswordBox.Size = new System.Drawing.Size(433, 32);
            this.rePasswordBox.TabIndex = 9;
            // 
            // createBtn
            // 
            this.createBtn.Location = new System.Drawing.Point(343, 433);
            this.createBtn.Name = "createBtn";
            this.createBtn.Size = new System.Drawing.Size(195, 74);
            this.createBtn.TabIndex = 10;
            this.createBtn.Text = "Create Account";
            this.createBtn.UseVisualStyleBackColor = true;
            this.createBtn.Click += new System.EventHandler(this.createBtn_Click);
            // 
            // NewAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 519);
            this.Controls.Add(this.createBtn);
            this.Controls.Add(this.rePasswordBox);
            this.Controls.Add(this.passwordBox);
            this.Controls.Add(this.userIDBox);
            this.Controls.Add(this.companyNameBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.backBtn);
            this.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "NewAccount";
            this.Text = "ASEAN Skills 2020 - New Sponsor Account Creation";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button backBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox companyNameBox;
        private System.Windows.Forms.TextBox userIDBox;
        private System.Windows.Forms.TextBox passwordBox;
        private System.Windows.Forms.TextBox rePasswordBox;
        private System.Windows.Forms.Button createBtn;
    }
}