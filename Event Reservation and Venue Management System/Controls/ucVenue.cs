using System;
using System.Data;
using System.Windows.Forms;
using Event_Reservation_and_Venue_Management_System.Services;

namespace Event_Reservation_and_Venue_Management_System.Controls
{
    public partial class ucVenue : UserControl
    {
        private readonly VenueService _venueService = new();

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
            LoadVenues();
        }

        private void LoadVenues()
        {
            try
            {
                dgvVenues.DataSource = _venueService.GetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unable to load venues. Run DatabaseSchema.sql first.\n\n{ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                if (!decimal.TryParse(txtHourlyRate.Text, out decimal rate) || rate < 0)
                {
                    MessageBox.Show("Enter a valid hourly rate.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DataRowView drv = (DataRowView)dgvVenues.CurrentRow.DataBoundItem;
                _venueService.Save(
                    Convert.ToInt32(drv["Id"]), txtVenueName.Text.Trim(),
                    drv["VenueType"].ToString() ?? txtVenueName.Text.Trim(),
                    (int)numCapacity.Value, txtMaintenance.Text.Trim(), rate,
                    cmbStatus.SelectedItem?.ToString() ?? "Available", drv["ImagePath"] as string, null);
                LoadVenues();
                MessageBox.Show("Venue updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnAddVenue_Click(object? sender, EventArgs e)
        {
            using VenueDetailsForm venueDetailsForm = new VenueDetailsForm();
            if (venueDetailsForm.ShowDialog(FindForm()) == DialogResult.OK)
            {
                LoadVenues();
            }
        }

        private void btnDelete_Click(object? sender, EventArgs e)
        {
            if (dgvVenues.CurrentRow != null)
            {
                int id = Convert.ToInt32(((DataRowView)dgvVenues.CurrentRow.DataBoundItem)["Id"]);
                _venueService.Delete(id);
                LoadVenues();
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