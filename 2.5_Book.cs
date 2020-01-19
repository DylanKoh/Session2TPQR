using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Session2
{
    public partial class Book : Form
    {
        string _userID;
        public Book(string userID)
        {
            InitializeComponent();
            _userID = userID;
        }

        private void Book_Load(object sender, EventArgs e)
        {
            #region Populating Tier Combo box for filtering
            HashSet<string> Tiers = new HashSet<string>();
            tierBox.Items.Add("No Sorting");
            using (var context = new Session2Entities1())
            {
                var getTiers = (from x in context.Packages
                                select x.packageTier).Distinct();
                foreach (var item in getTiers)
                {
                    Tiers.Add(item);
                }
                tierBox.Items.AddRange(Tiers.ToArray());
            }
            #endregion

            //Initial DGV loading with no filter yet selected
            GridRefresh();
        }

        //Redirects User back to Sponsorship Main Menu page - 2.3
        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new SponsorMain(_userID)).ShowDialog();
            this.Close();
        }
        private void GridRefresh()
        {
            #region Main DGV settings and column additions
            dataGridView1.ReadOnly = true;
            dataGridView1.ColumnCount = 7;
            dataGridView1.Columns[0].Name = "Tier";
            dataGridView1.Columns[1].Name = "Name";
            dataGridView1.Columns[2].Name = "Value ($)";
            dataGridView1.Columns[3].Name = "Available Qty";
            dataGridView1.Columns[4].Name = "Online";
            dataGridView1.Columns[5].Name = "Flyers";
            dataGridView1.Columns[6].Name = "Banner";
            #endregion

            using (var context = new Session2Entities1())
            {
                if (tierBox.SelectedItem != null && tierBox.SelectedItem.ToString() != "No Sorting")
                {
                    var getSelectedTier = tierBox.SelectedItem.ToString();
                    var getPackages = (from x in context.Packages
                                       where x.packageQuantity > 0
                                       where x.packageTier == getSelectedTier
                                       select new { x });

                    //For every distinct package name...
                    foreach (var item in getPackages.Select(x => x.x.packageName).Distinct())
                    {
                        var getPackageInfo = (from x in context.Packages
                                              where x.packageName == item
                                              select x).First();
                        List<string> rows = new List<string>()
                            {
                                getPackageInfo.packageTier, getPackageInfo.packageName, getPackageInfo.packageValue.ToString(),
                                getPackageInfo.packageQuantity.ToString()
                            };

                        //Getting benefits of current queried package and putting all benefits to list
                        var getBenefits = (from x in context.Benefits
                                           where x.packageIdFK == getPackageInfo.packageId
                                           select x.benefitName).ToList();

                        ///Since Online Benefits comes first followed by Flyer then Banner.
                        ///getBenefits.FirstOrDefault to check if Online as a benefit exist, then check if the list contains
                        ///Flyer first, then Banner
                        if (getBenefits.FirstOrDefault() == "Online") rows.Add("Yes");
                        else rows.Add("");
                        if (getBenefits.Contains("Flyer")) rows.Add("Yes");
                        else rows.Add("");
                        if (getBenefits.Contains("Banner")) rows.Add("Yes");
                        else rows.Add("");
                        dataGridView1.Rows.Add(rows.ToArray());

                    }
                }

                else
                {
                    var getPackages = (from x in context.Packages
                                       where x.packageQuantity > 0
                                       select new { x });

                    //For every distinct package name...
                    foreach (var item in getPackages.Select(x => x.x.packageName).Distinct())
                    {
                        var getPackageInfo = (from x in context.Packages
                                              where x.packageName == item
                                              select x).First();
                        List<string> rows = new List<string>()
                            {
                                getPackageInfo.packageTier, getPackageInfo.packageName, getPackageInfo.packageValue.ToString(),
                                getPackageInfo.packageQuantity.ToString()
                            };

                        //Getting benefits of current queried package and putting all benefits to list
                        var getBenefits = (from x in context.Benefits
                                           where x.packageIdFK == getPackageInfo.packageId
                                           select x.benefitName).ToList();

                        ///Since Online Benefits comes first followed by Flyer then Banner.
                        ///getBenefits.FirstOrDefault to check if Online as a benefit exist, then check if the list contains
                        ///Flyer first, then Banner
                        if (getBenefits.FirstOrDefault() == "Online") rows.Add("Yes");
                        else rows.Add("");
                        if (getBenefits.Contains("Flyer")) rows.Add("Yes");
                        else rows.Add("");
                        if (getBenefits.Contains("Banner")) rows.Add("Yes");
                        else rows.Add("");
                        dataGridView1.Rows.Add(rows.ToArray());

                    }
                }




            }
        }

        /// <summary>
        /// Triggered when Online Checkbox is checked, then remove rows of irrelevant information that doesn't have Online as a benefit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void onlineBox_CheckedChanged(object sender, EventArgs e)
        {
            if (onlineBox.Checked)
            {
                var index = new List<DataGridViewRow>();
                foreach (DataGridViewRow item in dataGridView1.Rows)
                {
                    using (var context = new Session2Entities1())
                    {
                        var packageName = item.Cells[1].Value.ToString();
                        var checkBenefits = (from x in context.Packages
                                             where x.packageName == packageName
                                             select x.packageId).First();
                        var getBenefits = (from x in context.Benefits
                                           where x.packageIdFK == checkBenefits
                                           select x.benefitName).ToList();
                        if (getBenefits.Contains("Online")) continue;
                        else index.Add(item);
                    }

                }
                foreach (var item in index)
                {
                    dataGridView1.Rows.Remove(item);
                }
            }
            else if (!flyersBox.Checked && !bannerBox.Checked)
            {
                dataGridView1.Rows.Clear();
                GridRefresh();
            }

        }

        /// <summary>
        /// Triggered when Flyer Checkbox is checked, then remove rows of irrelevant information that doesn't have Online as a benefit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void flyersBox_CheckedChanged(object sender, EventArgs e)
        {
            if (flyersBox.Checked)
            {
                var index = new List<DataGridViewRow>();
                foreach (DataGridViewRow item in dataGridView1.Rows)
                {
                    using (var context = new Session2Entities1())
                    {
                        var packageName = item.Cells[1].Value.ToString();
                        var checkBenefits = (from x in context.Packages
                                             where x.packageName == packageName
                                             select x.packageId).First();
                        var getBenefits = (from x in context.Benefits
                                           where x.packageIdFK == checkBenefits
                                           select x.benefitName).ToList();
                        if (getBenefits.Contains("Flyer")) continue;
                        else index.Add(item);
                    }

                }
                foreach (var item in index)
                {
                    dataGridView1.Rows.Remove(item);
                }
            }
            else if (!onlineBox.Checked && !bannerBox.Checked)
            {
                dataGridView1.Rows.Clear();
                GridRefresh();
            }
        }

        /// <summary>
        /// Triggered when Banner Checkbox is checked, then remove rows of irrelevant information that doesn't have Online as a benefit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bannerBox_CheckedChanged(object sender, EventArgs e)
        {
            if (bannerBox.Checked)
            {
                var index = new List<DataGridViewRow>();
                foreach (DataGridViewRow item in dataGridView1.Rows)
                {
                    using (var context = new Session2Entities1())
                    {
                        var packageName = item.Cells[1].Value.ToString();
                        var checkBenefits = (from x in context.Packages
                                             where x.packageName == packageName
                                             select x.packageId).First();
                        var getBenefits = (from x in context.Benefits
                                           where x.packageIdFK == checkBenefits
                                           select x.benefitName).ToList();
                        if (getBenefits.Contains("Banner")) continue;
                        else index.Add(item);
                    }

                }
                foreach (var item in index)
                {
                    dataGridView1.Rows.Remove(item);
                }

            }
            else if (!flyersBox.Checked && !onlineBox.Checked)
            {
                dataGridView1.Rows.Clear();
                GridRefresh();
            }
        }

        /// <summary>
        /// Triggered when the Book button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bookBtn_Click(object sender, EventArgs e)
        {
            //Check if any row is selected at all
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Please select a package to book!",
                    "No Package selected", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                //Check if user keyed in any invalid amount of packages (0 or less)
                if (Int32.Parse(quantityBox.Text) <= 0)
                {
                    MessageBox.Show("Please key in a valid amount", "Invalid amount", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                var getValueAfterBooking = Convert.ToInt32(dataGridView1.CurrentRow.Cells[3].Value);

                //Check with DB if amount to book is available for the User
                if (getValueAfterBooking - Int32.Parse(quantityBox.Text) < 0)
                {
                    MessageBox.Show("Unable to book more than current available quantity!", "Invalid amount", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                else
                {
                    //Else, add details of booking to DB
                    using (var context = new Session2Entities1())
                    {
                        var packageName = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                        var getPackageID = (from x in context.Packages
                                            where x.packageName == packageName
                                            select x.packageId).FirstOrDefault();
                        context.Bookings.Add(new Booking()
                        {
                            packageIdFK = getPackageID,
                            userIdFK = _userID,
                            quantityBooked = Int32.Parse(quantityBox.Text),
                            status = "Pending"
                        });
                        context.SaveChanges();
                        dataGridView1.Rows.Clear();
                        GridRefresh();


                    }

                }


            }

        }

        /// <summary>
        /// Whenever User keys in an amount, filter through DGV to get relevant prices that suits budget
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void budgetBox_TextChanged(object sender, EventArgs e)
        {
            if (budgetBox.Text.Trim() != "")
            {
                dataGridView1.Rows.Clear();
                using (var context = new Session2Entities1())
                {
                    var getValue = Int32.Parse(budgetBox.Text);
                    var getRelevant = (from x in context.Packages
                                       where x.packageValue <= getValue
                                       where x.packageQuantity >= 0
                                       select x.packageName).Distinct();
                    foreach (var item in getRelevant)
                    {
                        var checkBenefits = (from x in context.Benefits
                                             where x.Package.packageName == item
                                             select x).FirstOrDefault();
                        if (checkBenefits != null)
                        {
                            var getPackages1 = (from x in context.Packages
                                                join y in context.Benefits on x.packageId equals y.packageIdFK
                                                where x.packageName == item
                                                select x).FirstOrDefault();
                            List<string> rows = new List<string>()
                        {
                            getPackages1.packageTier, getPackages1.packageName, getPackages1.packageValue.ToString(),
                            getPackages1.packageQuantity.ToString()
                        };
                            List<string> vs = new List<string>();
                            foreach (var item1 in getPackages1.Benefits.Where(x => x.packageIdFK == getPackages1.packageId).Select(x => x.benefitName))
                            {
                                vs.Add(item1);
                            }
                            if (vs[0] == "Online") rows.Add("Yes");
                            else rows.Add("");
                            if (vs.Contains("Flyer")) rows.Add("Yes");
                            else rows.Add("");
                            if (vs.Contains("Banner")) rows.Add("Yes");
                            else rows.Add("");

                            dataGridView1.Rows.Add(rows.ToArray());
                            if (onlineBox.Checked)
                            {
                                onlineBox_CheckedChanged(null, null);
                            }
                            else if (flyersBox.Checked)
                            {
                                flyersBox_CheckedChanged(null, null);
                            }
                            else if (bannerBox.Checked)
                            {
                                bannerBox_CheckedChanged(null, null);
                            }
                        }
                        else
                        {
                            var getPackages1 = (from x in context.Packages
                                                where x.packageName == item
                                                select x).FirstOrDefault();
                            List<string> rows = new List<string>()
                        {
                            getPackages1.packageTier, getPackages1.packageName, getPackages1.packageValue.ToString(),
                            getPackages1.packageQuantity.ToString()
                        };

                            rows.Add("");
                            rows.Add("");
                            rows.Add("");

                            dataGridView1.Rows.Add(rows.ToArray());
                            if (onlineBox.Checked)
                            {
                                onlineBox_CheckedChanged(null, null);
                            }
                            else if (flyersBox.Checked)
                            {
                                flyersBox_CheckedChanged(null, null);
                            }
                            else if (bannerBox.Checked)
                            {
                                bannerBox_CheckedChanged(null, null);
                            }
                        }

                    }
                }

            }
            else
            {
                dataGridView1.Rows.Clear();
                GridRefresh();
            }



        }

        /// <summary>
        /// Whenever a tier is selected, refresh the entire DGV by deleting and repopulating
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tierBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (onlineBox.Checked)
            {
                dataGridView1.Rows.Clear();
                GridRefresh();
                onlineBox_CheckedChanged(null, null);
            }
            else if (flyersBox.Checked)
            {
                dataGridView1.Rows.Clear();
                GridRefresh();
                flyersBox_CheckedChanged(null, null);
            }
            else if (bannerBox.Checked)
            {
                dataGridView1.Rows.Clear();
                GridRefresh();
                bannerBox_CheckedChanged(null, null);
            }
            else
            {
                dataGridView1.Rows.Clear();
                GridRefresh();
            }

        }
    }
}
