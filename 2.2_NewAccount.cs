using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Session2
{
    public partial class NewAccount : Form
    {
        public NewAccount()
        {
            InitializeComponent();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new Login()).ShowDialog();
            this.Close();
        }

        private void createBtn_Click(object sender, EventArgs e)
        {
            if (companyNameBox.Text.Trim() == "")
            {
                MessageBox.Show("Company Name is required!", "Missing Company Name",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (userIDBox.TextLength < 8)
            {
                MessageBox.Show("User ID must have a minimum of 8 characters!", "User ID too short",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (passwordBox.Text.Trim() == "" || rePasswordBox.Text.Trim() == "")
            {
                MessageBox.Show("Please check your password fields!", "Empty password field(s)",
                   MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (rePasswordBox.Text != passwordBox.Text)
            {
                MessageBox.Show("Password does not match!", "Mismatched passwords",
                   MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                using (var context = new Session2Entities1())
                {
                    var checkForPossibleAccount = (from x in context.Users
                                                   where x.name == companyNameBox.Text.Trim()
                                                   select x).FirstOrDefault();
                    var checkUserID = (from x in context.Users
                                       where x.userId == userIDBox.Text
                                       select x).FirstOrDefault();
                    if (checkForPossibleAccount != null)
                    {
                        MessageBox.Show("Your current company already has a sponsor account!", "Unable to create an account",
                   MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (checkUserID != null)
                    {
                        MessageBox.Show("User ID has been used!", "Unable to create an account",
                   MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        context.Users.Add(new User()
                        {
                            name = companyNameBox.Text.Trim(),
                            passwd = passwordBox.Text,
                            userId = userIDBox.Text,
                            userTypeIdFK = 2
                        });
                        context.SaveChanges();
                        this.Hide();
                        (new Login()).ShowDialog();
                        this.Close();
                    }
                }
            }
        }
    }
}
