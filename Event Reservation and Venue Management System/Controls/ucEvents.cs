using Event_Reservation_and_Venue_Management_System.Services;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Windows.Forms;

namespace Event_Reservation_and_Venue_Management_System.Controls
{
    public partial class ucEvents : UserControl
    {
        public ucEvents()
        {
            InitializeComponent();
        }

        private void ucEvents_Load(object sender, EventArgs e)
        {
            RefreshGrid();
            PopulateVenuesCombo();
        }

        private void PopulateVenuesCombo()
        {
            cmbVenue.Items.Clear();
            foreach (DataRow row in DataRepository.VenuesTable.Rows)
            {
                cmbVenue.Items.Add(row["VenueName"].ToString());
            }
        }

        private void RefreshGrid()
        {
            dgvEvents.DataSource = DataRepository.EventsTable;
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
                drv["EventName"] = txtEventName.Text;
                drv["Venue"] = cmbVenue.SelectedItem?.ToString() ?? "";
                drv["Date"] = dtpEventDate.Value.ToString("yyyy-MM-dd");
                drv["Bookings"] = int.TryParse(txtBookings.Text, out int b) ? b : 0;
                MessageBox.Show("Event saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvEvents.CurrentRow != null)
            {
                dgvEvents.Rows.RemoveAt(dgvEvents.CurrentRow.Index);
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
            DataRepository.EventsTable.DefaultView.RowFilter = string.IsNullOrEmpty(query)
                ? string.Empty
                : $"EventName LIKE '%{query}%' OR Venue LIKE '%{query}%'";
        }

        private void dgvEvents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}