﻿namespace Session2
{
    partial class ViewPackage
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
            this.defaultBtn = new System.Windows.Forms.RadioButton();
            this.nameButton = new System.Windows.Forms.RadioButton();
            this.valueBtn = new System.Windows.Forms.RadioButton();
            this.quantityBtn = new System.Windows.Forms.RadioButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.tierBtn = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // backBtn
            // 
            this.backBtn.Location = new System.Drawing.Point(12, 12);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(125, 52);
            this.backBtn.TabIndex = 0;
            this.backBtn.Text = "Back";
            this.backBtn.UseVisualStyleBackColor = true;
            this.backBtn.Click += new System.EventHandler(this.backBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(309, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(332, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "View Sponsor Packages";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Sort By:";
            // 
            // defaultBtn
            // 
            this.defaultBtn.AutoSize = true;
            this.defaultBtn.Location = new System.Drawing.Point(145, 140);
            this.defaultBtn.Name = "defaultBtn";
            this.defaultBtn.Size = new System.Drawing.Size(106, 29);
            this.defaultBtn.TabIndex = 3;
            this.defaultBtn.TabStop = true;
            this.defaultBtn.Text = "Default";
            this.defaultBtn.UseVisualStyleBackColor = true;
            this.defaultBtn.CheckedChanged += new System.EventHandler(this.defaultBtn_CheckedChanged);
            // 
            // nameButton
            // 
            this.nameButton.AutoSize = true;
            this.nameButton.Location = new System.Drawing.Point(335, 140);
            this.nameButton.Name = "nameButton";
            this.nameButton.Size = new System.Drawing.Size(91, 29);
            this.nameButton.TabIndex = 4;
            this.nameButton.TabStop = true;
            this.nameButton.Text = "Name";
            this.nameButton.UseVisualStyleBackColor = true;
            this.nameButton.CheckedChanged += new System.EventHandler(this.nameButton_CheckedChanged);
            // 
            // valueBtn
            // 
            this.valueBtn.AutoSize = true;
            this.valueBtn.Location = new System.Drawing.Point(432, 140);
            this.valueBtn.Name = "valueBtn";
            this.valueBtn.Size = new System.Drawing.Size(216, 29);
            this.valueBtn.TabIndex = 5;
            this.valueBtn.TabStop = true;
            this.valueBtn.Text = "Value (Ascending)";
            this.valueBtn.UseVisualStyleBackColor = true;
            this.valueBtn.CheckedChanged += new System.EventHandler(this.valueBtn_CheckedChanged);
            // 
            // quantityBtn
            // 
            this.quantityBtn.AutoSize = true;
            this.quantityBtn.Location = new System.Drawing.Point(654, 140);
            this.quantityBtn.Name = "quantityBtn";
            this.quantityBtn.Size = new System.Drawing.Size(261, 29);
            this.quantityBtn.TabIndex = 6;
            this.quantityBtn.TabStop = true;
            this.quantityBtn.Text = "Quantity (Descending)";
            this.quantityBtn.UseVisualStyleBackColor = true;
            this.quantityBtn.CheckedChanged += new System.EventHandler(this.quantityBtn_CheckedChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 190);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(924, 340);
            this.dataGridView1.TabIndex = 7;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Maroon;
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.backBtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(948, 79);
            this.panel1.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 16F);
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.Location = new System.Drawing.Point(660, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(263, 32);
            this.label6.TabIndex = 1;
            this.label6.Text = "ASEAN Skills 2020";
            // 
            // tierBtn
            // 
            this.tierBtn.AutoSize = true;
            this.tierBtn.Location = new System.Drawing.Point(257, 140);
            this.tierBtn.Name = "tierBtn";
            this.tierBtn.Size = new System.Drawing.Size(72, 29);
            this.tierBtn.TabIndex = 15;
            this.tierBtn.TabStop = true;
            this.tierBtn.Text = "Tier";
            this.tierBtn.UseVisualStyleBackColor = true;
            this.tierBtn.CheckedChanged += new System.EventHandler(this.tierBtn_CheckedChanged_1);
            // 
            // ViewPackage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 542);
            this.Controls.Add(this.tierBtn);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.quantityBtn);
            this.Controls.Add(this.valueBtn);
            this.Controls.Add(this.nameButton);
            this.Controls.Add(this.defaultBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "ViewPackage";
            this.Text = "View Packages";
            this.Load += new System.EventHandler(this.ViewPackage_Load);
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
        private System.Windows.Forms.RadioButton defaultBtn;
        private System.Windows.Forms.RadioButton nameButton;
        private System.Windows.Forms.RadioButton valueBtn;
        private System.Windows.Forms.RadioButton quantityBtn;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton tierBtn;
    }
}