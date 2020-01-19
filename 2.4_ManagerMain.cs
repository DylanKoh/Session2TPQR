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
    public partial class ManagerMain : Form
    {
        public ManagerMain()
        {
            InitializeComponent();
        }

        //Redirects to Add Sponsorship Packages page - 2.8
        private void addPackageBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new AddPackage()).ShowDialog();
            this.Close();
        }

        //Redirects to View Sponsorship Packages page - 2.7
        private void viewPackageBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new ViewPackage()).ShowDialog();
            this.Close();
        }

        //Redirects back to Login page - 2.1
        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new Login()).ShowDialog();
            this.Close();
        }

        //Redirects tp Approve Sponsorship Bookings page - 2.9
        private void approveBookingsBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new ApproveBooking()).ShowDialog();
            this.Close();
        }

        //Redirects to View Sponshorship Packages Summary - 2.10
        private void viewBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new ViewSummary()).ShowDialog();
            this.Close();
        }
    }
}
