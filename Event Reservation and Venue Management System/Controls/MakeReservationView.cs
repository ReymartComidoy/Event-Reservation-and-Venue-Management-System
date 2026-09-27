using System;
using System.Windows.Forms;
using User = Event_Reservation_and_Venue_Management_System.Models.User;

namespace Event_Reservation_and_Venue_Management_System.Controls
{
    public partial class MakeReservationView : UserControl, IClientUserContextAware
    {
        private User? _currentUser;

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
            // TODO: Fetch active venues from DB
            // var venues = _venueRepository.GetActiveVenues();
            // foreach(var v in venues) cmbVenue.Items.Add(v.Name);

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

            // TODO: Fetch base rate from database model based on cmbVenue.SelectedItem
            decimal total = 0.00m;
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

            // TODO: Execute DB Insert / Service operation to save reservation
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