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
    public partial class ucClients : UserControl
    {
        private DataTable clientTable;
        private int selectedRowIndex = -1; // -1 indicates adding a new client
        public ucClients()
        {
            InitializeComponent();

            // Run setup in constructor to guarantee immediate render
            ConfigureGrid();
            InitializeData();
            SetupDropdowns();
            ClearForm();

            // Register Event Handlers
            txtSearch.TextChanged += FilterClients;
            cmbTypeFilter.SelectedIndexChanged += FilterClients;
            dgvClients.CellClick += dgvClients_CellClick;
            dgvClients.CellPainting += dgvClients_CellPainting;
        }
        private void ucClients_Load(object sender, EventArgs e)
        {

        }
        // --- 1. Grid Configuration & Initial Data ---
        private void ConfigureGrid()
        {
            dgvClients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvClients.RowHeadersVisible = false;
            dgvClients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClients.AllowUserToAddRows = false;
            dgvClients.RowTemplate.Height = 35;
            dgvClients.ColumnHeadersHeight = 35;
        }

        private void InitializeData()
        {
            clientTable = new DataTable();
            clientTable.Columns.Add("Client ID", typeof(string));
            clientTable.Columns.Add("Full Name", typeof(string));
            clientTable.Columns.Add("Email Address", typeof(string));
            clientTable.Columns.Add("Phone Number", typeof(string));
            clientTable.Columns.Add("Company Name", typeof(string));
            clientTable.Columns.Add("Client Type", typeof(string));
            clientTable.Columns.Add("Status", typeof(string));

            // Populate sample client records
            clientTable.Rows.Add("CLT-1001", "Alice Smith", "alice@techcorp.com", "(555) 019-2831", "TechCorp Inc.", "Corporate", "Active");
            clientTable.Rows.Add("CLT-1002", "Bob Johnson", "b.johnson@gmail.com", "(555) 014-4920", "N/A", "Individual", "Active");
            clientTable.Rows.Add("CLT-1003", "Carol White", "cwhite@innovatex.io", "(555) 018-3319", "InnovateX", "Corporate", "Inactive");
            clientTable.Rows.Add("CLT-1004", "David Lee", "david.lee@outlook.com", "(555) 012-7743", "Board Inc.", "Individual", "Active");

            dgvClients.DataSource = clientTable;
        }

        private void SetupDropdowns()
        {
            // Client Type Form Selection
            cmbClientType.Items.Clear();
            cmbClientType.Items.AddRange(new string[] { "Corporate", "Individual", "VIP" });

            // Client Type Top Filter Selection
            cmbTypeFilter.Items.Clear();
            cmbTypeFilter.Items.Add("All Client Types");
            cmbTypeFilter.Items.AddRange(new string[] { "Corporate", "Individual", "VIP" });
            cmbTypeFilter.SelectedIndex = 0;

            // Status Selection
            cmbStatus.Items.Clear();
            cmbStatus.Items.AddRange(new string[] { "Active", "Inactive" });
        }

        // --- 2. Live Search & Type Filtering ---
        private void FilterClients(object sender, EventArgs e)
        {
            string searchKeyword = txtSearch.Text.Replace("'", "''").Trim();
            if (searchKeyword == "Search Clients..." || searchKeyword == "Search Reservations...") searchKeyword = "";

            string selectedType = cmbTypeFilter.SelectedItem?.ToString();
            string filterExpression = "";

            if (!string.IsNullOrEmpty(searchKeyword))
            {
                filterExpression += $"([Full Name] LIKE '%{searchKeyword}%' OR [Email Address] LIKE '%{searchKeyword}%' OR [Company Name] LIKE '%{searchKeyword}%' OR [Client ID] LIKE '%{searchKeyword}%')";
            }

            if (!string.IsNullOrEmpty(selectedType) && selectedType != "All Client Types")
            {
                if (filterExpression.Length > 0) filterExpression += " AND ";
                filterExpression += $"[Client Type] = '{selectedType}'";
            }

            (dgvClients.DataSource as DataTable).DefaultView.RowFilter = filterExpression;
        }

        // --- 3. Row Selection Handling ---
        private void dgvClients_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            LoadClientToForm(e.RowIndex);
        }

        private void LoadClientToForm(int rowIndex)
        {
            selectedRowIndex = rowIndex;
            DataGridViewRow row = dgvClients.Rows[rowIndex];

            txtFullName.Text = row.Cells["Full Name"].Value?.ToString();
            txtEmail.Text = row.Cells["Email Address"].Value?.ToString();
            txtPhone.Text = row.Cells["Phone Number"].Value?.ToString();
            txtCompany.Text = row.Cells["Company Name"].Value?.ToString();
            cmbClientType.SelectedItem = row.Cells["Client Type"].Value?.ToString();
            cmbStatus.SelectedItem = row.Cells["Status"].Value?.ToString();
        }

        // --- 4. Form Action Buttons ---
        private void btnAddNewClient_Click(object sender, EventArgs e)
        {
            ClearForm();
            txtFullName.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("Please enter the client's Full Name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbClientType.SelectedItem == null || cmbStatus.SelectedItem == null)
            {
                MessageBox.Show("Please select both Client Type and Status.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string companyName = string.IsNullOrWhiteSpace(txtCompany.Text) ? "N/A" : txtCompany.Text.Trim();

            if (selectedRowIndex >= 0 && selectedRowIndex < dgvClients.Rows.Count)
            {
                // Update Existing Client
                DataGridViewRow row = dgvClients.Rows[selectedRowIndex];
                row.Cells["Full Name"].Value = txtFullName.Text.Trim();
                row.Cells["Email Address"].Value = txtEmail.Text.Trim();
                row.Cells["Phone Number"].Value = txtPhone.Text.Trim();
                row.Cells["Company Name"].Value = companyName;
                row.Cells["Client Type"].Value = cmbClientType.SelectedItem.ToString();
                row.Cells["Status"].Value = cmbStatus.SelectedItem.ToString();
            }
            else
            {
                // Add New Client
                string newId = $"CLT-{1000 + clientTable.Rows.Count + 1}";
                clientTable.Rows.Add(
                    newId,
                    txtFullName.Text.Trim(),
                    txtEmail.Text.Trim(),
                    txtPhone.Text.Trim(),
                    companyName,
                    cmbClientType.SelectedItem.ToString(),
                    cmbStatus.SelectedItem.ToString()
                );
            }

            ClearForm();
            MessageBox.Show("Client details saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedRowIndex < 0 || dgvClients.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a client from the table to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string clientName = dgvClients.Rows[selectedRowIndex].Cells["Full Name"].Value?.ToString();

            DialogResult result = MessageBox.Show($"Are you sure you want to delete client '{clientName}'?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                dgvClients.Rows.RemoveAt(selectedRowIndex);
                ClearForm();
                MessageBox.Show("Client deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            selectedRowIndex = -1;
            txtFullName.Clear();
            txtEmail.Clear();
            txtPhone.Clear();
            txtCompany.Clear();
            if (cmbClientType.Items.Count > 0) cmbClientType.SelectedIndex = 0;
            if (cmbStatus.Items.Count > 0) cmbStatus.SelectedIndex = 0;
            dgvClients.ClearSelection();
        }

        // --- 5. Status Pill Custom Rendering ---
        private void dgvClients_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && dgvClients.Columns[e.ColumnIndex].Name == "Status")
            {
                e.PaintBackground(e.CellBounds, true);

                string status = e.Value?.ToString() ?? "";
                Color pillColor = (status == "Active") ? Color.FromArgb(40, 167, 69) : Color.FromArgb(108, 117, 125);

                Rectangle rect = new Rectangle(e.CellBounds.X + 8, e.CellBounds.Y + 6, e.CellBounds.Width - 16, e.CellBounds.Height - 12);

                using (Brush brush = new SolidBrush(pillColor))
                using (GraphicsPath path = GetRoundedPath(rect, 10))
                using (StringFormat sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                {
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    e.Graphics.FillPath(brush, path);

                    using (Brush textBrush = new SolidBrush(Color.White))
                    {
                        e.Graphics.DrawString(status, dgvClients.Font, textBrush, rect, sf);
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
