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
    public partial class ViewPackage : Form
    {
        public ViewPackage()
        {
            InitializeComponent();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new ManagerMain()).ShowDialog();
            this.Close();
        }

        private void ViewPackage_Load(object sender, EventArgs e)
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
                var getPackages = (from x in context.Packages
                                   join y in context.Benefits on x.packageId equals y.packageIdFK
                                   orderby x.packageValue descending
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

        private void tierBtn_CheckedChanged(object sender, EventArgs e)
        {
            using(var context = new Session2Entities1())
            {
                dataGridView1.Rows.Clear();
                if (tierBtn.Checked)
                {
                    
                    var getPackages = (from x in context.Packages
                                       join y in context.Benefits on x.packageId equals y.packageIdFK
                                       orderby x.packageTier descending
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
                else
                {
                    ViewPackage_Load(null, null);
                }
            
            }
        }

        private void nameButton_CheckedChanged(object sender, EventArgs e)
        {
            using (var context = new Session2Entities1())
            {
                dataGridView1.Rows.Clear();
                if (nameButton.Checked)
                {
                    var getPackages = (from x in context.Packages
                                       join y in context.Benefits on x.packageId equals y.packageIdFK
                                       orderby x.packageName descending
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
                else
                {
                    ViewPackage_Load(null, null);
                }
            
            }
        }

        private void valueBtn_CheckedChanged(object sender, EventArgs e)
        {
            using (var context = new Session2Entities1())
            {
                dataGridView1.Rows.Clear();
                if (valueBtn.Checked)
                {
                    var getPackages = (from x in context.Packages
                                       join y in context.Benefits on x.packageId equals y.packageIdFK
                                       orderby x.packageValue ascending
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
                else
                {
                    ViewPackage_Load(null, null);
                }
            }
        }

        private void quantityBtn_CheckedChanged(object sender, EventArgs e)
        {
            using (var context = new Session2Entities1())
            {
                dataGridView1.Rows.Clear();
                if (quantityBtn.Checked)
                {
                    var getPackages = (from x in context.Packages
                                       join y in context.Benefits on x.packageId equals y.packageIdFK
                                       orderby x.packageQuantity descending
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
                else
                {
                    var getPackages = (from x in context.Packages
                                       join y in context.Benefits on x.packageId equals y.packageIdFK
                                       orderby x.packageQuantity ascending
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
    }
}
