using System;
using System.Data;
using System.Windows.Forms;
using Event_Reservation_and_Venue_Management_System.Services;

namespace Event_Reservation_and_Venue_Management_System.Controls
{
    public partial class ucClients : UserControl
    {
        private readonly ClientService _clientService = new();
        private DataTable _clients = new();

        public ucClients()
        {
            InitializeComponent();
            WireUpEvents();
        }

        private void WireUpEvents()
        {
            this.Load += ucClients_Load;
            btnSave.Click += btnSave_Click;
            btnDelete.Click += btnDelete_Click;
            btnCancel.Click += btnCancel_Click;
            dgvClients.SelectionChanged += dgvClients_SelectionChanged;
        }

        private void ucClients_Load(object? sender, EventArgs e)
        {
            LoadClients();
        }

        private void LoadClients()
        {
            try
            {
                _clients = _clientService.GetAll();
                dgvClients.DataSource = _clients;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unable to load clients.\n\n{ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvClients_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgvClients.CurrentRow != null && dgvClients.CurrentRow.Index >= 0)
            {
                DataGridViewRow row = dgvClients.CurrentRow;
                txtFullName.Text = row.Cells["ClientName"].Value?.ToString();
                txtEmail.Text = row.Cells["Email"].Value?.ToString();
                txtPhone.Text = row.Cells["Phone"].Value?.ToString();
                txtCompany.Text = row.Cells["Company"].Value?.ToString();
                cmbClientType.SelectedItem = row.Cells["ClientType"].Value?.ToString();
                cmbStatus.SelectedItem = row.Cells["Status"].Value?.ToString();
            }
        }

        private void btnSave_Click(object? sender, EventArgs e)
        {
            if (dgvClients.CurrentRow != null)
            {
                DataRowView drv = (DataRowView)dgvClients.CurrentRow.DataBoundItem;
                _clientService.Update(
                    Convert.ToInt32(drv["ClientId"]), txtFullName.Text.Trim(), txtEmail.Text.Trim(),
                    string.Equals(cmbStatus.SelectedItem?.ToString(), "Active", StringComparison.OrdinalIgnoreCase));
                LoadClients();
                MessageBox.Show("Client details updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnAddClient_Click(object? sender, EventArgs e)
        {
            using ClientDetailsForm clientDetailsForm = new ClientDetailsForm();
            if (clientDetailsForm.ShowDialog(FindForm()) == DialogResult.OK)
            {
                LoadClients();
            }
        }

        private void btnDelete_Click(object? sender, EventArgs e)
        {
            if (dgvClients.CurrentRow != null)
            {
                int id = Convert.ToInt32(((DataRowView)dgvClients.CurrentRow.DataBoundItem)["ClientId"]);
                _clientService.Delete(id);
                LoadClients();
            }
        }

        private void btnCancel_Click(object? sender, EventArgs e)
        {
            txtFullName.Clear();
            txtEmail.Clear();
            txtPhone.Clear();
            txtCompany.Clear();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }
    }
}