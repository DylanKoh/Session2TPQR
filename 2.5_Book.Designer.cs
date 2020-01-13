namespace Session2
{
    partial class Book
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
            this.tierBox = new System.Windows.Forms.ComboBox();
            this.budgetBox = new System.Windows.Forms.TextBox();
            this.onlineBox = new System.Windows.Forms.CheckBox();
            this.flyersBox = new System.Windows.Forms.CheckBox();
            this.bannerBox = new System.Windows.Forms.CheckBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.quantityBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.bookBtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // backBtn
            // 
            this.backBtn.Location = new System.Drawing.Point(12, 12);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(122, 58);
            this.backBtn.TabIndex = 0;
            this.backBtn.Text = "Back";
            this.backBtn.UseVisualStyleBackColor = true;
            this.backBtn.Click += new System.EventHandler(this.backBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(290, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(316, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "Book Sponsorship Packages";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(70, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Filter By Tier: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 158);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(153, 18);
            this.label3.TabIndex = 3;
            this.label3.Text = "Filter By Budget: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 200);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(154, 18);
            this.label4.TabIndex = 4;
            this.label4.Text = "Filter By Benefit: ";
            // 
            // tierBox
            // 
            this.tierBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tierBox.FormattingEnabled = true;
            this.tierBox.Location = new System.Drawing.Point(236, 116);
            this.tierBox.Name = "tierBox";
            this.tierBox.Size = new System.Drawing.Size(205, 26);
            this.tierBox.TabIndex = 5;
            // 
            // budgetBox
            // 
            this.budgetBox.Location = new System.Drawing.Point(236, 155);
            this.budgetBox.Name = "budgetBox";
            this.budgetBox.Size = new System.Drawing.Size(205, 27);
            this.budgetBox.TabIndex = 6;
            this.budgetBox.TextChanged += new System.EventHandler(this.budgetBox_TextChanged);
            // 
            // onlineBox
            // 
            this.onlineBox.AutoSize = true;
            this.onlineBox.Location = new System.Drawing.Point(236, 199);
            this.onlineBox.Name = "onlineBox";
            this.onlineBox.Size = new System.Drawing.Size(80, 22);
            this.onlineBox.TabIndex = 7;
            this.onlineBox.Text = "Online";
            this.onlineBox.UseVisualStyleBackColor = true;
            this.onlineBox.CheckedChanged += new System.EventHandler(this.onlineBox_CheckedChanged);
            // 
            // flyersBox
            // 
            this.flyersBox.AutoSize = true;
            this.flyersBox.Location = new System.Drawing.Point(342, 199);
            this.flyersBox.Name = "flyersBox";
            this.flyersBox.Size = new System.Drawing.Size(75, 22);
            this.flyersBox.TabIndex = 8;
            this.flyersBox.Text = "Flyers";
            this.flyersBox.UseVisualStyleBackColor = true;
            this.flyersBox.CheckedChanged += new System.EventHandler(this.flyersBox_CheckedChanged);
            // 
            // bannerBox
            // 
            this.bannerBox.AutoSize = true;
            this.bannerBox.Location = new System.Drawing.Point(443, 199);
            this.bannerBox.Name = "bannerBox";
            this.bannerBox.Size = new System.Drawing.Size(84, 22);
            this.bannerBox.TabIndex = 9;
            this.bannerBox.Text = "Banner";
            this.bannerBox.UseVisualStyleBackColor = true;
            this.bannerBox.CheckedChanged += new System.EventHandler(this.bannerBox_CheckedChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 234);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(937, 336);
            this.dataGridView1.TabIndex = 10;
            // 
            // quantityBox
            // 
            this.quantityBox.Location = new System.Drawing.Point(217, 608);
            this.quantityBox.Name = "quantityBox";
            this.quantityBox.Size = new System.Drawing.Size(220, 27);
            this.quantityBox.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 611);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(160, 18);
            this.label5.TabIndex = 12;
            this.label5.Text = "Desired Quantity: ";
            // 
            // bookBtn
            // 
            this.bookBtn.Location = new System.Drawing.Point(825, 607);
            this.bookBtn.Name = "bookBtn";
            this.bookBtn.Size = new System.Drawing.Size(124, 32);
            this.bookBtn.TabIndex = 13;
            this.bookBtn.Text = "Book";
            this.bookBtn.UseVisualStyleBackColor = true;
            this.bookBtn.Click += new System.EventHandler(this.bookBtn_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Maroon;
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.backBtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(961, 84);
            this.panel1.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 16F);
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.Location = new System.Drawing.Point(733, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(216, 26);
            this.label6.TabIndex = 1;
            this.label6.Text = "ASEAN Skills 2020";
            // 
            // Book
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 649);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.bookBtn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.quantityBox);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.bannerBox);
            this.Controls.Add(this.flyersBox);
            this.Controls.Add(this.onlineBox);
            this.Controls.Add(this.budgetBox);
            this.Controls.Add(this.tierBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Book";
            this.Text = "Book";
            this.Load += new System.EventHandler(this.Book_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button backBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox tierBox;
        private System.Windows.Forms.TextBox budgetBox;
        private System.Windows.Forms.CheckBox onlineBox;
        private System.Windows.Forms.CheckBox flyersBox;
        private System.Windows.Forms.CheckBox bannerBox;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox quantityBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button bookBtn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
    }
}