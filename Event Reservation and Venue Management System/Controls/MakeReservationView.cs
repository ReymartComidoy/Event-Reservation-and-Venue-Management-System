using System;
using System.Windows.Forms;
using User = Event_Reservation_and_Venue_Management_System.Models.User;
using Event_Reservation_and_Venue_Management_System.Services;
using Event_Reservation_and_Venue_Management_System.DbContext;
using Microsoft.Data.SqlClient;

namespace Event_Reservation_and_Venue_Management_System.Controls
{
    public partial class MakeReservationView : UserControl, IClientUserContextAware
    {
        private User? _currentUser;
        private readonly VenueService _venueService = new();
        private readonly ReservationService _reservationService = new();
        private System.Data.DataTable _venues = new();

        public MakeReservationView()
        {
            InitializeComponent();
            InitializeFormDefaults();
        }

        public void SetCurrentUser(User user)
        {
            _currentUser = user;
            LoadVenuesList();
        }

        private void InitializeFormDefaults()
        {
            cmbTimeSlot.Items.Clear();
            cmbTimeSlot.Items.Add("Morning (08:00 AM - 12:00 PM)");
            cmbTimeSlot.Items.Add("Afternoon (01:00 PM - 05:00 PM)");
            cmbTimeSlot.Items.Add("Evening (06:00 PM - 10:00 PM)");
            cmbTimeSlot.Items.Add("Full Day (08:00 AM - 05:00 PM)");

            dtpReservationDate.MinDate = DateTime.Today.AddDays(1);
            dtpReservationDate.Value = DateTime.Today.AddDays(1);

            lblTotalFeeVal.Text = "₱ 0.00";
        }

        public void LoadVenuesList()
        {
            cmbVenue.Items.Clear();
            try
            {
                _venues = _venueService.GetAll();
                foreach (System.Data.DataRow row in _venues.Rows)
                {
                    if (string.Equals(row["Status"].ToString(), "Available", StringComparison.OrdinalIgnoreCase))
                        cmbVenue.Items.Add(row["VenueName"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unable to load venues.\n\n{ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (cmbVenue.Items.Count > 0)
                cmbVenue.SelectedIndex = 0;
        }

        private void CalculateTotal()
        {
            if (cmbVenue.SelectedItem == null)
            {
                lblTotalFeeVal.Text = "₱ 0.00";
                return;
            }

            System.Data.DataRow? venue = _venues.Rows.Cast<System.Data.DataRow>()
                .FirstOrDefault(row => string.Equals(row["VenueName"].ToString(), cmbVenue.SelectedItem?.ToString(), StringComparison.OrdinalIgnoreCase));
            decimal hourlyRate = venue == null ? 0 : Convert.ToDecimal(venue["PricePerHour"]);
            decimal total = hourlyRate;
            lblTotalFeeVal.Text = $"₱ {total:N2}";
        }

        private void cmbVenue_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalculateTotal();
        }

        private void cmbTimeSlot_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalculateTotal();
        }

        private void btnSubmitReservation_Click(object sender, EventArgs e)
        {
            if (cmbVenue.SelectedItem == null)
            {
                MessageBox.Show("Please select a venue.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtEventTitle.Text))
            {
                MessageBox.Show("Please enter an Event Title / Description.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEventTitle.Focus();
                return;
            }

            if (_currentUser == null)
                return;

            System.Data.DataRow? venue = _venues.Rows.Cast<System.Data.DataRow>()
                .FirstOrDefault(row => string.Equals(row["VenueName"].ToString(), cmbVenue.SelectedItem?.ToString(), StringComparison.OrdinalIgnoreCase));
            if (venue == null)
                return;

            try
            {
                _reservationService.Save(_currentUser.Id, Convert.ToInt32(venue["Id"]), txtEventTitle.Text.Trim(),
                    dtpReservationDate.Value, cmbTimeSlot.SelectedItem?.ToString() ?? "", (int)numGuestCount.Value,
                    txtSpecialRequests.Text.Trim(), Convert.ToDecimal(venue["PricePerHour"]));
                MessageBox.Show("Reservation submitted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnClear_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unable to submit reservation.\n\n{ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtEventTitle.Clear();
            txtSpecialRequests.Clear();
            numGuestCount.Value = 1;
            if (cmbVenue.Items.Count > 0) cmbVenue.SelectedIndex = 0;
            if (cmbTimeSlot.Items.Count > 0) cmbTimeSlot.SelectedIndex = 0;
            dtpReservationDate.Value = DateTime.Today.AddDays(1);
            lblTotalFeeVal.Text = "₱ 0.00";
        }
    }
}