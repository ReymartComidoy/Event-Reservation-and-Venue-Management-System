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
        private int selectedRowIndex = -1; // -1 indicates adding a new venue

        public ucVenue()
        {
            InitializeComponent();

            ConfigureGrid();

            // Register event handlers safely
            if (txtSearch != null) txtSearch.TextChanged += txtSearch_TextChanged;
            if (dgvVenues != null)
            {
                dgvVenues.CellClick += dgvVenues_CellClick;
                dgvVenues.CellPainting += dgvVenues_CellPainting;
            }

            if (btnAddNewVenue != null) btnAddNewVenue.Click += btnAddNewVenue_Click;
            if (btnSave != null) btnSave.Click += btnSave_Click;
            if (btnDelete != null) btnDelete.Click += btnDelete_Click;
            if (btnCancel != null) btnCancel.Click += btnCancel_Click;
        }

        private void ucVenue_Load(object sender, EventArgs e)
        {
            RefreshVenueData();
        }

        // Auto-refresh when tab becomes visible
        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            if (this.Visible)
            {
                RefreshVenueData();
            }
        }

        public void RefreshVenueData()
        {
            SetupDropdowns();

            // Bind grid directly to shared DataRepository
            dgvVenues.DataSource = null;
            dgvVenues.AutoGenerateColumns = true;
            dgvVenues.DataSource = DataRepository.VenuesTable;

            ClearForm();
        }

        // --- Grid Configuration ---
        private void ConfigureGrid()
        {
            dgvVenues.AutoGenerateColumns = true;
            dgvVenues.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvVenues.RowHeadersVisible = false;
            dgvVenues.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVenues.AllowUserToAddRows = false;
            dgvVenues.RowTemplate.Height = 35;
            dgvVenues.ColumnHeadersHeight = 35;
        }

        private void SetupDropdowns()
        {
            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("Available");
            cmbStatus.Items.Add("Maintenance");
            cmbStatus.SelectedIndex = 0;
        }

        // --- Live Search Filtering ---
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (dgvVenues.DataSource is DataTable dt)
            {
                string filterText = txtSearch.Text.Replace("'", "''").Trim();
                if (string.IsNullOrEmpty(filterText) || filterText == "search..")
                {
                    dt.DefaultView.RowFilter = "";
                }
                else
                {
                    dt.DefaultView.RowFilter = $"[Venue Name] LIKE '%{filterText}%' OR [Status] LIKE '%{filterText}%'";
                }
            }
        }

        // --- Grid Row Selection ---
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

            // Dynamically retrieve hourly rate regardless of ($) symbol in column header
            string rateCol = dgvVenues.Columns.Contains("Hourly Rate ($)") ? "Hourly Rate ($)" :
                            dgvVenues.Columns.Contains("Hourly Rate") ? "Hourly Rate" : "Rate";

            if (dgvVenues.Columns.Contains(rateCol))
            {
                txtHourlyRate.Text = row.Cells[rateCol].Value?.ToString().Replace("$", "").Trim();
            }

            if (dgvVenues.Columns.Contains("Status"))
            {
                cmbStatus.SelectedItem = row.Cells["Status"].Value?.ToString();
            }

            if (dgvVenues.Columns.Contains("Maintenance Notes"))
            {
                txtMaintenance.Text = row.Cells["Maintenance Notes"].Value?.ToString();
            }
        }

        // --- Form Action Buttons ---
        private void btnAddNewVenue_Click(object sender, EventArgs e)
        {
            ClearForm();
            txtVenueName.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtVenueName.Text))
            {
                return; // Returns silently without showing the error pop-up
            }

            string rawRate = txtHourlyRate.Text.Replace("$", "").Trim();
            string formattedRate = string.IsNullOrWhiteSpace(rawRate) ? "$0.00" : $"${rawRate}";

            if (selectedRowIndex >= 0 && selectedRowIndex < dgvVenues.Rows.Count)
            {
                // Update existing row directly via DataRowView
                DataGridViewRow gridRow = dgvVenues.Rows[selectedRowIndex];
                if (gridRow.DataBoundItem is DataRowView drv)
                {
                    drv["Venue Name"] = txtVenueName.Text.Trim();
                    drv["Capacity"] = (int)numCapacity.Value;

                    // Find matching column name in DataTable schema
                    if (drv.Row.Table.Columns.Contains("Hourly Rate ($)")) drv["Hourly Rate ($)"] = formattedRate;
                    else if (drv.Row.Table.Columns.Contains("Hourly Rate")) drv["Hourly Rate"] = formattedRate;
                    else if (drv.Row.Table.Columns.Contains("Rate")) drv["Rate"] = formattedRate;

                    if (drv.Row.Table.Columns.Contains("Status")) drv["Status"] = cmbStatus.SelectedItem.ToString();
                    if (drv.Row.Table.Columns.Contains("Maintenance Notes")) drv["Maintenance Notes"] = txtMaintenance.Text.Trim();
                }
            }
            else
            {
                // Add new row matching DataRepository.VenuesTable schema dynamically
                DataRow newRow = DataRepository.VenuesTable.NewRow();
                newRow["Venue Name"] = txtVenueName.Text.Trim();
                newRow["Capacity"] = (int)numCapacity.Value;

                if (DataRepository.VenuesTable.Columns.Contains("Hourly Rate ($)")) newRow["Hourly Rate ($)"] = formattedRate;
                else if (DataRepository.VenuesTable.Columns.Contains("Hourly Rate")) newRow["Hourly Rate"] = formattedRate;
                else if (DataRepository.VenuesTable.Columns.Contains("Rate")) newRow["Rate"] = formattedRate;

                if (DataRepository.VenuesTable.Columns.Contains("Status")) newRow["Status"] = cmbStatus.SelectedItem.ToString();
                if (DataRepository.VenuesTable.Columns.Contains("Maintenance Notes")) newRow["Maintenance Notes"] = txtMaintenance.Text.Trim();

                DataRepository.VenuesTable.Rows.Add(newRow);
            }

            RefreshVenueData();
            MessageBox.Show("Venue record saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Silently return if no valid row is selected (prevents "No Selection" pop-up)
            if (selectedRowIndex < 0 || selectedRowIndex >= dgvVenues.Rows.Count || dgvVenues.SelectedRows.Count == 0)
            {
                return;
            }

            DataGridViewRow row = dgvVenues.Rows[selectedRowIndex];
            string venueName = row.Cells["Venue Name"].Value?.ToString();

            DialogResult confirm = MessageBox.Show($"Are you sure you want to delete '{venueName}'?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                if (row.DataBoundItem is DataRowView drv)
                {
                    drv.Row.Delete();
                }

                RefreshVenueData();
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

        // --- Status Pill Custom Rendering ---
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