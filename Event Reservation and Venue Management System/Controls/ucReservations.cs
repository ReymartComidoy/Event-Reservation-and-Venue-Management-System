using System;
using System.Data;
using System.Windows.Forms;
using Event_Reservation_and_Venue_Management_System.Services;

namespace Event_Reservation_and_Venue_Management_System.Controls
{
    public partial class ucReservations : UserControl
    {
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
        }

        private void ucReservations_Load(object? sender, EventArgs e)
        {
            dgvReservations.DataSource = DataRepository.ReservationsTable;
            PopulateDropdowns();
        }

        private void PopulateDropdowns()
        {
            cmbClient.Items.Clear();
            foreach (DataRow row in DataRepository.ClientsTable.Rows)
            {
                cmbClient.Items.Add(row["ClientName"].ToString());
            }

            cmbEvent.Items.Clear();
            foreach (DataRow row in DataRepository.EventsTable.Rows)
            {
                cmbEvent.Items.Add(row["EventName"].ToString());
            }

            cmbVenue.Items.Clear();
            foreach (DataRow row in DataRepository.VenuesTable.Rows)
            {
                cmbVenue.Items.Add(row["VenueName"].ToString());
            }
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
            }
        }

        private void btnSave_Click(object? sender, EventArgs e)
        {
            if (dgvReservations.CurrentRow != null)
            {
                DataRowView drv = (DataRowView)dgvReservations.CurrentRow.DataBoundItem;
                drv["ClientName"] = cmbClient.SelectedItem?.ToString() ?? "";
                drv["EventName"] = cmbEvent.SelectedItem?.ToString() ?? "";
                drv["Venue"] = cmbVenue.SelectedItem?.ToString() ?? "";
                drv["TotalAmount"] = numTotalAmount.Value;
                drv["Status"] = cmbStatus.SelectedItem?.ToString() ?? "Pending";
                MessageBox.Show("Reservation updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnAddReservation_Click(object? sender, EventArgs e)
        {
            using ReservationDetailsForm reservationDetailsForm = new ReservationDetailsForm();
            if (reservationDetailsForm.ShowDialog(FindForm()) == DialogResult.OK)
            {
                dgvReservations.DataSource = null;
                dgvReservations.DataSource = DataRepository.ReservationsTable;
            }
        }

        private void btnDelete_Click(object? sender, EventArgs e)
        {
            if (dgvReservations.CurrentRow != null)
            {
                dgvReservations.Rows.RemoveAt(dgvReservations.CurrentRow.Index);
            }
        }

        private void btnCancel_Click(object? sender, EventArgs e)
        {
            numTotalAmount.Value = 0;
        }

        private void txtSearchReservations_TextChanged(object? sender, EventArgs e)
        {
            string query = txtSearch.Text.Trim().Replace("'", "''");
            DataRepository.ReservationsTable.DefaultView.RowFilter = string.IsNullOrEmpty(query)
                ? string.Empty
                : $"ClientName LIKE '%{query}%' OR EventName LIKE '%{query}%'";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}