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
    public partial class ApproveBooking : Form
    {
        public ApproveBooking()
        {
            InitializeComponent();
        }

        private void ApproveBooking_Load(object sender, EventArgs e)
        {
            GridRefresh();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new ManagerMain()).ShowDialog();
            this.Close();
        }
        private void GridRefresh()
        {
            dataGridView1.ReadOnly = true;
            dataGridView1.ColumnCount = 4;
            dataGridView1.Columns[0].Name = "Company Name";
            dataGridView1.Columns[1].Name = "Package Name";
            dataGridView1.Columns[2].Name = "Status";
            dataGridView1.Columns[3].Name = "Booking ID";
            dataGridView1.Columns[3].Visible = false;
            using (var context = new Session2Entities1())
            {
                var sort = new Dictionary<string, int>()
                {
                    {"Pending", 1 }, {"Accepted", 2}, {"Rejected", 3}
                };
                var getRows = (from x in context.Bookings
                               orderby x.User.name
                               select x).ToList();
                var results = getRows.OrderBy(x => sort[x.status]).AsQueryable();
                foreach (var item in results)
                {
                    var rows = new List<string>()
                    {
                        item.User.name, item.Package.packageName, item.status, item.bookingId.ToString()
                    };
                    dataGridView1.Rows.Add(rows.ToArray());
                }
            }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select at least one row", "No rows selected",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                foreach (DataGridViewRow item in dataGridView1.SelectedRows)
                {
                    var getBookingID = Convert.ToInt32(item.Cells[3].Value);
                    using (var context = new Session2Entities1())
                    {
                        var getUpdate = (from x in context.Bookings
                                         where x.bookingId == getBookingID
                                         select x).First();

                        var checkQuantity = (from x in context.Bookings
                                             where x.bookingId == getBookingID
                                             join y in context.Packages on x.packageIdFK equals y.packageId
                                             select y).First();

                        if ((checkQuantity.packageQuantity - getUpdate.quantityBooked) < 0)
                        {
                            MessageBox.Show($"{checkQuantity.packageName} amount will be negative if this is approved!",
                                "Unable to approve", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            checkQuantity.packageQuantity -= getUpdate.quantityBooked;
                            getUpdate.status = "Accepted";
                            context.SaveChanges();
                            
                        }
                    }
                }
                dataGridView1.Rows.Clear();
                GridRefresh();
            }
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select at least one row", "No rows selected",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                foreach (DataGridViewRow item in dataGridView1.SelectedRows)
                {
                    var getBookingID = Convert.ToInt32(item.Cells[3].Value);
                    using (var context = new Session2Entities1())
                    {
                        var getBooking = (from x in context.Bookings
                                          where x.bookingId == getBookingID
                                          select x).First();
                        var dl = MessageBox.Show("Are you sure you want to reject the booking(s)?", "Reject",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        if (dl == DialogResult.Yes)
                        {
                            getBooking.status = "Rejected";
                            context.SaveChanges();
                        }
                    }
                }
                dataGridView1.Rows.Clear();
                GridRefresh();
            }
        }
    }
}
