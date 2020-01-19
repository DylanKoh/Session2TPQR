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
    public partial class ViewSummary : Form
    {
        public ViewSummary()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Redirects user back to Manager Main Menu - 2.4
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new ManagerMain()).ShowDialog();
            this.Close();
        }

        private void ViewSummary_Load(object sender, EventArgs e)
        {
            #region Loading Tier Combo box for filtering
            cbTier.Items.Add("No Filter");
            using (var context = new Session2Entities1())
            {
                var getTiers = (from x in context.Packages
                                select x.packageTier);
                var tiers = new HashSet<string>();
                foreach (var item in getTiers)
                {
                    tiers.Add(item);
                }
                cbTier.Items.AddRange(tiers.ToArray());
            }
            #endregion

            //Loads initial Pie Chart with no filtering
            loadPie();
        }

        /// <summary>
        /// This method is responsible for loading details and data to Pie Chart, based on selected Tiers
        /// </summary>
        private void loadPie()
        {
            chart1.Series[0].Points.Clear();

            if (cbTier.SelectedItem != null && cbTier.SelectedItem.ToString() != "No Filter")
            {
                var selectedTier = cbTier.SelectedItem.ToString();
                using (var context = new Session2Entities1())
                {
                    var getPoints = (from x in context.Bookings
                                     where x.status == "Accepted"
                                     where x.Package.packageTier == selectedTier
                                     group new { amount = x.Package.packageValue * x.quantityBooked, quantityBooked = x.quantityBooked } by x.Package.packageName into q
                                     select new
                                     {
                                         Package = q.Key,
                                         Amount = q.Sum(y => y.amount),
                                         ApprovedQuantity = q.Sum(y => y.quantityBooked)
                                     });
                    var total = 0;
                    var List = new List<string>();
                    foreach (var item in getPoints)
                    {
                        var Idx = chart1.Series[0].Points.AddY(item.ApprovedQuantity);
                        chart1.Series[0].Points[Idx].AxisLabel = item.Package;
                        total += Convert.ToInt32(item.Amount);
                        List.Add(item.Package);

                    }
                    lblTotalValue.Text = total.ToString();




                }
            }
            else
            {
                using (var context = new Session2Entities1())
                {
                    var getPoints = (from x in context.Bookings
                                     where x.status == "Accepted"
                                     group new { amount = x.Package.packageValue * x.quantityBooked, quantityBooked = x.quantityBooked } by x.Package.packageName into q
                                     select new
                                     {
                                         Package = q.Key,
                                         Amount = q.Sum(y => y.amount),
                                         ApprovedQuantity = q.Sum(y => y.quantityBooked)
                                     });
                    var total = 0;
                    var List = new List<string>();
                    foreach (var item in getPoints)
                    {
                        var Idx = chart1.Series[0].Points.AddY(item.ApprovedQuantity);
                        chart1.Series[0].Points[Idx].AxisLabel = item.Package;
                        total += Convert.ToInt32(item.Amount);
                        List.Add(item.Package);

                    }
                    lblTotalValue.Text = total.ToString();




                }

            }

        }

        /// <summary>
        /// When a new Tier is selected, it reloads the Pie Chart again
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbTier_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadPie();
        }
    }

}


