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

        private void addPackageBtn_Click(object sender, EventArgs e)
        {

        }

        private void viewPackageBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new ViewPackage()).ShowDialog();
            this.Close();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new Login()).ShowDialog();
            this.Close();
        }
    }
}
