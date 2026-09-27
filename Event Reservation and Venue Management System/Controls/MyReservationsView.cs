using System;
using System.Data;
using System.Windows.Forms;
using User = Event_Reservation_and_Venue_Management_System.Models.User;

namespace Event_Reservation_and_Venue_Management_System.Controls
{
    public partial class MyReservationsView : UserControl, IClientUserContextAware
    {
        private User? _currentUser;
        private DataTable _reservationsTable = new DataTable();

        public MyReservationsView()
        {
            InitializeComponent();
            InitializeFilterOptions();
            InitializeDataSchema();
        }

        public void SetCurrentUser(User user)
        {
            _currentUser = user;
            LoadUserReservations();
        }

        private void InitializeFilterOptions()
        {
            cmbStatusFilter.Items.Clear();
            cmbStatusFilter.Items.Add("All Statuses");
            cmbStatusFilter.Items.Add("Pending");
            cmbStatusFilter.Items.Add("Approved");
            cmbStatusFilter.Items.Add("Cancelled");
            cmbStatusFilter.Items.Add("Completed");
            cmbStatusFilter.SelectedIndex = 0;
        }

        private void InitializeDataSchema()
        {
            _reservationsTable.Columns.Clear();
            _reservationsTable.Columns.Add("ReservationId", typeof(int));
            _reservationsTable.Columns.Add("VenueName", typeof(string));
            _reservationsTable.Columns.Add("EventTitle", typeof(string));
            _reservationsTable.Columns.Add("EventDate", typeof(DateTime));
            _reservationsTable.Columns.Add("TimeSlot", typeof(string));
            _reservationsTable.Columns.Add("GuestCount", typeof(int));
            _reservationsTable.Columns.Add("TotalFee", typeof(decimal));
            _reservationsTable.Columns.Add("Status", typeof(string));
        }

        public void LoadUserReservations()
        {
            if (_currentUser == null) return;

            _reservationsTable.Rows.Clear();

            // TODO: Fetch user reservations from database context / repository
            // Example:
            // DataTable dt = _reservationRepository.GetReservationsByUserId(_currentUser.Id);
            // _reservationsTable = dt;

            ApplyFilters();
        }

        private void ApplyFilters()
        {
            string searchKeyword = txtSearch.Text.Trim().ToLower();
            string selectedStatus = cmbStatusFilter.SelectedItem?.ToString() ?? "All Statuses";

            dgvMyReservations.Rows.Clear();

            foreach (DataRow row in _reservationsTable.Rows)
            {
                string venueName = row["VenueName"].ToString() ?? "";
                string eventTitle = row["EventTitle"].ToString() ?? "";
                string status = row["Status"].ToString() ?? "";

                bool matchesSearch = string.IsNullOrEmpty(searchKeyword) ||
                                     venueName.ToLower().Contains(searchKeyword) ||
                                     eventTitle.ToLower().Contains(searchKeyword);

                bool matchesStatus = selectedStatus == "All Statuses" ||
                                     status.Equals(selectedStatus, StringComparison.OrdinalIgnoreCase);

                if (matchesSearch && matchesStatus)
                {
                    DateTime eventDate = Convert.ToDateTime(row["EventDate"]);
                    decimal totalFee = Convert.ToDecimal(row["TotalFee"]);

                    dgvMyReservations.Rows.Add(
                        row["ReservationId"],
                        venueName,
                        eventTitle,
                        eventDate.ToString("yyyy-MM-dd"),
                        row["TimeSlot"],
                        row["GuestCount"],
                        $"₱ {totalFee:N2}",
                        status
                    );
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void cmbStatusFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadUserReservations();
        }

        private void btnCancelReservation_Click(object sender, EventArgs e)
        {
            if (dgvMyReservations.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a reservation to cancel.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int reservationId = Convert.ToInt32(dgvMyReservations.SelectedRows[0].Cells["colId"].Value);
            string status = dgvMyReservations.SelectedRows[0].Cells["colStatus"].Value?.ToString() ?? "";

            if (status.Equals("Cancelled", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("This reservation has already been cancelled.", "Action Invalid", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (status.Equals("Completed", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Completed reservations cannot be cancelled.", "Action Invalid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Are you sure you want to cancel Reservation ID #{reservationId}?",
                "Confirm Cancelation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                // TODO: Update reservation status to 'Cancelled' in Database
                // _reservationRepository.UpdateStatus(reservationId, "Cancelled");

                MessageBox.Show("Reservation has been successfully cancelled.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadUserReservations();
            }
        }
    }
}