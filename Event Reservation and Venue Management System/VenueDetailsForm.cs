using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Event_Reservation_and_Venue_Management_System.Services;

namespace Event_Reservation_and_Venue_Management_System
{
    public sealed class VenueDetailsForm : Form
    {
        private readonly TextBox txtVenueName = new TextBox();
        private readonly NumericUpDown numCapacity = new NumericUpDown();
        private readonly TextBox txtLocation = new TextBox();
        private readonly TextBox txtHourlyRate = new TextBox();
        private readonly ComboBox cmbStatus = new ComboBox();

        public VenueDetailsForm()
        {
            InitializeForm();
        }

        private void InitializeForm()
        {
            Text = "Venue Details";
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            ShowInTaskbar = false;
            ClientSize = new Size(744, 238);

            var groupBox = new GroupBox
            {
                Text = "Venue Details",
                Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold),
                Location = new Point(10, 10),
                Size = new Size(734, 218)
            };

            AddField(groupBox, "Venue Name:", txtVenueName, 10, 34, 249, 23);
            AddField(groupBox, "Capacity:", numCapacity, 10, 74, 249, 23);
            AddField(groupBox, "Location:", txtLocation, 10, 114, 249, 23);
            AddField(groupBox, "Price Per Hour:", txtHourlyRate, 357, 34, 214, 23);
            AddField(groupBox, "Status:", cmbStatus, 357, 74, 214, 23);

            numCapacity.Maximum = 1000000;
            ConfigureCombo(cmbStatus);
            cmbStatus.Items.AddRange(new object[] { "Available", "Unavailable", "Maintenance" });
            cmbStatus.SelectedItem = "Available";

            var btnSave = CreateButton("Save", 92, 166);
            var btnCancel = CreateButton("Cancel", 219, 166);
            var btnDelete = CreateButton("Delete", 346, 166);

            btnSave.Click += btnSave_Click;
            btnCancel.Click += (_, _) =>
            {
                DialogResult = DialogResult.Cancel;
                Close();
            };
            btnDelete.Click += (_, _) => MessageBox.Show("Delete is available when editing an existing venue.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            string venueName = txtVenueName.Text.Trim();
            string location = txtLocation.Text.Trim();

            if (string.IsNullOrWhiteSpace(venueName) || string.IsNullOrWhiteSpace(location))
            {
                MessageBox.Show("Enter a venue name and location.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtHourlyRate.Text.Trim(), out decimal hourlyRate) || hourlyRate < 0)
            {
                MessageBox.Show("Price per hour must be a nonnegative number.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHourlyRate.Focus();
                return;
            }

            DataRepository.VenuesTable.Rows.Add(
                venueName,
                (int)numCapacity.Value,
                location,
                hourlyRate,
                cmbStatus.SelectedItem?.ToString() ?? "Available");

            DialogResult = DialogResult.OK;
        }
    }
}
