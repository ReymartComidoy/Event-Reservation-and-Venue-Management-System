using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Event_Reservation_and_Venue_Management_System.Services;

namespace Event_Reservation_and_Venue_Management_System
{
    public sealed class ReservationDetailsForm : Form
    {
        private readonly ComboBox cmbClient = new ComboBox();
        private readonly ComboBox cmbEvent = new ComboBox();
        private readonly ComboBox cmbVenue = new ComboBox();
        private readonly DateTimePicker dtpReservationDate = new DateTimePicker();
        private readonly NumericUpDown numTotalAmount = new NumericUpDown();
        private readonly ComboBox cmbStatus = new ComboBox();

        public ReservationDetailsForm()
        {
            InitializeForm();
            PopulateOptions();
        }

        private void InitializeForm()
        {
            Text = "Reservation Details";
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            ShowInTaskbar = false;
            ClientSize = new Size(744, 238);

            var groupBox = new GroupBox
            {
                Text = "Reservation Details",
                Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold),
                Location = new Point(10, 10),
                Size = new Size(734, 218)
            };

            AddField(groupBox, "Client:", cmbClient, 10, 34, 249, 23);
            AddField(groupBox, "Event:", cmbEvent, 10, 74, 249, 23);
            AddField(groupBox, "Venue:", cmbVenue, 10, 114, 249, 23);
            AddField(groupBox, "Date:", dtpReservationDate, 357, 34, 214, 23);
            AddField(groupBox, "Total Amount:", numTotalAmount, 357, 74, 214, 23);
            AddField(groupBox, "Status:", cmbStatus, 357, 114, 214, 23);

            ConfigureCombo(cmbClient);
            ConfigureCombo(cmbEvent);
            ConfigureCombo(cmbVenue);
            ConfigureCombo(cmbStatus);
            dtpReservationDate.Format = DateTimePickerFormat.Long;
            numTotalAmount.DecimalPlaces = 2;
            numTotalAmount.Maximum = 100000000;
            numTotalAmount.ThousandsSeparator = true;

            var btnSave = CreateButton("Save", 92, 166);
            var btnCancel = CreateButton("Cancel", 219, 166);
            var btnDelete = CreateButton("Delete", 346, 166);

            btnSave.Click += btnSave_Click;
            btnCancel.Click += (_, _) =>
            {
                DialogResult = DialogResult.Cancel;
                Close();
            };
            btnDelete.Click += (_, _) => MessageBox.Show("Delete is available when editing an existing reservation.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void PopulateOptions()
        {
            foreach (DataRow row in DataRepository.ClientsTable.Rows)
            {
                cmbClient.Items.Add(row["ClientName"].ToString());
            }

            foreach (DataRow row in DataRepository.EventsTable.Rows)
            {
                cmbEvent.Items.Add(row["EventName"].ToString());
            }

            foreach (DataRow row in DataRepository.VenuesTable.Rows)
            {
                cmbVenue.Items.Add(row["VenueName"].ToString());
            }

            cmbStatus.Items.AddRange(new object[] { "Confirmed", "Pending", "Completed" });
            SelectFirst(cmbClient);
            SelectFirst(cmbEvent);
            SelectFirst(cmbVenue);
            cmbStatus.SelectedItem = "Confirmed";
        }

        private static void SelectFirst(ComboBox comboBox)
        {
            if (comboBox.Items.Count > 0)
            {
                comboBox.SelectedIndex = 0;
            }
        }

        private void btnSave_Click(object? sender, EventArgs e)
        {
            if (cmbClient.SelectedItem == null || cmbEvent.SelectedItem == null || cmbVenue.SelectedItem == null)
            {
                MessageBox.Show("Select a client, event, and venue.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string newId = $"RES-{2000 + DataRepository.ReservationsTable.Rows.Count + 1}";
            DataRepository.ReservationsTable.Rows.Add(
                newId,
                cmbClient.SelectedItem.ToString(),
                cmbEvent.SelectedItem.ToString(),
                cmbVenue.SelectedItem.ToString(),
                dtpReservationDate.Value.ToString("yyyy-MM-dd"),
                numTotalAmount.Value,
                cmbStatus.SelectedItem?.ToString() ?? "Confirmed");

            DialogResult = DialogResult.OK;
        }
    }
}
