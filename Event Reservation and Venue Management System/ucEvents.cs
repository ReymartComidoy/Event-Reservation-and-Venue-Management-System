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
        private DataTable eventTable;
        private int selectedRowIndex = -1; // Tracks which row is being edited (-1 = New Event)

        public ucEvents()
        {
            InitializeComponent();

            // Call setup methods directly inside the constructor
            ConfigureGrid();
            InitializeData();
            SetupDropdowns();
            ClearForm();

            // Register Event Handlers
            txtSearch.TextChanged += FilterEvents;
            cmbVenueFilter.SelectedIndexChanged += FilterEvents;
            dgvEvents.CellClick += dgvEvents_CellClick;
            dgvEvents.CellPainting += dgvEvents_CellPainting;
        }

        private void ucEvents_Load(object sender, EventArgs e)
        {

        }

        // --- 1. Grid Configuration & Sample Data ---
        private void ConfigureGrid()
        {
            dgvEvents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEvents.RowHeadersVisible = false;
            dgvEvents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEvents.AllowUserToAddRows = false;
            dgvEvents.RowTemplate.Height = 35;
            dgvEvents.ColumnHeadersHeight = 35;
        }

        private void InitializeData()
        {
            eventTable = new DataTable();
            eventTable.Columns.Add("Event Name", typeof(string));
            eventTable.Columns.Add("Venue", typeof(string));
            eventTable.Columns.Add("Organizer", typeof(string));
            eventTable.Columns.Add("Date", typeof(string));
            eventTable.Columns.Add("Status", typeof(string));
            eventTable.Columns.Add("Description", typeof(string));

            // Pre-populate sample event data
            eventTable.Rows.Add("Annual Tech Summit", "Grand Ballroom", "TechCorp", "2026-10-15", "Upcoming", "Global tech conference.");
            eventTable.Rows.Add("Corporate Gala", "Auditorium", "Lune Events", "2026-11-02", "Upcoming", "Annual charity gala evening.");
            eventTable.Rows.Add("Product Launch", "Garden Terrace", "InnovateX", "2026-09-01", "Completed", "New smartphone release.");
            eventTable.Rows.Add("Executive Meeting", "Executive Boardroom", "Board Inc.", "2026-09-10", "Completed", "Q3 strategy review.");
            eventTable.Rows.Add("Wedding Reception", "Outdoor Pavilion", "Smith Family", "2026-12-05", "Upcoming", "Private wedding reception.");

            dgvEvents.DataSource = eventTable;
        }

        private void SetupDropdowns()
        {
            // Populate Venue selection list
            string[] venues = new string[] {
                "Grand Ballroom",
                "Grand Ballroom B",
                "Auditorium",
                "Garden Terrace",
                "Conference Rm A",
                "VIP Lounge",
                "Outdoor Pavilion",
                "Executive Boardroom"
            };

            cmbVenue.Items.Clear();
            cmbVenue.Items.AddRange(venues);

            // Populate Filter dropdown
            cmbVenueFilter.Items.Clear();
            cmbVenueFilter.Items.Add("All Venues");
            cmbVenueFilter.Items.AddRange(venues);
            cmbVenueFilter.SelectedIndex = 0;
        }

        // --- 2. Real-Time Search & Venue Filtering ---
        private void FilterEvents(object sender, EventArgs e)
        {
            string searchKeyword = txtSearch.Text.Replace("'", "''").Trim();
            if (searchKeyword == "Search Events...") searchKeyword = "";

            string selectedVenue = cmbVenueFilter.SelectedItem?.ToString();

            string filterExpression = "";

            if (!string.IsNullOrEmpty(searchKeyword))
            {
                filterExpression += $"([Event Name] LIKE '%{searchKeyword}%' OR [Organizer] LIKE '%{searchKeyword}%')";
            }

            if (!string.IsNullOrEmpty(selectedVenue) && selectedVenue != "All Venues")
            {
                if (filterExpression.Length > 0) filterExpression += " AND ";
                filterExpression += $"[Venue] = '{selectedVenue.Replace("'", "''")}'";
            }

            (dgvEvents.DataSource as DataTable).DefaultView.RowFilter = filterExpression;
        }

        // --- 3. Grid Selection Handling ---
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
            cmbVenue.SelectedItem = row.Cells["Venue"].Value?.ToString();
            txtDescription.Text = row.Cells["Description"].Value?.ToString();

            if (DateTime.TryParse(row.Cells["Date"].Value?.ToString(), out DateTime parsedDate))
            {
                dtpEventDate.Value = parsedDate;
            }
        }

        // --- 4. CRUD Action Buttons ---
        private void btnAddNewEvent_Click(object sender, EventArgs e)
        {
            ClearForm();
            txtEventName.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEventName.Text))
            {
                MessageBox.Show("Please enter an Event Name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbVenue.SelectedItem == null)
            {
                MessageBox.Show("Please select a Venue.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string formattedDate = dtpEventDate.Value.ToString("yyyy-MM-dd");
            string status = dtpEventDate.Value.Date >= DateTime.Now.Date ? "Upcoming" : "Completed";

            if (selectedRowIndex >= 0 && selectedRowIndex < dgvEvents.Rows.Count)
            {
                // Update Existing Event
                DataGridViewRow row = dgvEvents.Rows[selectedRowIndex];
                row.Cells["Event Name"].Value = txtEventName.Text;
                row.Cells["Venue"].Value = cmbVenue.SelectedItem.ToString();
                row.Cells["Date"].Value = formattedDate;
                row.Cells["Status"].Value = status;
                row.Cells["Description"].Value = txtDescription.Text;
            }
            else
            {
                // Add New Event
                eventTable.Rows.Add(
                    txtEventName.Text,
                    cmbVenue.SelectedItem.ToString(),
                    "Internal", // Default Organizer value
                    formattedDate,
                    status,
                    txtDescription.Text
                );
            }

            ClearForm();
            MessageBox.Show("Event saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Ensure a row is selected before attempting deletion
            if (selectedRowIndex < 0 || dgvEvents.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an event from the list to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string eventName = dgvEvents.Rows[selectedRowIndex].Cells["Event Name"].Value?.ToString();

            // Confirmation dialog
            DialogResult result = MessageBox.Show($"Are you sure you want to delete '{eventName}'?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                // Remove from DataGridView / DataTable
                dgvEvents.Rows.RemoveAt(selectedRowIndex);
                ClearForm();
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
            txtDescription.Clear();
            dgvEvents.ClearSelection();
        }

        // --- 5. Status Pill Custom Rendering ---
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
