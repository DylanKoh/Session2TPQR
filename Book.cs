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
            GridRefresh();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new SponsorMain(_userID)).ShowDialog();
            this.Close();
        }
        private void GridRefresh()
        {
            dataGridView1.ColumnCount = 7;
            dataGridView1.Columns[0].Name = "Tier";
            dataGridView1.Columns[1].Name = "Name";
            dataGridView1.Columns[2].Name = "Value ($)";
            dataGridView1.Columns[3].Name = "Available Qty";
            dataGridView1.Columns[4].Name = "Online";
            dataGridView1.Columns[5].Name = "Flyers";
            dataGridView1.Columns[6].Name = "Banner";
            using (var context = new Session2Entities1())
            {
                if (onlineBox.Checked)
                {
                    var getPackages = (from x in context.Packages
                                       join y in context.Benefits on x.packageId equals y.packageIdFK
                                       where y.benefitName == "Online"
                                       select new { x, y });
                    if (flyersBox.Checked)
                    {
                        var getPackages1 = (from x in getPackages
                                            where x.y.benefitName == "Flyer"
                                            select x);

                        if (bannerBox.Checked)
                        {
                            var getPackages2 = (from x in getPackages1
                                                where x.y.benefitName == "Banner"
                                                select x);
                            foreach (var item in getPackages2.Select(x => x.x.packageName).Distinct())
                            {
                                var getPackages3 = (from x in context.Packages
                                                    join y in context.Benefits on x.packageId equals y.packageIdFK
                                                    where x.packageName == item
                                                    select x).FirstOrDefault();
                                List<string> rows = new List<string>()
                                {
                                    getPackages3.packageTier, getPackages3.packageName, getPackages3.packageValue.ToString(),
                                    getPackages3.packageQuantity.ToString()
                                };
                                List<string> vs = new List<string>();
                                foreach (var item1 in getPackages3.Benefits.Where(x => x.packageIdFK == getPackages3.packageId).Select(x => x.benefitName))
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
                            }
                        }
                        foreach (var item in getPackages1.Select(x => x.x.packageName).Distinct())
                        {
                            var getPackages2 = (from x in context.Packages
                                                join y in context.Benefits on x.packageId equals y.packageIdFK
                                                where x.packageName == item
                                                select x).FirstOrDefault();
                            List<string> rows = new List<string>()
                            {
                                getPackages2.packageTier, getPackages2.packageName, getPackages2.packageValue.ToString(),
                                getPackages2.packageQuantity.ToString()
                            };
                            List<string> vs = new List<string>();
                            foreach (var item1 in getPackages2.Benefits.Where(x => x.packageIdFK == getPackages2.packageId).Select(x => x.benefitName))
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

                        }
                    }
                    foreach (var item in getPackages.Select(x => x.x.packageName).Distinct())
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
                    }
                }

                else if (flyersBox.Checked)
                {
                    var getPackages = (from x in context.Packages
                                       join y in context.Benefits on x.packageId equals y.packageIdFK
                                       where y.benefitName == "Flyer"
                                       select new { x, y });
                    if (onlineBox.Checked)
                    {
                        var getPackages1 = (from x in getPackages
                                            where x.y.benefitName == "Online"
                                            select x);

                        if (bannerBox.Checked)
                        {
                            var getPackages2 = (from x in getPackages1
                                                where x.y.benefitName == "Banner"
                                                select x);
                            foreach (var item in getPackages2.Select(x => x.x.packageName).Distinct())
                            {
                                var getPackages3 = (from x in context.Packages
                                                    join y in context.Benefits on x.packageId equals y.packageIdFK
                                                    where x.packageName == item
                                                    select x).FirstOrDefault();
                                List<string> rows = new List<string>()
                                {
                                    getPackages3.packageTier, getPackages3.packageName, getPackages3.packageValue.ToString(),
                                    getPackages3.packageQuantity.ToString()
                                };
                                List<string> vs = new List<string>();
                                foreach (var item1 in getPackages3.Benefits.Where(x => x.packageIdFK == getPackages3.packageId).Select(x => x.benefitName))
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
                            }
                        }
                        foreach (var item in getPackages1.Select(x => x.x.packageName).Distinct())
                        {
                            var getPackages2 = (from x in context.Packages
                                                join y in context.Benefits on x.packageId equals y.packageIdFK
                                                where x.packageName == item
                                                select x).FirstOrDefault();
                            List<string> rows = new List<string>()
                            {
                                getPackages2.packageTier, getPackages2.packageName, getPackages2.packageValue.ToString(),
                                getPackages2.packageQuantity.ToString()
                            };
                            List<string> vs = new List<string>();
                            foreach (var item1 in getPackages2.Benefits.Where(x => x.packageIdFK == getPackages2.packageId).Select(x => x.benefitName))
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
                        }
                    }
                    foreach (var item in getPackages.Select(x => x.x.packageName).Distinct())
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
                    }
                }
                else if (bannerBox.Checked)
                {
                    var getPackages = (from x in context.Packages
                                       join y in context.Benefits on x.packageId equals y.packageIdFK
                                       where y.benefitName == "Banner"
                                       select new { x, y });
                    if (flyersBox.Checked)
                    {
                        var getPackages1 = (from x in getPackages
                                            where x.y.benefitName == "Flyer"
                                            select x);

                        if (onlineBox.Checked)
                        {
                            var getPackages2 = (from x in getPackages1
                                                where x.y.benefitName == "Online"
                                                select x);
                            foreach (var item in getPackages2)
                            {
                                List<string> rows = new List<string>()
                                {
                                    item.x.packageTier, item.x.packageName, item.x.packageValue.ToString(),
                                    item.x.packageQuantity.ToString()
                                };
                                if (item.y.benefitName == "Online") rows.Add("Yes");
                                else rows.Add("");
                                if (item.y.benefitName == "Flyer") rows.Add("Yes");
                                else rows.Add("");
                                if (item.y.benefitName == "Banner") rows.Add("Yes");
                                else rows.Add("");
                                dataGridView1.Rows.Add(rows.ToArray());
                            }
                        }
                        foreach (var item in getPackages1)
                        {
                            List<string> rows = new List<string>()
                            {
                                item.x.packageTier, item.x.packageName, item.x.packageValue.ToString(),
                                item.x.packageQuantity.ToString()
                            };
                            if (item.y.benefitName == "Online") rows.Add("Yes");
                            else rows.Add("");
                            if (item.y.benefitName == "Flyer") rows.Add("Yes");
                            else rows.Add("");
                            if (item.y.benefitName == "Banner") rows.Add("Yes");
                            else rows.Add("");
                            dataGridView1.Rows.Add(rows.ToArray());
                        }
                    }
                    foreach (var item in getPackages.Select(x => x.x.packageName).Distinct())
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
                    }
                }
                else
                {
                    var getPackages = (from x in context.Packages
                                       join y in context.Benefits on x.packageId equals y.packageIdFK
                                       select new { x, y });
                    foreach (var item in getPackages.Select(x => x.x.packageName).Distinct())
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
                    }
                }

            }
        }

        private void onlineBox_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            GridRefresh();
        }

        private void flyersBox_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            GridRefresh();
        }

        private void bannerBox_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            GridRefresh();
        }

        private void bookBtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Please select a package to book!",
                    "No Package selected", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (Int32.Parse(quantityBox.Text) <= 0)
                {
                    MessageBox.Show("Please key in a valid amount", "Invalid amount", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                var getValueAfterBooking = Convert.ToInt32(dataGridView1.CurrentRow.Cells[3].Value);

                if (getValueAfterBooking - Int32.Parse(quantityBox.Text) < 0)
                {
                    MessageBox.Show("unable to book more than current quantity!", "Invalid amount", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                else
                {
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
                        var updateQuantity = (from x in context.Packages
                                              where x.packageId == getPackageID
                                              select x).FirstOrDefault();

                        updateQuantity.packageQuantity -= Int32.Parse(quantityBox.Text);
                        context.SaveChanges();
                        dataGridView1.Rows.Clear();
                        GridRefresh();


                    }

                }


            }

        }

        private void budgetBox_TextChanged(object sender, EventArgs e)
        {
            using (var context = new Session2Entities1())
            {
                var getValue = Int32.Parse(budgetBox.Text);
                var getRelevent = (from x in context.Packages
                                   where x.packageValue <= getValue
                                   join y in context.Benefits on x.packageId equals y.packageIdFK
                                   select new { x, y });
                dataGridView1.Rows.Clear();
                foreach (var item in getRelevent.Select(x => x.x.packageName).Distinct())
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
                }
            }
            
        }
    }
}
