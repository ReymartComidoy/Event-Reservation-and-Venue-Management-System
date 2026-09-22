using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Event_Reservation_and_Venue_Management_System.Services;

namespace Event_Reservation_and_Venue_Management_System
{
    public sealed class ClientDetailsForm : Form
    {
        private readonly TextBox txtFullName = new TextBox();
        private readonly TextBox txtEmail = new TextBox();
        private readonly TextBox txtPhone = new TextBox();
        private readonly TextBox txtCompany = new TextBox();
        private readonly ComboBox cmbClientType = new ComboBox();
        private readonly ComboBox cmbStatus = new ComboBox();

        public ClientDetailsForm()
        {
            InitializeForm();
        }

        private void InitializeForm()
        {
            Text = "Client Details";
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            ShowInTaskbar = false;
            ClientSize = new Size(744, 238);

            var groupBox = new GroupBox
            {
                Text = "Client Details",
                Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold),
                Location = new Point(10, 10),
                Size = new Size(734, 218)
            };

            AddField(groupBox, "Full Name:", txtFullName, 10, 34, 249, 23);
            AddField(groupBox, "Email:", txtEmail, 10, 74, 249, 23);
            AddField(groupBox, "Phone:", txtPhone, 10, 114, 249, 23);
            AddField(groupBox, "Company:", txtCompany, 357, 34, 214, 23);
            AddField(groupBox, "Client Type:", cmbClientType, 357, 74, 214, 23);
            AddField(groupBox, "Status:", cmbStatus, 357, 114, 214, 23);

            ConfigureCombo(cmbClientType);
            cmbClientType.Items.AddRange(new object[] { "Corporate", "Individual" });
            cmbClientType.SelectedItem = "Individual";
            ConfigureCombo(cmbStatus);
            cmbStatus.Items.AddRange(new object[] { "Active", "Inactive" });
            cmbStatus.SelectedItem = "Active";

            var btnSave = CreateButton("Save", 92, 166);
            var btnCancel = CreateButton("Cancel", 219, 166);
            var btnDelete = CreateButton("Delete", 346, 166);

            btnSave.Click += btnSave_Click;
            btnCancel.Click += (_, _) =>
            {
                DialogResult = DialogResult.Cancel;
                Close();
            };
            btnDelete.Click += (_, _) => MessageBox.Show("Delete is available when editing an existing client.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            groupBox.Controls.AddRange(new Control[] { btnSave, btnCancel, btnDelete });
            Controls.Add(groupBox);
            AcceptButton = btnSave;
            CancelButton = btnCancel;
        }

        private static void AddField(GroupBox groupBox, string labelText, Control control, int x, int y, int width, int height)
        {
            groupBox.Controls.Add(new Label
            {
                AutoSize = true,
                Text = labelText,
                Font = new Font("Segoe UI", 9.75F),
                Location = new Point(x, y + 3)
            });
            control.Location = new Point(x + 91, y);
            control.Size = new Size(width, height);
            control.Font = new Font("Segoe UI", 9F);
            groupBox.Controls.Add(control);
        }

        private static void ConfigureCombo(ComboBox comboBox)
        {
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private static Button CreateButton(string text, int x, int y)
        {
            return new Button
            {
                BackColor = Color.FromArgb(33, 37, 41),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(x, y),
                Size = new Size(122, 29),
                Text = text,
                UseVisualStyleBackColor = false
            };
        }

        private void btnSave_Click(object? sender, EventArgs e)
        {
            string fullName = txtFullName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string company = txtCompany.Text.Trim();

            if (string.IsNullOrWhiteSpace(fullName) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(phone))
            {
                MessageBox.Show("Enter the client's name, email, and phone.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string newId = $"CLT-{1000 + DataRepository.ClientsTable.Rows.Count + 1}";
            DataRepository.ClientsTable.Rows.Add(
                newId,
                fullName,
                email,
                phone,
                string.IsNullOrWhiteSpace(company) ? "N/A" : company,
                cmbClientType.SelectedItem?.ToString() ?? "Individual",
                cmbStatus.SelectedItem?.ToString() ?? "Active");

            DialogResult = DialogResult.OK;
        }
    }
}
