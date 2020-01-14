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
    public partial class Update : Form
    {
        string _userID;
        public Update(string userID)
        {
            InitializeComponent();
            _userID = userID;
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new SponsorMain(_userID)).ShowDialog();
            this.Close();
        }

        private void Update_Load(object sender, EventArgs e)
        {
            GridRefresh();
            var total = 0;
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                total += Convert.ToInt32(item.Cells[4].Value);

            }
            totalLbl.Text += total.ToString();
        }

        private void GridRefresh()
        {
            dataGridView1.ColumnCount = 6;
            dataGridView1.Columns[0].Name = "Tier";
            dataGridView1.Columns[1].Name = "Name";
            dataGridView1.Columns[2].Name = "Individual Value ($)";
            dataGridView1.Columns[3].Name = "Quantity Booked";
            dataGridView1.Columns[4].Name = "Sub-Total Value ($)";
            dataGridView1.Columns[5].Name = "Booking ID";
            dataGridView1.Columns[5].Visible = false;

            using (var context = new Session2Entities1())
            {
                var getBookings = (from x in context.Bookings
                                   where x.userIdFK == _userID
                                   where x.status == "Approved"
                                   select x);
                foreach (var item in getBookings)
                {
                    List<string> rows = new List<string>()
                    {
                        item.Package.packageTier, item.Package.packageName,
                        item.Package.packageValue.ToString(), item.quantityBooked.ToString(),
                        (item.quantityBooked * item.Package.packageValue).ToString(), item.bookingId.ToString()
                    };
                    dataGridView1.Rows.Add(rows.ToArray());

                }

            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Please select a booking to delete!", "No booking selected",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var dl = MessageBox.Show("Are you sure you want to delete this booking?", "Delete",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (DialogResult.Yes == dl)
                {
                    var getBookingId = Convert.ToInt32(dataGridView1.CurrentRow.Cells[5].Value);
                    var getQuantity = Convert.ToInt32(dataGridView1.CurrentRow.Cells[3].Value);
                    var getPackageName = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    using (var context = new Session2Entities1())
                    {
                        var getBookingToDelete = (from x in context.Bookings
                                                  where x.bookingId == getBookingId
                                                  select x).First();
                        var updatePackage = (from x in context.Packages
                                             where x.packageName == getPackageName
                                             select x).First();
                        updatePackage.packageQuantity += getQuantity;
                        context.SaveChanges();
                        context.Bookings.Remove(getBookingToDelete);
                        dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
                        context.SaveChanges();

                    }
                }


            }
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            if (Int32.Parse(quantityBox.Text) <= 0)
            {
                MessageBox.Show("Quantity cannot be less than or equals to 0!", "Invalid Amount!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                using (var context = new Session2Entities1())
                {
                    foreach (DataGridViewRow item in dataGridView1.SelectedRows)
                    {
                        var getBookingId = Convert.ToInt32(item.Cells[5].Value);
                        var checkPackage = (from x in context.Bookings
                                            where x.bookingId == getBookingId
                                            join y in context.Packages on x.packageIdFK equals y.packageId
                                            select y.packageQuantity).First();

                        if ((checkPackage - Int32.Parse(quantityBox.Text)) < 0)
                        {
                            MessageBox.Show("Cannot update quantity as Package quantity will hit negative!",
                                "Not enough packages", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            var UpdateBooking = (from x in context.Bookings
                                                 where x.bookingId == getBookingId
                                                 select x).First();
                            UpdateBooking.quantityBooked = Int32.Parse(quantityBox.Text);
                            UpdateBooking.status = "Pending";
                            context.SaveChanges();
                        }
                        dataGridView1.Rows.Clear();
                        GridRefresh();
                    }
                }
            }
        }
    }
}
