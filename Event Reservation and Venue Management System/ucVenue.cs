using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Event_Reservation_and_Venue_Management_System
{
    public partial class ucVenue : UserControl
    {
        private DataTable venueTable;
        private int selectedRowIndex = -1; // -1 indicates adding a new venue
        public ucVenue()
        {
            InitializeComponent();
        }
        private void ucVenue_Load(object sender, EventArgs e)
        {
            ConfigureGrid();
            InitializeData();
            SetupDropdowns();
            ClearForm();

            // Register event handlers
            txtSearch.TextChanged += txtSearch_TextChanged;
            dgvVenues.CellClick += dgvVenues_CellClick;
            dgvVenues.CellPainting += dgvVenues_CellPainting;
        }

        // --- 1. Grid Configuration & Pre-populated Data ---
        private void ConfigureGrid()
        {
            dgvVenues.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvVenues.RowHeadersVisible = false;
            dgvVenues.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVenues.AllowUserToAddRows = false;
            dgvVenues.RowTemplate.Height = 35;
            dgvVenues.ColumnHeadersHeight = 35;
        }

        private void InitializeData()
        {
            venueTable = new DataTable();
            venueTable.Columns.Add("Venue Name", typeof(string));
            venueTable.Columns.Add("Capacity", typeof(int));
            venueTable.Columns.Add("Hourly Rate ($)", typeof(string));
            venueTable.Columns.Add("Status", typeof(string));
            venueTable.Columns.Add("Maintenance Notes", typeof(string));

            // Populate with exact data from reference view
            venueTable.Rows.Add("Grand Ballroom", 1000, "$30.00", "Available", "Routine check completed.");
            venueTable.Rows.Add("Grand Ballroom B", 400, "$10.00", "Available", "None");
            venueTable.Rows.Add("Auditorium", 2000, "$35.00", "Maintenance", "Audio system repair.");
            venueTable.Rows.Add("Garden Terrace", 350, "$45.00", "Available", "Lawn manicured.");
            venueTable.Rows.Add("Conference Rm A", 1000, "$25.00", "Available", "AC filter replaced.");
            venueTable.Rows.Add("VIP Lounge", 30, "$10.00", "Maintenance", "Lighting upgrade.");
            venueTable.Rows.Add("Outdoor Pavilion", 600, "$30.00", "Maintenance", "Roof inspection.");
            venueTable.Rows.Add("Executive Boardroom", 300, "$50.00", "Available", "Projector calibrated.");

            dgvVenues.DataSource = venueTable;
        }

        private void SetupDropdowns()
        {
            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("Available");
            cmbStatus.Items.Add("Maintenance");
            cmbStatus.SelectedIndex = 0;
        }

        // --- 2. Live Search Filtering ---
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string filterText = txtSearch.Text.Replace("'", "''").Trim();
            if (string.IsNullOrEmpty(filterText) || filterText == "search..")
            {
                (dgvVenues.DataSource as DataTable).DefaultView.RowFilter = "";
            }
            else
            {
                (dgvVenues.DataSource as DataTable).DefaultView.RowFilter =
                    $"[Venue Name] LIKE '%{filterText}%' OR [Status] LIKE '%{filterText}%'";
            }
        }

        // --- 3. Grid Row Selection ---
        private void dgvVenues_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            LoadVenueToForm(e.RowIndex);
        }

        private void LoadVenueToForm(int rowIndex)
        {
            selectedRowIndex = rowIndex;
            DataGridViewRow row = dgvVenues.Rows[rowIndex];

            txtVenueName.Text = row.Cells["Venue Name"].Value?.ToString();

            if (int.TryParse(row.Cells["Capacity"].Value?.ToString(), out int cap))
                numCapacity.Value = cap;

            txtHourlyRate.Text = row.Cells["Hourly Rate ($)"].Value?.ToString().Replace("$", "");
            cmbStatus.SelectedItem = row.Cells["Status"].Value?.ToString();
            txtMaintenance.Text = row.Cells["Maintenance Notes"].Value?.ToString();
        }

        // --- 4. Form Action Buttons ---
        private void btnAddNewVenue_Click(object sender, EventArgs e)
        {
            ClearForm();
            txtVenueName.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtVenueName.Text))
            {
                MessageBox.Show("Please enter a valid Venue Name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string formattedRate = txtHourlyRate.Text.StartsWith("$") ? txtHourlyRate.Text : $"${txtHourlyRate.Text.Trim()}";

            if (selectedRowIndex >= 0 && selectedRowIndex < dgvVenues.Rows.Count)
            {
                // Update Existing Row
                DataGridViewRow row = dgvVenues.Rows[selectedRowIndex];
                row.Cells["Venue Name"].Value = txtVenueName.Text;
                row.Cells["Capacity"].Value = (int)numCapacity.Value;
                row.Cells["Hourly Rate ($)"].Value = formattedRate;
                row.Cells["Status"].Value = cmbStatus.SelectedItem.ToString();
                row.Cells["Maintenance Notes"].Value = txtMaintenance.Text;
            }
            else
            {
                // Add New Row
                venueTable.Rows.Add(
                    txtVenueName.Text,
                    (int)numCapacity.Value,
                    formattedRate,
                    cmbStatus.SelectedItem.ToString(),
                    txtMaintenance.Text
                );
            }

            ClearForm();
            MessageBox.Show("Venue record saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedRowIndex < 0 || dgvVenues.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a venue from the list to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string venueName = dgvVenues.Rows[selectedRowIndex].Cells["Venue Name"].Value?.ToString();

            DialogResult confirm = MessageBox.Show($"Are you sure you want to delete '{venueName}'?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                dgvVenues.Rows.RemoveAt(selectedRowIndex);
                ClearForm();
                MessageBox.Show("Venue deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            selectedRowIndex = -1;
            txtVenueName.Clear();
            numCapacity.Value = 0;
            txtHourlyRate.Clear();
            cmbStatus.SelectedIndex = 0;
            txtMaintenance.Clear();
            dgvVenues.ClearSelection();
        }

        // --- 5. Status Pill Custom Rendering ---
        private void dgvVenues_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && dgvVenues.Columns[e.ColumnIndex].Name == "Status")
            {
                e.PaintBackground(e.CellBounds, true);

                string status = e.Value?.ToString() ?? "";
                Color pillColor = (status == "Available") ? Color.FromArgb(40, 167, 69) : Color.FromArgb(255, 193, 7);

                Rectangle rect = new Rectangle(e.CellBounds.X + 8, e.CellBounds.Y + 6, e.CellBounds.Width - 16, e.CellBounds.Height - 12);

                using (Brush brush = new SolidBrush(pillColor))
                using (GraphicsPath path = GetRoundedPath(rect, 10))
                using (StringFormat sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                {
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    e.Graphics.FillPath(brush, path);

                    Color textColor = (status == "Maintenance") ? Color.Black : Color.White;
                    using (Brush textBrush = new SolidBrush(textColor))
                    {
                        e.Graphics.DrawString(status, dgvVenues.Font, textBrush, rect, sf);
                    }
                }
                e.Handled = true;
            }
        }

        private GraphicsPath GetRoundedPath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90);
            path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90);
            path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90);
            path.CloseFigure();
            return path;
        }

    }
}
