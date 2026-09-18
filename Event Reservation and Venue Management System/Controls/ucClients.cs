using System;
using System.Data;
using System.Windows.Forms;
using Event_Reservation_and_Venue_Management_System.Services;

namespace Event_Reservation_and_Venue_Management_System.Controls
{
    public partial class ucClients : UserControl
    {
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
            btnAddNewClient.Click += btnAddClient_Click;
            dgvClients.SelectionChanged += dgvClients_SelectionChanged;
        }

        private void ucClients_Load(object? sender, EventArgs e)
        {
            dgvClients.DataSource = DataRepository.ClientsTable;
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
                cmbClientType.SelectedItem = row.Cells["Type"].Value?.ToString();
                cmbStatus.SelectedItem = row.Cells["Status"].Value?.ToString();
            }
        }

        private void btnSave_Click(object? sender, EventArgs e)
        {
            if (dgvClients.CurrentRow != null)
            {
                DataRowView drv = (DataRowView)dgvClients.CurrentRow.DataBoundItem;
                drv["ClientName"] = txtFullName.Text;
                drv["Email"] = txtEmail.Text;
                drv["Phone"] = txtPhone.Text;
                drv["Company"] = txtCompany.Text;
                drv["Type"] = cmbClientType.SelectedItem?.ToString();
                drv["Status"] = cmbStatus.SelectedItem?.ToString();
                MessageBox.Show("Client details updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnAddClient_Click(object? sender, EventArgs e)
        {
            string newId = $"CLT-{1000 + DataRepository.ClientsTable.Rows.Count + 1}";
            DataRepository.ClientsTable.Rows.Add(newId, txtFullName.Text, txtEmail.Text, txtPhone.Text, txtCompany.Text, cmbClientType.SelectedItem?.ToString(), "Active");
            MessageBox.Show("New client added!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDelete_Click(object? sender, EventArgs e)
        {
            if (dgvClients.CurrentRow != null)
            {
                dgvClients.Rows.RemoveAt(dgvClients.CurrentRow.Index);
            }
        }

        private void btnCancel_Click(object? sender, EventArgs e)
        {
            txtFullName.Clear();
            txtEmail.Clear();
            txtPhone.Clear();
            txtCompany.Clear();
        }
    }
}