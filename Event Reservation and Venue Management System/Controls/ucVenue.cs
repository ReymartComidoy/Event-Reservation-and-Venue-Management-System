using System;
using System.Data;
using System.Windows.Forms;
using Event_Reservation_and_Venue_Management_System.Services;

namespace Event_Reservation_and_Venue_Management_System.Controls
{
    public partial class ucVenue : UserControl
    {
        public ucVenue()
        {
            InitializeComponent();
            WireUpEvents();
        }

        private void WireUpEvents()
        {
            this.Load += ucVenue_Load;
            btnSave.Click += btnSave_Click;
            btnDelete.Click += btnDelete_Click;
            btnCancel.Click += btnCancel_Click;
            dgvVenues.SelectionChanged += dgvVenues_SelectionChanged;
        }

        private void ucVenue_Load(object? sender, EventArgs e)
        {
            dgvVenues.DataSource = DataRepository.VenuesTable;
        }

        private void dgvVenues_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgvVenues.CurrentRow != null && dgvVenues.CurrentRow.Index >= 0)
            {
                DataGridViewRow row = dgvVenues.CurrentRow;
                txtVenueName.Text = row.Cells["VenueName"].Value?.ToString();
                numCapacity.Value = int.TryParse(row.Cells["Capacity"].Value?.ToString(), out int cap) ? cap : 0;
                txtHourlyRate.Text = row.Cells["PricePerHour"].Value?.ToString();
                cmbStatus.SelectedItem = row.Cells["Status"].Value?.ToString();
            }
        }

        private void btnSave_Click(object? sender, EventArgs e)
        {
            if (dgvVenues.CurrentRow != null)
            {
                DataRowView drv = (DataRowView)dgvVenues.CurrentRow.DataBoundItem;
                drv["VenueName"] = txtVenueName.Text;
                drv["Capacity"] = (int)numCapacity.Value;
                drv["PricePerHour"] = decimal.TryParse(txtHourlyRate.Text, out decimal r) ? r : 0;
                drv["Status"] = cmbStatus.SelectedItem?.ToString() ?? "Available";
                MessageBox.Show("Venue updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnAddVenue_Click(object? sender, EventArgs e)
        {
            using VenueDetailsForm venueDetailsForm = new VenueDetailsForm();
            if (venueDetailsForm.ShowDialog(FindForm()) == DialogResult.OK)
            {
                dgvVenues.DataSource = null;
                dgvVenues.DataSource = DataRepository.VenuesTable;
            }
        }

        private void btnDelete_Click(object? sender, EventArgs e)
        {
            if (dgvVenues.CurrentRow != null)
            {
                dgvVenues.Rows.RemoveAt(dgvVenues.CurrentRow.Index);
            }
        }

        private void btnCancel_Click(object? sender, EventArgs e)
        {
            txtVenueName.Clear();
            txtHourlyRate.Clear();
            numCapacity.Value = 0;
        }
    }
}