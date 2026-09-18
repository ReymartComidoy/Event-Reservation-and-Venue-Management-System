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
        private int selectedRowIndex = -1; // -1 indicates adding a new client

        public ucClients()
        {
            InitializeComponent();

            // Run setup in constructor
            ConfigureGrid();
            SetupDropdowns();

            // Register Event Handlers safely
            if (txtSearch != null) txtSearch.TextChanged += FilterClients;
            if (cmbTypeFilter != null) cmbTypeFilter.SelectedIndexChanged += FilterClients;

            if (dgvClients != null)
            {
                dgvClients.CellClick += dgvClients_CellClick;
                dgvClients.CellPainting += dgvClients_CellPainting;
            }

            if (btnAddNewClient != null) btnAddNewClient.Click += btnAddNewClient_Click;
            if (btnSave != null) btnSave.Click += btnSave_Click;
            if (btnDelete != null) btnDelete.Click += btnDelete_Click;
            if (btnCancel != null) btnCancel.Click += btnCancel_Click;
        }

        private void ucClients_Load(object sender, EventArgs e)
        {
            RefreshClientData();
        }

        // Auto-refresh data when switching to this UserControl tab
        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            if (this.Visible)
            {
                RefreshClientData();
            }
        }

        public void RefreshClientData()
        {
            // Bind directly to central DataRepository
            if (dgvClients != null)
            {
                dgvClients.DataSource = null;
                dgvClients.AutoGenerateColumns = true;
                dgvClients.DataSource = DataRepository.ClientsTable;
            }

            ClearForm();
        }

        // --- 1. Grid Configuration ---
        private void ConfigureGrid()
        {
            if (dgvClients == null) return;

            dgvClients.AutoGenerateColumns = true;
            dgvClients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvClients.RowHeadersVisible = false;
            dgvClients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClients.AllowUserToAddRows = false;
            dgvClients.RowTemplate.Height = 35;
            dgvClients.ColumnHeadersHeight = 35;
        }

        private void SetupDropdowns()
        {
            // Client Type Form Selection
            if (cmbClientType != null)
            {
                cmbClientType.Items.Clear();
                cmbClientType.Items.AddRange(new string[] { "Corporate", "Individual", "VIP" });
            }

            // Client Type Top Filter Selection
            if (cmbTypeFilter != null)
            {
                cmbTypeFilter.Items.Clear();
                cmbTypeFilter.Items.Add("All Client Types");
                cmbTypeFilter.Items.AddRange(new string[] { "Corporate", "Individual", "VIP" });
                cmbTypeFilter.SelectedIndex = 0;
            }

            // Status Selection
            if (cmbStatus != null)
            {
                cmbStatus.Items.Clear();
                cmbStatus.Items.AddRange(new string[] { "Active", "Inactive" });
            }
        }

        // --- 2. Live Search & Type Filtering ---
        private void FilterClients(object sender, EventArgs e)
        {
            if (dgvClients?.DataSource is DataTable dt)
            {
                string searchKeyword = txtSearch.Text.Replace("'", "''").Trim();
                if (searchKeyword == "Search Clients...") searchKeyword = "";

                string selectedType = cmbTypeFilter.SelectedItem?.ToString();
                string filterExpression = "";

                if (!string.IsNullOrEmpty(searchKeyword))
                {
                    List<string> searchableCols = new List<string>();
                    if (dt.Columns.Contains("Client Name")) searchableCols.Add($"[Client Name] LIKE '%{searchKeyword}%'");
                    if (dt.Columns.Contains("Email Address")) searchableCols.Add($"[Email Address] LIKE '%{searchKeyword}%'");
                    if (dt.Columns.Contains("Company Name")) searchableCols.Add($"[Company Name] LIKE '%{searchKeyword}%'");
                    if (dt.Columns.Contains("Client ID")) searchableCols.Add($"[Client ID] LIKE '%{searchKeyword}%'");

                    if (searchableCols.Count > 0)
                    {
                        filterExpression += $"({string.Join(" OR ", searchableCols)})";
                    }
                }

                if (!string.IsNullOrEmpty(selectedType) && selectedType != "All Client Types" && dt.Columns.Contains("Client Type"))
                {
                    if (filterExpression.Length > 0) filterExpression += " AND ";
                    filterExpression += $"[Client Type] = '{selectedType}'";
                }

                dt.DefaultView.RowFilter = filterExpression;
            }
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

            if (dgvClients.Columns.Contains("Client Name")) txtFullName.Text = row.Cells["Client Name"].Value?.ToString();
            if (dgvClients.Columns.Contains("Email Address")) txtEmail.Text = row.Cells["Email Address"].Value?.ToString();
            if (dgvClients.Columns.Contains("Phone Number")) txtPhone.Text = row.Cells["Phone Number"].Value?.ToString();
            if (dgvClients.Columns.Contains("Company Name")) txtCompany.Text = row.Cells["Company Name"].Value?.ToString();

            if (dgvClients.Columns.Contains("Client Type") && cmbClientType != null)
            {
                cmbClientType.SelectedItem = row.Cells["Client Type"].Value?.ToString();
            }

            if (dgvClients.Columns.Contains("Status") && cmbStatus != null)
            {
                cmbStatus.SelectedItem = row.Cells["Status"].Value?.ToString();
            }
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
                return; // Return silently without popup
            }

            if (cmbClientType.SelectedItem == null || cmbStatus.SelectedItem == null)
            {
                MessageBox.Show("Please select both Client Type and Status.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string companyName = string.IsNullOrWhiteSpace(txtCompany.Text) ? "N/A" : txtCompany.Text.Trim();
            string fullName = txtFullName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string clientType = cmbClientType.SelectedItem.ToString();
            string status = cmbStatus.SelectedItem.ToString();

            if (selectedRowIndex >= 0 && selectedRowIndex < dgvClients.Rows.Count)
            {
                // Update Existing Client Row
                DataGridViewRow gridRow = dgvClients.Rows[selectedRowIndex];
                if (gridRow.DataBoundItem is DataRowView drv)
                {
                    if (drv.Row.Table.Columns.Contains("Client Name")) drv["Client Name"] = fullName;
                    if (drv.Row.Table.Columns.Contains("Email Address")) drv["Email Address"] = email;
                    if (drv.Row.Table.Columns.Contains("Phone Number")) drv["Phone Number"] = phone;
                    if (drv.Row.Table.Columns.Contains("Company Name")) drv["Company Name"] = companyName;
                    if (drv.Row.Table.Columns.Contains("Client Type")) drv["Client Type"] = clientType;
                    if (drv.Row.Table.Columns.Contains("Status")) drv["Status"] = status;
                }
            }
            else
            {
                // Add New Client to shared DataRepository
                string newId = $"CLT-{1000 + DataRepository.ClientsTable.Rows.Count + 1}";
                DataRow newRow = DataRepository.ClientsTable.NewRow();

                if (DataRepository.ClientsTable.Columns.Contains("Client ID")) newRow["Client ID"] = newId;
                if (DataRepository.ClientsTable.Columns.Contains("Client Name")) newRow["Client Name"] = fullName;
                if (DataRepository.ClientsTable.Columns.Contains("Email Address")) newRow["Email Address"] = email;
                if (DataRepository.ClientsTable.Columns.Contains("Phone Number")) newRow["Phone Number"] = phone;
                if (DataRepository.ClientsTable.Columns.Contains("Company Name")) newRow["Company Name"] = companyName;
                if (DataRepository.ClientsTable.Columns.Contains("Client Type")) newRow["Client Type"] = clientType;
                if (DataRepository.ClientsTable.Columns.Contains("Status")) newRow["Status"] = status;

                DataRepository.ClientsTable.Rows.Add(newRow);
            }

            RefreshClientData();
            MessageBox.Show("Client details saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedRowIndex < 0 || selectedRowIndex >= dgvClients.Rows.Count || dgvClients.SelectedRows.Count == 0)
            {
                return; // Return silently if no row selected
            }

            DataGridViewRow row = dgvClients.Rows[selectedRowIndex];
            string clientName = dgvClients.Columns.Contains("Client Name") ? row.Cells["Client Name"].Value?.ToString() : "selected client";

            DialogResult result = MessageBox.Show($"Are you sure you want to delete client '{clientName}'?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                if (row.DataBoundItem is DataRowView drv)
                {
                    drv.Row.Delete();
                }

                RefreshClientData();
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
            if (cmbClientType != null && cmbClientType.Items.Count > 0) cmbClientType.SelectedIndex = 0;
            if (cmbStatus != null && cmbStatus.Items.Count > 0) cmbStatus.SelectedIndex = 0;
            if (dgvClients != null) dgvClients.ClearSelection();
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