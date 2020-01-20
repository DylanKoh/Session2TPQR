using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Session2
{
    public partial class AddPackage : Form
    {
        List<string> _list = new List<string>();
        public AddPackage()
        {
            InitializeComponent();
        }

        //Redirects user back to Manager Main Menu - 2.4
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new ManagerMain()).ShowDialog();
            this.Close();
        }

        private void AddPackage_Load(object sender, EventArgs e)
        {
            using (var context = new Session2Entities1())
            {
                #region Populating the Tier Combo box
                var getTier = (from x in context.Packages
                               select x.packageTier);
                var tiers = new HashSet<string>();
                foreach (var item in getTier)
                {
                    tiers.Add(item);
                }
                cbTier.Items.AddRange(tiers.ToArray());
                #endregion

                #region Populating the Benefits Checklist Box
                var getBenefits = (from x in context.Benefits
                                   select x.benefitName);
                var benefits = new HashSet<string>();
                foreach (var item in getBenefits)
                {
                    benefits.Add(item);
                }
                clbBenefits.Items.AddRange(benefits.ToArray());
                #endregion
            }
        }

        /// <summary>
        /// When clicked, it will clear all previous entrys on the form and reloads in fresh empty data from DB
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            cbTier.Items.Clear();
            clbBenefits.Items.Clear();
            AddPackage_Load(null, null);
            txtPackageName.Text = "";
            txtValue.Text = "";
            txtAvailabeQuantity.Text = "";
            txtFilePath.Text = "";
        }

        /// <summary>
        /// When clicked, opens File Dialog for user to choose a csv file to import
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtFilePath_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Filter = "csv|*csv",
                InitialDirectory = "C:",
                Title = "Select CSV file to upload"
            };
            var results = openFileDialog.ShowDialog();
            if (results == DialogResult.OK)
            {
                txtFilePath.Text = openFileDialog.FileName;
            }
        }

        /// <summary>
        /// Whenever an item is checked or unchecked, it is added or removed from the global list created respectively.
        /// The lis is referenced for saving to DB later on.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clbBenefits_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            var item = clbBenefits.SelectedItem.ToString();
            if (e.NewValue == CheckState.Checked)
            {
                _list.Add(item);
            }
            else
            {
                _list.Remove(item);
            }
        }

        /// <summary>
        /// When clicked, runs the appropiate VadChecks like empty fields,
        /// invalid data entry, checking with DB to make sure no duplicates. When all VadChecks are passed,
        /// then add the new package(s) to DB
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPackageName.Text.Trim() == "" || txtValue.Text.Trim() == "" || txtAvailabeQuantity.Text.Trim() == "" || cbTier.SelectedItem == null)
                {
                    MessageBox.Show("Please check your entries!", "Empty Field(s)", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
                else
                {
                    using (var context = new Session2Entities1())
                    {
                        var checkName = (from x in context.Packages
                                         where x.packageName == txtPackageName.Text
                                         select x).FirstOrDefault();
                        if (checkName != null)
                        {
                            MessageBox.Show("Package name has been used!", "Used Package Name", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                        }
                        else
                        {
                            if (cbTier.SelectedItem.ToString() == "Bronze" && (Int32.Parse(txtValue.Text) > 10000 || Int32.Parse(txtValue.Text) <= 0))
                            {
                                MessageBox.Show("Invalid value for Bronze Tier! Valid value ranges from > $0 and less than or equals to $10,000", "Invalid Value for Package Tier", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                            }
                            else if (cbTier.SelectedItem.ToString() == "Silver" && (Int32.Parse(txtValue.Text) <= 10000 || Int32.Parse(txtValue.Text) > 50000 || Int32.Parse(txtValue.Text) <= 0))
                            {
                                MessageBox.Show("Invalid value for Silver Tier! Valid value ranges from > $10,000 and less than or equals to $50,000", "Invalid Value for Package Tier", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                            }
                            else if (cbTier.SelectedItem.ToString() == "Gold" && (Int32.Parse(txtValue.Text) <= 50000 || Int32.Parse(txtValue.Text) <= 0))
                            {
                                MessageBox.Show("Invalid value for Gold Tier! Valid value ranges from > $50,000", "Invalid Value for Package Tier", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                            }
                            else if (Int32.Parse(txtAvailabeQuantity.Text) <= 0)
                            {
                                MessageBox.Show("Package quantity must be more than 0!", "Invalid amount", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                            }
                            else if (cbTier.SelectedItem.ToString() == "Bronze" && clbBenefits.CheckedItems.Count != 1)
                            {
                                MessageBox.Show("Bronze Tier packages should have only 1 benefit!", "Invalid number of benefits",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else if (cbTier.SelectedItem.ToString() == "Silver" && clbBenefits.CheckedItems.Count != 2)
                            {
                                MessageBox.Show("Silver Tier packages should have only 2 benefits!", "Invalid number of benefits",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else if (cbTier.SelectedItem.ToString() == "Gold" && clbBenefits.CheckedItems.Count != 3)
                            {
                                MessageBox.Show("Gold Tier packages should have only 3 benefits!", "Invalid number of benefits",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                var getNewID = (from x in context.Packages
                                                orderby x.packageId descending
                                                select x.packageId).First() + 1;
                                context.Packages.Add(new Package()
                                {
                                    packageId = getNewID,
                                    packageName = txtPackageName.Text,
                                    packageTier = cbTier.SelectedItem.ToString(),
                                    packageQuantity = Int32.Parse(txtAvailabeQuantity.Text),
                                    packageValue = Int32.Parse(txtValue.Text)
                                });
                                foreach (var item in _list)
                                {
                                    context.Benefits.Add(new Benefit()
                                    {
                                        packageIdFK = getNewID,
                                        benefitName = item
                                    });
                                }
                                context.SaveChanges();
                                MessageBox.Show("Package has been added successfully!", "Successful addition of package",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Hide();
                                (new ManagerMain()).ShowDialog();
                                this.Close();
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Please check your entries!", "Invalid input detected", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                
            }
            
            
        }

        /// <summary>
        /// When clicked, reads CSV file and relatively assign them to DB in the correct
        /// fields. Also checks if Package exist. If it does, it will skip the package and go on to the next
        /// record in the CSV file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpload_Click(object sender, EventArgs e)
        {
            if (txtFilePath.Text.Trim() != "")
            {
                string[] lines = File.ReadAllLines(txtFilePath.Text);
                for (int i = 1; i < lines.Count(); i++)
                {
                    var values = lines[i].Split(',');
                    using (var context = new Session2Entities1())
                    {
                        var name = values[0];
                        var checkIfExist = (from x in context.Packages
                                            where x.packageName == name
                                            select x).FirstOrDefault();
                        if (checkIfExist != null)
                        {
                            context.Packages.Add(new Package()
                            {
                                packageTier = values[0],
                                packageName = values[1],
                                packageValue = Int32.Parse(values[2]),
                                packageQuantity = Int32.Parse(values[3])
                            });
                            context.SaveChanges();
                            MessageBox.Show("Packages added!", "Successful upload",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtFilePath.Text = "";
                        }
                        else
                        {
                            continue;
                        }
                        
                    }
                }
            }
            else
            {
                MessageBox.Show("Please input a file path!", "No file detected",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}
