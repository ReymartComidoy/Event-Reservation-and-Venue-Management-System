using Event_Reservation_and_Venue_Management_System.Services;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Windows.Forms;

namespace Event_Reservation_and_Venue_Management_System.Controls
{
    public partial class ucEvents : UserControl
    {
        private readonly EventService _eventService = new();
        private readonly VenueService _venueService = new();
        private DataTable _events = new();
        private DataTable _venues = new();

        public ucEvents()
        {
            InitializeComponent();
        }

        private void ucEvents_Load(object sender, EventArgs e)
        {
            _venues = _venueService.GetAll();
            RefreshGrid();
            PopulateVenuesCombo();
        }

        private void PopulateVenuesCombo()
        {
            cmbVenue.Items.Clear();
            foreach (DataRow row in _venues.Rows)
            {
                cmbVenue.Items.Add(row["VenueName"].ToString());
            }
        }

        private void RefreshGrid()
        {
            try
            {
                _events = _eventService.GetAll();
                dgvEvents.DataSource = _events;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unable to load events.\n\n{ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvEvents_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvEvents.CurrentRow != null && dgvEvents.CurrentRow.Index >= 0)
            {
                DataGridViewRow row = dgvEvents.CurrentRow;
                txtEventName.Text = row.Cells["EventName"].Value?.ToString();
                cmbVenue.SelectedItem = row.Cells["Venue"].Value?.ToString();
                if (DateTime.TryParse(row.Cells["Date"].Value?.ToString(), out DateTime dt))
                {
                    dtpEventDate.Value = dt;
                }
                txtBookings.Text = row.Cells["Bookings"].Value?.ToString();
            }
        }

        private void btnAddEvent_Click(object sender, EventArgs e)
        {
            using EventDetailsForm eventDetailsForm = new EventDetailsForm();
            if (eventDetailsForm.ShowDialog(FindForm()) == DialogResult.OK)
            {
                RefreshGrid();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dgvEvents.CurrentRow != null)
            {
                DataRowView drv = (DataRowView)dgvEvents.CurrentRow.DataBoundItem;
                DataRow? venue = _venues.AsEnumerable().FirstOrDefault(row =>
                    string.Equals(row["VenueName"]?.ToString(), cmbVenue.SelectedItem?.ToString(), StringComparison.OrdinalIgnoreCase));
                _eventService.Save(Convert.ToInt32(drv["Id"]), txtEventName.Text.Trim(),
                    venue == null ? null : Convert.ToInt32(venue["Id"]), dtpEventDate.Value, null,
                    int.TryParse(txtBookings.Text, out int b) ? b : 0, "Upcoming");
                RefreshGrid();
                MessageBox.Show("Event saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvEvents.CurrentRow != null)
            {
                int id = Convert.ToInt32(((DataRowView)dgvEvents.CurrentRow.DataBoundItem)["Id"]);
                _eventService.Delete(id);
                RefreshGrid();
                MessageBox.Show("Event deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtEventName.Clear();
            txtBookings.Clear();
            if (cmbVenue.Items.Count > 0) cmbVenue.SelectedIndex = 0;
        }

        private void txtSearchEvents_TextChanged(object sender, EventArgs e)
        {
            string query = txtSearch.Text.Trim().Replace("'", "''");
            _events.DefaultView.RowFilter = string.IsNullOrEmpty(query)
                ? string.Empty
                : $"EventName LIKE '%{query}%' OR Venue LIKE '%{query}%'";
        }

        private void dgvEvents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}