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

        //Redirects User to Manager Main Menu - 2.4
        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new ManagerMain()).ShowDialog();
            this.Close();
        }

        /// <summary>
        /// Upon loading this form, load the default DGV layout and order of data of Sponsorship package
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                                   select new { x });
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

                    var getBenefits = (from x in context.Benefits
                                       where x.packageIdFK == getPackageInfo.packageId
                                       select x.benefitName).ToList();
                    
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

        //When the Default radio button is checked, refresh the DGV again
        private void defaultBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (defaultBtn.Checked)
            {
                dataGridView1.Rows.Clear();
                ViewPackage_Load(null, null);
            }

        }

        //When the Name radio button is checked, refresh the DGV again by ascending name order
        private void nameButton_CheckedChanged(object sender, EventArgs e)
        {
            if (nameButton.Checked)
            {
                dataGridView1.Rows.Clear();
                using (var context = new Session2Entities1())
                {
                    var getPackages = (from x in context.Packages
                                       orderby x.packageValue
                                       select x).ToList();

                    var results = getPackages.OrderByDescending(x => x.packageName).AsQueryable();
                    foreach (var item in results)
                    {
                        List<string> rows = new List<string>()
                            {
                                item.packageTier, item.packageName, item.packageValue.ToString(),
                                item.packageQuantity.ToString()
                            };

                        var getBenefits = (from x in context.Benefits
                                           where x.packageIdFK == item.packageId
                                           select x.benefitName).ToList();

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

        //When the Value radio button is checked, refresh the DGV again by ascending value of package order
        private void valueBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (valueBtn.Checked)
            {
                dataGridView1.Rows.Clear();
                using (var context = new Session2Entities1())
                {
                    var getPackages = (from x in context.Packages
                                       orderby x.packageValue
                                       select x ).ToList();

                    var results = getPackages.OrderBy(x => x.packageValue).AsQueryable();
                    foreach (var item in results)
                    {
                        List<string> rows = new List<string>()
                            {
                                item.packageTier, item.packageName, item.packageValue.ToString(),
                                item.packageQuantity.ToString()
                            };

                        var getBenefits = (from x in context.Benefits
                                           where x.packageIdFK == item.packageId
                                           select x.benefitName).ToList();

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

        //When the Quantity radio button is checked, refresh the DGV again by descending quantity of packages order
        private void quantityBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (quantityBtn.Checked)
            {
                dataGridView1.Rows.Clear();
                using (var context = new Session2Entities1())
                {
                    var getPackages = (from x in context.Packages
                                       orderby x.packageValue
                                       select x).ToList();

                    var results = getPackages.OrderByDescending(x => x.packageQuantity).AsQueryable();
                    foreach (var item in results)
                    {
                        List<string> rows = new List<string>()
                            {
                                item.packageTier, item.packageName, item.packageValue.ToString(),
                                item.packageQuantity.ToString()
                            };

                        var getBenefits = (from x in context.Benefits
                                           where x.packageIdFK == item.packageId
                                           select x.benefitName).ToList();

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

        //When the Tier radio button is checked, refresh the DGV again accord to Tier Gold, Silver then Bronze order
        private void tierBtn_CheckedChanged_1(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            var order = new Dictionary<string, int>() { { "Gold", 1},
                { "Silver", 2}, { "Bronze", 3} };
            using (var context = new Session2Entities1())
            {
                var getPackages = (from x in context.Packages
                                   select new { x }).ToList();

                var results = getPackages.OrderBy(x => order[x.x.packageTier]).AsQueryable();
                foreach (var item in results)
                {

                
                
                    List<string> rows = new List<string>()
                            {
                                item.x.packageTier, item.x.packageName, item.x.packageValue.ToString(),
                                item.x.packageQuantity.ToString()
                            };

                    var getBenefits = (from x in context.Benefits
                                       where x.packageIdFK == item.x.packageId
                                       select x.benefitName).ToList();

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
}
