using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Event_Reservation_and_Venue_Management_System.Services;

namespace Event_Reservation_and_Venue_Management_System.Controls
{
    public partial class ucReservations : UserControl
    {
        private readonly ReservationService _reservationService = new();
        private readonly ClientService _clientService = new();
        private readonly VenueService _venueService = new();
        private readonly EventService _eventService = new();
        private DataTable _reservations = new();
        private DataTable _clients = new();
        private DataTable _venues = new();
        private DataTable _events = new();

        public ucReservations()
        {
            InitializeComponent();
            WireUpEvents();
        }

        private void WireUpEvents()
        {
            this.Load += ucReservations_Load;
            btnSave.Click += btnSave_Click;
            btnDelete.Click += btnDelete_Click;
            btnCancel.Click += btnCancel_Click;
            dgvReservations.SelectionChanged += dgvReservations_SelectionChanged;
            txtSearch.TextChanged += txtSearchReservations_TextChanged;
            cmbStatusFilter.SelectedIndexChanged += cmbStatusFilter_SelectedIndexChanged;
        }

        private void ucReservations_Load(object? sender, EventArgs e)
        {
            try
            {
                _reservations = _reservationService.GetAll();
                dgvReservations.DataSource = _reservations;
                _clients = _clientService.GetAll();
                _venues = _venueService.GetAll();
                _events = _eventService.GetAll();
                PopulateStatusFilter();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unable to load reservations.\n\n{ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            PopulateDropdowns();
        }

        private void PopulateDropdowns()
        {
            cmbClient.Items.Clear();
            foreach (DataRow row in _clients.Rows)
            {
                cmbClient.Items.Add(row["ClientName"]?.ToString());
            }

            cmbEvent.Items.Clear();
            foreach (DataRow row in _events.Rows)
            {
                cmbEvent.Items.Add(row["EventName"].ToString());
            }

            cmbVenue.Items.Clear();
            foreach (DataRow row in _venues.Rows)
            {
                cmbVenue.Items.Add(row["VenueName"].ToString());
            }
        }

        private void PopulateStatusFilter()
        {
            cmbStatusFilter.Items.Clear();
            cmbStatusFilter.Items.Add("All Statuses");
            foreach (string status in _reservations.AsEnumerable()
                .Select(row => row["Status"]?.ToString() ?? string.Empty)
                .Where(status => !string.IsNullOrWhiteSpace(status))
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .OrderBy(status => status))
            {
                cmbStatusFilter.Items.Add(status);
            }
            cmbStatusFilter.SelectedIndex = 0;
        }

        private void dgvReservations_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgvReservations.CurrentRow != null && dgvReservations.CurrentRow.Index >= 0)
            {
                DataGridViewRow row = dgvReservations.CurrentRow;
                cmbClient.SelectedItem = row.Cells["ClientName"].Value?.ToString();
                cmbEvent.SelectedItem = row.Cells["EventName"].Value?.ToString();
                cmbVenue.SelectedItem = row.Cells["Venue"].Value?.ToString();
                cmbStatus.SelectedItem = row.Cells["Status"].Value?.ToString();
                numTotalAmount.Value = decimal.TryParse(row.Cells["TotalAmount"].Value?.ToString(), out decimal amt) ? amt : 0;
                if (DateTime.TryParse(row.Cells["ReservationDate"].Value?.ToString(), out DateTime date))
                    dtpReservationDate.Value = date;
            }
        }

        private void btnSave_Click(object? sender, EventArgs e)
        {
            if (dgvReservations.CurrentRow != null)
            {
                DataRowView drv = (DataRowView)dgvReservations.CurrentRow.DataBoundItem;
                DataRow? client = _clients.AsEnumerable().FirstOrDefault(row =>
                    string.Equals(row["ClientName"]?.ToString(), cmbClient.SelectedItem?.ToString(), StringComparison.OrdinalIgnoreCase));
                DataRow? venue = _venues.AsEnumerable().FirstOrDefault(row =>
                    string.Equals(row["VenueName"]?.ToString(), cmbVenue.SelectedItem?.ToString(), StringComparison.OrdinalIgnoreCase));
                if (client == null || venue == null)
                {
                    MessageBox.Show("Select a valid client and venue.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                _reservationService.Update(
                    Convert.ToInt32(drv["Id"]), Convert.ToInt32(client["ClientId"]), Convert.ToInt32(venue["Id"]),
                    cmbEvent.SelectedItem?.ToString() ?? string.Empty, dtpReservationDate.Value,
                    string.Empty, 1, numTotalAmount.Value,
                    cmbStatus.SelectedItem?.ToString() ?? "Pending");
                _reservations = _reservationService.GetAll();
                dgvReservations.DataSource = _reservations;
                MessageBox.Show("Reservation updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnAddReservation_Click(object? sender, EventArgs e)
        {
            using ReservationDetailsForm reservationDetailsForm = new ReservationDetailsForm();
            if (reservationDetailsForm.ShowDialog(FindForm()) == DialogResult.OK)
            {
                _reservations = _reservationService.GetAll();
                dgvReservations.DataSource = _reservations;
            }
        }

        private void btnDelete_Click(object? sender, EventArgs e)
        {
            if (dgvReservations.CurrentRow != null)
            {
                int id = Convert.ToInt32(((DataRowView)dgvReservations.CurrentRow.DataBoundItem)["Id"]);
                _reservationService.Delete(id);
                _reservations = _reservationService.GetAll();
                dgvReservations.DataSource = _reservations;
            }
        }

        private void btnCancel_Click(object? sender, EventArgs e)
        {
            numTotalAmount.Value = 0;
        }

        private void txtSearchReservations_TextChanged(object? sender, EventArgs e)
        {
            string query = txtSearch.Text.Trim().Replace("'", "''");
            string status = cmbStatusFilter.SelectedItem?.ToString() ?? "All Statuses";
            List<string> filters = new();
            if (!string.IsNullOrWhiteSpace(query) && query != "Search Reservations...")
                filters.Add($"(ClientName LIKE '%{query}%' OR EventName LIKE '%{query}%')");
            if (status != "All Statuses")
                filters.Add($"Status = '{status.Replace("'", "''")}'");
            _reservations.DefaultView.RowFilter = string.Join(" AND ", filters);
        }

        private void cmbStatusFilter_SelectedIndexChanged(object? sender, EventArgs e)
        {
            txtSearchReservations_TextChanged(sender, e);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}