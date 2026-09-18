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
    public partial class ucReservations : UserControl
    {
        private int selectedRowIndex = -1; // -1 indicates adding a new reservation

        public ucReservations()
        {
            InitializeComponent();

            ConfigureGrid();

            // Register Event Handlers safely
            if (txtSearch != null) txtSearch.TextChanged += FilterReservations;
            if (cmbStatusFilter != null) cmbStatusFilter.SelectedIndexChanged += FilterReservations;

            if (dgvReservations != null)
            {
                dgvReservations.CellClick += dgvReservations_CellClick;
                dgvReservations.CellPainting += dgvReservations_CellPainting;
            }

            if (btnAddNewReservation != null) btnAddNewReservation.Click += btnAddNewReservation_Click;
            if (btnSave != null) btnSave.Click += btnSave_Click;
            if (btnDelete != null) btnDelete.Click += btnDelete_Click;
            if (btnCancel != null) btnCancel.Click += btnCancel_Click;
        }

        private void ucReservations_Load(object sender, EventArgs e)
        {
            RefreshReservationData();
        }

        // Auto-refresh dropdowns and grid when switching tabs
        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            if (this.Visible)
            {
                RefreshReservationData();
            }
        }

        public void RefreshReservationData()
        {
            SetupDropdowns();

            // Bind directly to central DataRepository
            dgvReservations.DataSource = null;
            dgvReservations.AutoGenerateColumns = true;
            dgvReservations.DataSource = DataRepository.ReservationsTable;

            ClearForm();
        }

        private void ConfigureGrid()
        {
            if (numTotalAmount != null)
            {
                numTotalAmount.Minimum = 0;
                numTotalAmount.Maximum = 100000;
                numTotalAmount.DecimalPlaces = 2;
            }

            dgvReservations.AutoGenerateColumns = true;
            dgvReservations.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReservations.RowHeadersVisible = false;
            dgvReservations.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReservations.AllowUserToAddRows = false;
            dgvReservations.RowTemplate.Height = 35;
            dgvReservations.ColumnHeadersHeight = 35;
        }

        private void SetupDropdowns()
        {
            // Populate Clients from DataRepository
            cmbClient.Items.Clear();
            if (DataRepository.ClientsTable != null)
            {
                foreach (DataRow row in DataRepository.ClientsTable.Rows)
                {
                    string clientName = row["Client Name"]?.ToString();
                    if (!string.IsNullOrEmpty(clientName) && !cmbClient.Items.Contains(clientName))
                    {
                        cmbClient.Items.Add(clientName);
                    }
                }
            }

            // Populate Events from DataRepository
            cmbEvent.Items.Clear();
            if (DataRepository.EventsTable != null)
            {
                foreach (DataRow row in DataRepository.EventsTable.Rows)
                {
                    string eventName = row["Event Name"]?.ToString();
                    if (!string.IsNullOrEmpty(eventName) && !cmbEvent.Items.Contains(eventName))
                    {
                        cmbEvent.Items.Add(eventName);
                    }
                }
            }

            // Populate Venues from DataRepository
            cmbVenue.Items.Clear();
            if (DataRepository.VenuesTable != null)
            {
                foreach (DataRow row in DataRepository.VenuesTable.Rows)
                {
                    string venueName = row["Venue Name"]?.ToString();
                    if (!string.IsNullOrEmpty(venueName) && !cmbVenue.Items.Contains(venueName))
                    {
                        cmbVenue.Items.Add(venueName);
                    }
                }
            }

            // Status Form Selection
            cmbStatus.Items.Clear();
            cmbStatus.Items.AddRange(new string[] { "Pending", "Confirmed", "Cancelled" });

            // Status Top Filter
            cmbStatusFilter.Items.Clear();
            cmbStatusFilter.Items.Add("All Statuses");
            cmbStatusFilter.Items.AddRange(new string[] { "Pending", "Confirmed", "Cancelled" });
            cmbStatusFilter.SelectedIndex = 0;
        }

        // --- Real-Time Search & Status Filtering ---
        private void FilterReservations(object sender, EventArgs e)
        {
            if (dgvReservations.DataSource is DataTable dt)
            {
                string searchKeyword = txtSearch.Text.Replace("'", "''").Trim();
                if (searchKeyword == "Search Reservations...") searchKeyword = "";

                string selectedStatus = cmbStatusFilter.SelectedItem?.ToString();
                string filterExpression = "";

                if (!string.IsNullOrEmpty(searchKeyword))
                {
                    List<string> searchableCols = new List<string>();
                    if (dt.Columns.Contains("Client Name")) searchableCols.Add($"[Client Name] LIKE '%{searchKeyword}%'");
                    if (dt.Columns.Contains("Event Name")) searchableCols.Add($"[Event Name] LIKE '%{searchKeyword}%'");
                    if (dt.Columns.Contains("Venue")) searchableCols.Add($"[Venue] LIKE '%{searchKeyword}%'");
                    if (dt.Columns.Contains("Reservation ID")) searchableCols.Add($"[Reservation ID] LIKE '%{searchKeyword}%'");

                    if (searchableCols.Count > 0)
                    {
                        filterExpression += $"({string.Join(" OR ", searchableCols)})";
                    }
                }

                if (!string.IsNullOrEmpty(selectedStatus) && selectedStatus != "All Statuses" && dt.Columns.Contains("Status"))
                {
                    if (filterExpression.Length > 0) filterExpression += " AND ";
                    filterExpression += $"[Status] = '{selectedStatus}'";
                }

                dt.DefaultView.RowFilter = filterExpression;
            }
        }

        // --- Selection & Data Binding ---
        private void dgvReservations_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            LoadReservationToForm(e.RowIndex);
        }

        private void LoadReservationToForm(int rowIndex)
        {
            selectedRowIndex = rowIndex;
            DataGridViewRow row = dgvReservations.Rows[rowIndex];

            if (dgvReservations.Columns.Contains("Client Name")) cmbClient.SelectedItem = row.Cells["Client Name"].Value?.ToString();
            if (dgvReservations.Columns.Contains("Event Name")) cmbEvent.SelectedItem = row.Cells["Event Name"].Value?.ToString();
            if (dgvReservations.Columns.Contains("Venue")) cmbVenue.SelectedItem = row.Cells["Venue"].Value?.ToString();
            if (dgvReservations.Columns.Contains("Status")) cmbStatus.SelectedItem = row.Cells["Status"].Value?.ToString();

            string dateCol = dgvReservations.Columns.Contains("Reservation Date") ? "Reservation Date" : "Date";
            if (dgvReservations.Columns.Contains(dateCol) && DateTime.TryParse(row.Cells[dateCol].Value?.ToString(), out DateTime parsedDate))
            {
                dtpReservationDate.Value = parsedDate;
            }

            string amountCol = dgvReservations.Columns.Contains("Total Amount ($)") ? "Total Amount ($)" :
                                dgvReservations.Columns.Contains("Total Amount") ? "Total Amount" : "Amount";

            if (dgvReservations.Columns.Contains(amountCol))
            {
                string rawAmount = row.Cells[amountCol].Value?.ToString().Replace("$", "").Replace(",", "").Trim();
                if (decimal.TryParse(rawAmount, out decimal amount))
                {
                    numTotalAmount.Value = amount;
                }
            }
        }

        // --- CRUD Actions ---
        private void btnAddNewReservation_Click(object sender, EventArgs e)
        {
            ClearForm();
            cmbClient.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbClient.SelectedItem == null || cmbEvent.SelectedItem == null || cmbVenue.SelectedItem == null || cmbStatus.SelectedItem == null)
            {
                return; // Return silently without popup
            }

            string formattedAmount = $"${numTotalAmount.Value:N2}";
            string formattedDate = dtpReservationDate.Value.ToString("yyyy-MM-dd");

            if (selectedRowIndex >= 0 && selectedRowIndex < dgvReservations.Rows.Count)
            {
                // Update Existing Row
                DataGridViewRow gridRow = dgvReservations.Rows[selectedRowIndex];
                if (gridRow.DataBoundItem is DataRowView drv)
                {
                    if (drv.Row.Table.Columns.Contains("Client Name")) drv["Client Name"] = cmbClient.SelectedItem.ToString();
                    if (drv.Row.Table.Columns.Contains("Event Name")) drv["Event Name"] = cmbEvent.SelectedItem.ToString();
                    if (drv.Row.Table.Columns.Contains("Venue")) drv["Venue"] = cmbVenue.SelectedItem.ToString();

                    if (drv.Row.Table.Columns.Contains("Reservation Date")) drv["Reservation Date"] = formattedDate;
                    else if (drv.Row.Table.Columns.Contains("Date")) drv["Date"] = formattedDate;

                    if (drv.Row.Table.Columns.Contains("Total Amount ($)")) drv["Total Amount ($)"] = formattedAmount;
                    else if (drv.Row.Table.Columns.Contains("Total Amount")) drv["Total Amount"] = formattedAmount;
                    else if (drv.Row.Table.Columns.Contains("Amount")) drv["Amount"] = formattedAmount;

                    if (drv.Row.Table.Columns.Contains("Status")) drv["Status"] = cmbStatus.SelectedItem.ToString();
                }
            }
            else
            {
                // Add New Row matching DataRepository schema
                DataRow newRow = DataRepository.ReservationsTable.NewRow();

                if (DataRepository.ReservationsTable.Columns.Contains("Reservation ID"))
                {
                    newRow["Reservation ID"] = $"RES-00{DataRepository.ReservationsTable.Rows.Count + 1}";
                }

                if (DataRepository.ReservationsTable.Columns.Contains("Client Name")) newRow["Client Name"] = cmbClient.SelectedItem.ToString();
                if (DataRepository.ReservationsTable.Columns.Contains("Event Name")) newRow["Event Name"] = cmbEvent.SelectedItem.ToString();
                if (DataRepository.ReservationsTable.Columns.Contains("Venue")) newRow["Venue"] = cmbVenue.SelectedItem.ToString();

                if (DataRepository.ReservationsTable.Columns.Contains("Reservation Date")) newRow["Reservation Date"] = formattedDate;
                else if (DataRepository.ReservationsTable.Columns.Contains("Date")) newRow["Date"] = formattedDate;

                if (DataRepository.ReservationsTable.Columns.Contains("Total Amount ($)")) newRow["Total Amount ($)"] = formattedAmount;
                else if (DataRepository.ReservationsTable.Columns.Contains("Total Amount")) newRow["Total Amount"] = formattedAmount;
                else if (DataRepository.ReservationsTable.Columns.Contains("Amount")) newRow["Amount"] = formattedAmount;

                if (DataRepository.ReservationsTable.Columns.Contains("Status")) newRow["Status"] = cmbStatus.SelectedItem.ToString();

                DataRepository.ReservationsTable.Rows.Add(newRow);
            }

            RefreshReservationData();
            MessageBox.Show("Reservation saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Return silently if no row selected
            if (selectedRowIndex < 0 || selectedRowIndex >= dgvReservations.Rows.Count || dgvReservations.SelectedRows.Count == 0)
            {
                return;
            }

            DataGridViewRow row = dgvReservations.Rows[selectedRowIndex];
            string resId = dgvReservations.Columns.Contains("Reservation ID") ? row.Cells["Reservation ID"].Value?.ToString() : "selected reservation";

            DialogResult result = MessageBox.Show($"Are you sure you want to delete reservation '{resId}'?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                if (row.DataBoundItem is DataRowView drv)
                {
                    drv.Row.Delete();
                }

                RefreshReservationData();
                MessageBox.Show("Reservation deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            selectedRowIndex = -1;
            if (cmbClient.Items.Count > 0) cmbClient.SelectedIndex = -1;
            if (cmbEvent.Items.Count > 0) cmbEvent.SelectedIndex = -1;
            if (cmbVenue.Items.Count > 0) cmbVenue.SelectedIndex = -1;
            if (cmbStatus.Items.Count > 0) cmbStatus.SelectedIndex = 0;
            dtpReservationDate.Value = DateTime.Now;
            numTotalAmount.Value = 0;
            dgvReservations.ClearSelection();
        }

        // --- Custom Status Pill Rendering ---
        private void dgvReservations_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && dgvReservations.Columns[e.ColumnIndex].Name == "Status")
            {
                e.PaintBackground(e.CellBounds, true);

                string status = e.Value?.ToString() ?? "";
                Color pillColor;

                switch (status)
                {
                    case "Confirmed":
                        pillColor = Color.FromArgb(40, 167, 69); // Green
                        break;
                    case "Pending":
                        pillColor = Color.FromArgb(255, 193, 7); // Yellow
                        break;
                    case "Cancelled":
                        pillColor = Color.FromArgb(220, 53, 69); // Red
                        break;
                    default:
                        pillColor = Color.Gray;
                        break;
                }

                Rectangle rect = new Rectangle(e.CellBounds.X + 8, e.CellBounds.Y + 6, e.CellBounds.Width - 16, e.CellBounds.Height - 12);

                using (Brush brush = new SolidBrush(pillColor))
                using (GraphicsPath path = GetRoundedPath(rect, 10))
                using (StringFormat sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                {
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    e.Graphics.FillPath(brush, path);

                    Color textColor = (status == "Pending") ? Color.Black : Color.White;
                    using (Brush textBrush = new SolidBrush(textColor))
                    {
                        e.Graphics.DrawString(status, dgvReservations.Font, textBrush, rect, sf);
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