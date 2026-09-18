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
        private DataTable reservationTable;
        private int selectedRowIndex = -1; // -1 indicates adding a new reservation
        public ucReservations()
        {
            InitializeComponent();

            // Run setup directly in constructor to guarantee immediate load
            ConfigureGrid();
            InitializeData();
            SetupDropdowns();
            ClearForm();

            // Register Event Handlers
            txtSearch.TextChanged += FilterReservations;
            cmbStatusFilter.SelectedIndexChanged += FilterReservations;
            dgvReservations.CellClick += dgvReservations_CellClick;
            dgvReservations.CellPainting += dgvReservations_CellPainting;
        }

        private void ucReservations_Load(object sender, EventArgs e)
        {

        }
        private void ConfigureGrid()
        {
            numTotalAmount.Minimum = 0;
            numTotalAmount.Maximum = 100000;
            numTotalAmount.DecimalPlaces = 2;

            dgvReservations.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReservations.RowHeadersVisible = false;
            dgvReservations.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReservations.AllowUserToAddRows = false;
            dgvReservations.RowTemplate.Height = 35;
            dgvReservations.ColumnHeadersHeight = 35;
        }

        private void InitializeData()
        {
            reservationTable = new DataTable();
            reservationTable.Columns.Add("Reservation ID", typeof(string));
            reservationTable.Columns.Add("Client Name", typeof(string));
            reservationTable.Columns.Add("Event Name", typeof(string));
            reservationTable.Columns.Add("Reservation Date", typeof(string));
            reservationTable.Columns.Add("Total Amount ($)", typeof(string));
            reservationTable.Columns.Add("Status", typeof(string));
            reservationTable.Columns.Add("Notes", typeof(string));

            // Populate sample data
            reservationTable.Rows.Add("RES-1001", "Alice Smith", "Annual Tech Summit", "2026-10-15", "$1,200.00", "Confirmed", "Full deposit paid.");
            reservationTable.Rows.Add("RES-1002", "Bob Johnson", "Corporate Gala", "2026-11-02", "$2,500.00", "Pending", "Awaiting client confirmation.");
            reservationTable.Rows.Add("RES-1003", "Carol White", "Product Launch", "2026-09-01", "$850.00", "Cancelled", "Client requested cancellation.");
            reservationTable.Rows.Add("RES-1004", "David Lee", "Executive Meeting", "2026-09-10", "$500.00", "Confirmed", "Paid via Credit Card.");

            dgvReservations.DataSource = reservationTable;
        }

        private void SetupDropdowns()
        {
            // Clients
            cmbClient.Items.Clear();
            cmbClient.Items.AddRange(new string[] { "Alice Smith", "Bob Johnson", "Carol White", "David Lee", "Smith Family" });

            // Events
            cmbEvent.Items.Clear();
            cmbEvent.Items.AddRange(new string[] { "Annual Tech Summit", "Corporate Gala", "Product Launch", "Executive Meeting", "Wedding Reception" });

            // Status Form Selection
            cmbStatus.Items.Clear();
            cmbStatus.Items.AddRange(new string[] { "Pending", "Confirmed", "Cancelled" });

            // Status Top Filter
            cmbStatusFilter.Items.Clear();
            cmbStatusFilter.Items.Add("All Statuses");
            cmbStatusFilter.Items.AddRange(new string[] { "Pending", "Confirmed", "Cancelled" });
            cmbStatusFilter.SelectedIndex = 0;
        }

        // --- 2. Real-Time Search & Status Filtering ---
        private void FilterReservations(object sender, EventArgs e)
        {
            string searchKeyword = txtSearch.Text.Replace("'", "''").Trim();
            if (searchKeyword == "Search Reservations...") searchKeyword = "";

            string selectedStatus = cmbStatusFilter.SelectedItem?.ToString();
            string filterExpression = "";

            if (!string.IsNullOrEmpty(searchKeyword))
            {
                filterExpression += $"([Client Name] LIKE '%{searchKeyword}%' OR [Event Name] LIKE '%{searchKeyword}%' OR [Reservation ID] LIKE '%{searchKeyword}%')";
            }

            if (!string.IsNullOrEmpty(selectedStatus) && selectedStatus != "All Statuses")
            {
                if (filterExpression.Length > 0) filterExpression += " AND ";
                filterExpression += $"[Status] = '{selectedStatus}'";
            }

            (dgvReservations.DataSource as DataTable).DefaultView.RowFilter = filterExpression;
        }

        // --- 3. Selection & Data Binding ---
        private void dgvReservations_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            LoadReservationToForm(e.RowIndex);
        }

        private void LoadReservationToForm(int rowIndex)
        {
            selectedRowIndex = rowIndex;
            DataGridViewRow row = dgvReservations.Rows[rowIndex];

            cmbClient.SelectedItem = row.Cells["Client Name"].Value?.ToString();
            cmbEvent.SelectedItem = row.Cells["Event Name"].Value?.ToString();
            cmbStatus.SelectedItem = row.Cells["Status"].Value?.ToString();
            txtNotes.Text = row.Cells["Notes"].Value?.ToString();

            if (DateTime.TryParse(row.Cells["Reservation Date"].Value?.ToString(), out DateTime parsedDate))
            {
                dtpReservationDate.Value = parsedDate;
            }

            string rawAmount = row.Cells["Total Amount ($)"].Value?.ToString().Replace("$", "").Replace(",", "").Trim();
            if (decimal.TryParse(rawAmount, out decimal amount))
            {
                numTotalAmount.Value = amount;
            }
        }

        // --- 4. CRUD Actions ---
        private void btnAddNewReservation_Click(object sender, EventArgs e)
        {
            ClearForm();
            cmbClient.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbClient.SelectedItem == null || cmbEvent.SelectedItem == null || cmbStatus.SelectedItem == null)
            {
                MessageBox.Show("Please fill out all required dropdown fields (Client, Event, Status).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string formattedAmount = $"${numTotalAmount.Value:N2}";
            string formattedDate = dtpReservationDate.Value.ToString("yyyy-MM-dd");

            if (selectedRowIndex >= 0 && selectedRowIndex < dgvReservations.Rows.Count)
            {
                // Update Existing
                DataGridViewRow row = dgvReservations.Rows[selectedRowIndex];
                row.Cells["Client Name"].Value = cmbClient.SelectedItem.ToString();
                row.Cells["Event Name"].Value = cmbEvent.SelectedItem.ToString();
                row.Cells["Reservation Date"].Value = formattedDate;
                row.Cells["Total Amount ($)"].Value = formattedAmount;
                row.Cells["Status"].Value = cmbStatus.SelectedItem.ToString();
                row.Cells["Notes"].Value = txtNotes.Text;
            }
            else
            {
                // Add New
                string newId = $"RES-{1000 + reservationTable.Rows.Count + 1}";
                reservationTable.Rows.Add(
                    newId,
                    cmbClient.SelectedItem.ToString(),
                    cmbEvent.SelectedItem.ToString(),
                    formattedDate,
                    formattedAmount,
                    cmbStatus.SelectedItem.ToString(),
                    txtNotes.Text
                );
            }

            ClearForm();
            MessageBox.Show("Reservation saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedRowIndex < 0 || dgvReservations.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a reservation from the table to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string resId = dgvReservations.Rows[selectedRowIndex].Cells["Reservation ID"].Value?.ToString();

            DialogResult result = MessageBox.Show($"Are you sure you want to delete reservation '{resId}'?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                dgvReservations.Rows.RemoveAt(selectedRowIndex);
                ClearForm();
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
            if (cmbStatus.Items.Count > 0) cmbStatus.SelectedIndex = 0;
            dtpReservationDate.Value = DateTime.Now;
            numTotalAmount.Value = 0;
            txtNotes.Clear();
            dgvReservations.ClearSelection();
        }

        // --- 5. Custom Status Pill Rendering ---
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
