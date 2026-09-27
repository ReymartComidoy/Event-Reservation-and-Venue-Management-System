using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using User = Event_Reservation_and_Venue_Management_System.Models.User;

namespace Event_Reservation_and_Venue_Management_System.Controls
{
    public partial class CheckAvailabilityView : UserControl, IClientUserContextAware
    {
        private User? _currentUser;
        private DataTable _schedulesTable = new DataTable();

        public CheckAvailabilityView()
        {
            InitializeComponent();
            InitializeVenues();
            InitializeScheduleData();
        }

        public void SetCurrentUser(User user)
        {
            _currentUser = user;
        }

        private void InitializeVenues()
        {
            cmbVenueSelect.Items.Clear();
            cmbVenueSelect.Items.Add("Tagum City Hall Atrium");
            cmbVenueSelect.Items.Add("Mankilam Cultural Center");
            cmbVenueSelect.Items.Add("Rotary Park Pavilion");
            cmbVenueSelect.Items.Add("Tagum Trade & Cultural Center");
            cmbVenueSelect.Items.Add("Energy Park Amphitheater");
            cmbVenueSelect.SelectedIndex = 0;

            dtpEventDate.Value = DateTime.Today;
        }

        private void InitializeScheduleData()
        {
            _schedulesTable.Columns.Clear();
            _schedulesTable.Columns.Add("TimeSlot", typeof(string));
            _schedulesTable.Columns.Add("Status", typeof(string));
            _schedulesTable.Columns.Add("Details", typeof(string));

            CheckAvailability();
        }

        private void CheckAvailability()
        {
            _schedulesTable.Rows.Clear();
            string selectedVenue = cmbVenueSelect.SelectedItem?.ToString() ?? "";
            DateTime selectedDate = dtpEventDate.Value.Date;

            // Mock logic: Simulate booked slots for demonstration
            if (selectedDate.DayOfWeek == DayOfWeek.Saturday)
            {
                _schedulesTable.Rows.Add("08:00 AM - 12:00 PM", "Booked", "Reserved for Government Summit");
                _schedulesTable.Rows.Add("01:00 PM - 05:00 PM", "Available", "Open for Booking");
                _schedulesTable.Rows.Add("06:00 PM - 10:00 PM", "Booked", "Reserved for Private Event");
            }
            else
            {
                _schedulesTable.Rows.Add("08:00 AM - 12:00 PM", "Available", "Open for Booking");
                _schedulesTable.Rows.Add("01:00 PM - 05:00 PM", "Available", "Open for Booking");
                _schedulesTable.Rows.Add("06:00 PM - 10:00 PM", "Available", "Open for Booking");
            }

            dgvAvailability.Rows.Clear();
            foreach (DataRow row in _schedulesTable.Rows)
            {
                dgvAvailability.Rows.Add(
                    row["TimeSlot"],
                    row["Status"],
                    row["Details"]
                );
            }

            lblStatusResult.Text = $"Showing schedule for {selectedVenue} on {selectedDate:MMMM dd, yyyy}";
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            CheckAvailability();
        }

        private void btnProceedReservation_Click(object sender, EventArgs e)
        {
            if (dgvAvailability.SelectedRows.Count > 0)
            {
                string status = dgvAvailability.SelectedRows[0].Cells["colStatus"].Value?.ToString() ?? "";
                string slot = dgvAvailability.SelectedRows[0].Cells["colTimeSlot"].Value?.ToString() ?? "";

                if (status == "Booked")
                {
                    MessageBox.Show("The selected time slot is already booked. Please choose an available time slot.", "Slot Unavailable", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show($"Proceeding to reserve {cmbVenueSelect.SelectedItem} for {dtpEventDate.Value:yyyy-MM-dd} ({slot}).", "Reservation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Please select a time slot from the schedule table.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}