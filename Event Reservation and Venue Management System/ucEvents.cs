using Microsoft.VisualBasic;
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
    public partial class ucEvents : UserControl
    {
        private int selectedRowIndex = -1; // Tracks which row is being edited (-1 = New Event)

        public ucEvents()
        {
            InitializeComponent();

            // Configure Grid layout
            ConfigureGrid();

            // Register Search & Filter Handlers safely
            if (txtSearch != null) txtSearch.TextChanged += FilterEvents;
            if (cmbVenueFilter != null) cmbVenueFilter.SelectedIndexChanged += FilterEvents;
            if (dgvEvents != null)
            {
                dgvEvents.CellClick += dgvEvents_CellClick;
                dgvEvents.CellPainting += dgvEvents_CellPainting;
            }

            // Register Action Button Handlers safely
            if (btnAddNewEvent != null) btnAddNewEvent.Click += btnAddNewEvent_Click;
            if (btnSave != null) btnSave.Click += btnSave_Click;
            if (btnDelete != null) btnDelete.Click += btnDelete_Click;
            if (btnCancel != null) btnCancel.Click += btnCancel_Click;
        }

        private void ucEvents_Load(object sender, EventArgs e)
        {
            RefreshEventData();
        }

        // Auto-refresh when tab becomes visible
        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            if (this.Visible)
            {
                RefreshEventData();
            }
        }

        public void RefreshEventData()
        {
            SetupDropdowns();

            // Bind grid directly to shared DataRepository
            dgvEvents.DataSource = null;
            dgvEvents.AutoGenerateColumns = true;
            dgvEvents.DataSource = DataRepository.EventsTable;

            ClearForm();
        }

        private void ConfigureGrid()
        {
            dgvEvents.AutoGenerateColumns = true;
            dgvEvents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEvents.RowHeadersVisible = false;
            dgvEvents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEvents.AllowUserToAddRows = false;
            dgvEvents.RowTemplate.Height = 35;
            dgvEvents.ColumnHeadersHeight = 35;
        }

        private void SetupDropdowns()
        {
            cmbVenue.Items.Clear();
            cmbVenueFilter.Items.Clear();
            cmbVenueFilter.Items.Add("All Venues");

            // Dynamically load venue dropdown items from shared repository
            if (DataRepository.VenuesTable != null)
            {
                foreach (DataRow row in DataRepository.VenuesTable.Rows)
                {
                    string venueName = row["Venue Name"]?.ToString();
                    if (!string.IsNullOrEmpty(venueName))
                    {
                        cmbVenue.Items.Add(venueName);
                        cmbVenueFilter.Items.Add(venueName);
                    }
                }
            }

            if (cmbVenueFilter.Items.Count > 0)
            {
                cmbVenueFilter.SelectedIndex = 0;
            }
        }

        // --- Real-Time Search & Venue Filtering ---
        private void FilterEvents(object sender, EventArgs e)
        {
            if (dgvEvents.DataSource is DataTable dt)
            {
                string searchKeyword = txtSearch.Text.Replace("'", "''").Trim();
                if (searchKeyword == "Search Events...") searchKeyword = "";

                string selectedVenue = cmbVenueFilter.SelectedItem?.ToString();
                string filterExpression = "";

                if (!string.IsNullOrEmpty(searchKeyword))
                {
                    filterExpression += $"([Event Name] LIKE '%{searchKeyword}%' OR [Venue] LIKE '%{searchKeyword}%')";
                }

                if (!string.IsNullOrEmpty(selectedVenue) && selectedVenue != "All Venues")
                {
                    if (filterExpression.Length > 0) filterExpression += " AND ";
                    filterExpression += $"[Venue] = '{selectedVenue.Replace("'", "''")}'";
                }

                dt.DefaultView.RowFilter = filterExpression;
            }
        }

        // --- Grid Selection Handling ---
        private void dgvEvents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            LoadEventToForm(e.RowIndex);
        }

        private void LoadEventToForm(int rowIndex)
        {
            selectedRowIndex = rowIndex;
            DataGridViewRow row = dgvEvents.Rows[rowIndex];

            txtEventName.Text = row.Cells["Event Name"].Value?.ToString();

            string venueValue = row.Cells["Venue"].Value?.ToString();
            if (cmbVenue.Items.Contains(venueValue))
            {
                cmbVenue.SelectedItem = venueValue;
            }

            // Load Bookings count into txtBookings
            if (dgvEvents.Columns.Contains("Bookings") && txtBookings != null)
            {
                txtBookings.Text = row.Cells["Bookings"].Value?.ToString() ?? "0";
            }

            if (DateTime.TryParse(row.Cells["Date"].Value?.ToString(), out DateTime parsedDate))
            {
                dtpEventDate.Value = parsedDate;
            }
        }

        // --- CRUD Action Buttons ---
        private void btnAddNewEvent_Click(object sender, EventArgs e)
        {
            ClearForm();
            txtEventName.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEventName.Text))
            {
                return; // Returns silently without showing the error pop-up
            }

            if (cmbVenue.SelectedItem == null)
            {
                MessageBox.Show("Please select a Venue.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string formattedDate = dtpEventDate.Value.ToString("yyyy-MM-dd");
            string formattedTime = "09:00 AM";
            string status = dtpEventDate.Value.Date >= DateTime.Now.Date ? "Upcoming" : "Completed";

            // Parse Bookings TextBox input (defaults to 0 if invalid or empty)
            int bookingsCount = 0;
            if (txtBookings != null)
            {
                int.TryParse(txtBookings.Text.Trim(), out bookingsCount);
            }

            if (selectedRowIndex >= 0 && selectedRowIndex < dgvEvents.Rows.Count)
            {
                // Update existing row safely
                DataGridViewRow gridRow = dgvEvents.Rows[selectedRowIndex];
                if (gridRow.DataBoundItem is DataRowView drv)
                {
                    drv["Event Name"] = txtEventName.Text.Trim();
                    drv["Venue"] = cmbVenue.SelectedItem.ToString();
                    drv["Date"] = formattedDate;
                    drv["Time"] = formattedTime;
                    drv["Status"] = status;
                    if (drv.Row.Table.Columns.Contains("Bookings")) drv["Bookings"] = bookingsCount;
                }
            }
            else
            {
                // Add new row matching DataRepository schema
                DataRow newRow = DataRepository.EventsTable.NewRow();

                if (DataRepository.EventsTable.Columns.Contains("Event Name")) newRow["Event Name"] = txtEventName.Text.Trim();
                if (DataRepository.EventsTable.Columns.Contains("Venue")) newRow["Venue"] = cmbVenue.SelectedItem.ToString();
                if (DataRepository.EventsTable.Columns.Contains("Date")) newRow["Date"] = formattedDate;
                if (DataRepository.EventsTable.Columns.Contains("Time")) newRow["Time"] = formattedTime;
                if (DataRepository.EventsTable.Columns.Contains("Status")) newRow["Status"] = status;
                if (DataRepository.EventsTable.Columns.Contains("Bookings")) newRow["Bookings"] = bookingsCount;

                DataRepository.EventsTable.Rows.Add(newRow);
            }

            RefreshEventData();
            MessageBox.Show("Event saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Silently return if no valid row is selected (prevents "No Selection" pop-up)
            if (selectedRowIndex < 0 || selectedRowIndex >= dgvEvents.Rows.Count || dgvEvents.SelectedRows.Count == 0)
            {
                return;
            }

            DataGridViewRow row = dgvEvents.Rows[selectedRowIndex];
            string eventName = row.Cells["Event Name"].Value?.ToString();

            DialogResult result = MessageBox.Show($"Are you sure you want to delete '{eventName}'?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                if (row.DataBoundItem is DataRowView drv)
                {
                    drv.Row.Delete(); // Safely remove from DataRepository
                }

                RefreshEventData();
                MessageBox.Show("Event deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            selectedRowIndex = -1;
            txtEventName.Clear();
            if (cmbVenue.Items.Count > 0) cmbVenue.SelectedIndex = 0;
            dtpEventDate.Value = DateTime.Now;
            if (txtBookings != null) txtBookings.Clear();
            dgvEvents.ClearSelection();
        }

        // --- Status Pill Rendering ---
        private void dgvEvents_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && dgvEvents.Columns[e.ColumnIndex].Name == "Status")
            {
                e.PaintBackground(e.CellBounds, true);

                string status = e.Value?.ToString() ?? "";
                Color pillColor = (status == "Upcoming") ? Color.FromArgb(0, 122, 255) : Color.FromArgb(108, 117, 125);

                Rectangle rect = new Rectangle(e.CellBounds.X + 8, e.CellBounds.Y + 6, e.CellBounds.Width - 16, e.CellBounds.Height - 12);

                using (Brush brush = new SolidBrush(pillColor))
                using (GraphicsPath path = GetRoundedPath(rect, 10))
                using (StringFormat sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                {
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    e.Graphics.FillPath(brush, path);

                    using (Brush textBrush = new SolidBrush(Color.White))
                    {
                        e.Graphics.DrawString(status, dgvEvents.Font, textBrush, rect, sf);
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