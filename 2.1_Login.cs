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
    public partial class Login : Form
    {
        //Initial Commit
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            using (var context = new Session2Entities1())
            {

                //Checks if User ID field is empty
                if (userIDBox.Text.Trim() == "")
                {
                    MessageBox.Show("Please enter your User ID!", "Empty User ID",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //Checks if password field is empty
                else if (passwordBox.Text.Trim() == "")
                {
                    MessageBox.Show("Please enter your Password!", "Empty password",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    var getUser = (from x in context.Users
                                   where x.userId.Equals(userIDBox.Text)
                                   select x).FirstOrDefault();

                    //Check if User even exist in DB
                    if (getUser == null)
                    {
                        MessageBox.Show("User does not exist!", "Invalid Login details",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    //Check if entered password matches the intended account's password
                    else if (getUser.passwd != passwordBox.Text)
                    {
                        MessageBox.Show("Password is incorrect!", "Invalid Login details",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        var getUserType = getUser.userTypeIdFK;
                        var findManagerID = (from x in context.User_Type
                                             where x.userTypeName == "Manager"
                                             select x.userTypeId).First();

                        var findSponsorID = (from x in context.User_Type
                                             where x.userTypeName == "Sponsor"
                                             select x.userTypeId).First();

                        //Check if account type is "Manager" and redirect to the Manager's Main Menu - 2.4
                        if (getUser.userTypeIdFK == findManagerID)
                        {
                            MessageBox.Show($"Welcome {getUser.name}!", "Successful login",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Hide();
                            (new ManagerMain()).ShowDialog();
                            this.Close();
                        }

                        //Else redirect to Sponsor's Main Menu - 2.3
                        else
                        {
                            MessageBox.Show($"Welcome {getUser.name}!", "Successful login",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Hide();
                            (new SponsorMain(getUser.userId)).ShowDialog();
                            this.Close();
                        }
                    }
                }
            }
        }

        //Redirects user to Sponsor Account Creation page - 2.2
        private void createBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new NewAccount()).ShowDialog();
            this.Close();
        }
    }
}
