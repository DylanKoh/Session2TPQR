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
    public partial class SponsorMain : Form
    {
        string _userID;
        public SponsorMain(string userID)
        {
            InitializeComponent();
            _userID = userID;
        }

        private void bookBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new Book(_userID)).ShowDialog();
            this.Close();
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new Update(_userID)).ShowDialog();
            this.Close();
        }
    }
}
