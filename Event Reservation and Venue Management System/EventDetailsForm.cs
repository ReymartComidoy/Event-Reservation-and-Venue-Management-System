using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Event_Reservation_and_Venue_Management_System.Services;

namespace Event_Reservation_and_Venue_Management_System
{
    public sealed class EventDetailsForm : Form
    {
        private readonly TextBox txtEventName = new TextBox();
        private readonly ComboBox cmbVenue = new ComboBox();
        private readonly TextBox txtBookings = new TextBox();
        private readonly DateTimePicker dtpEventDate = new DateTimePicker();
        private readonly Button btnSave = new Button();
        private readonly Button btnCancel = new Button();
        private readonly Button btnDelete = new Button();

        public EventDetailsForm()
        {
            InitializeForm();
            PopulateVenues();
        }

        private void InitializeForm()
        {
            Text = "Event Details";
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            ShowInTaskbar = false;
            ClientSize = new Size(744, 198);

            var groupBox = new GroupBox
            {
                Text = "Event Details",
                Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold),
                Location = new Point(10, 10),
                Size = new Size(734, 178)
            };

            var eventNameLabel = CreateLabel("Event Name:", 10, 34);
            txtEventName.Location = new Point(91, 31);
            txtEventName.Size = new Size(249, 23);
            txtEventName.Font = new Font("Segoe UI", 9F);

            var venueLabel = CreateLabel("Venue:", 10, 74);
            cmbVenue.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbVenue.Location = new Point(91, 71);
            cmbVenue.Size = new Size(249, 23);
            cmbVenue.Font = new Font("Segoe UI", 9F);

            var bookingsLabel = CreateLabel("Bookings:", 357, 34);
            txtBookings.Location = new Point(438, 31);
            txtBookings.Size = new Size(214, 23);
            txtBookings.Font = new Font("Segoe UI", 9F);

            var dateLabel = CreateLabel("Date:", 357, 74);
            dtpEventDate.Format = DateTimePickerFormat.Long;
            dtpEventDate.Location = new Point(438, 71);
            dtpEventDate.Size = new Size(214, 23);
            dtpEventDate.Font = new Font("Segoe UI", 9F);

            ConfigureButton(btnSave, "Save", 92, 116);
            ConfigureButton(btnCancel, "Cancel", 219, 116);
            ConfigureButton(btnDelete, "Delete", 346, 116);

            btnSave.Click += btnSave_Click;
            btnCancel.Click += (_, _) =>
            {
                DialogResult = DialogResult.Cancel;
                Close();
            };
            btnDelete.Click += (_, _) => MessageBox.Show("Delete is available when editing an existing event.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);

            groupBox.Controls.AddRange(new Control[]
            {
                eventNameLabel, txtEventName,
                venueLabel, cmbVenue,
                bookingsLabel, txtBookings,
                dateLabel, dtpEventDate,
                btnSave, btnCancel, btnDelete
            });
            Controls.Add(groupBox);

            AcceptButton = btnSave;
            CancelButton = btnCancel;
        }

        private static Label CreateLabel(string text, int x, int y)
        {
            return new Label
            {
                AutoSize = true,
                Text = text,
                Font = new Font("Segoe UI", 9.75F),
                Location = new Point(x, y)
            };
        }

        private static void ConfigureButton(Button button, string text, int x, int y)
        {
            button.BackColor = Color.FromArgb(33, 37, 41);
            button.ForeColor = Color.White;
            button.FlatStyle = FlatStyle.Flat;
            button.Location = new Point(x, y);
            button.Size = new Size(122, 29);
            button.Text = text;
            button.UseVisualStyleBackColor = false;
        }

        private void PopulateVenues()
        {
            foreach (DataRow row in DataRepository.VenuesTable.Rows)
            {
                cmbVenue.Items.Add(row["VenueName"].ToString());
            }

            if (cmbVenue.Items.Count > 0)
            {
                cmbVenue.SelectedIndex = 0;
            }
        }

        private void btnSave_Click(object? sender, EventArgs e)
        {
            string eventName = txtEventName.Text.Trim();
            string venue = cmbVenue.SelectedItem?.ToString() ?? string.Empty;

            if (string.IsNullOrWhiteSpace(eventName))
            {
                MessageBox.Show("Enter an event name.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEventName.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(venue))
            {
                MessageBox.Show("Select a venue.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbVenue.Focus();
                return;
            }

            if (!int.TryParse(txtBookings.Text.Trim(), out int bookings) || bookings < 0)
            {
                MessageBox.Show("Bookings must be a nonnegative whole number.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBookings.Focus();
                return;
            }

            int maxId = 100;
            foreach (DataRow row in DataRepository.EventsTable.Rows)
            {
                if (row["EventID"] != DBNull.Value)
                {
                    maxId = Math.Max(maxId, Convert.ToInt32(row["EventID"]));
                }
            }

            DataRepository.EventsTable.Rows.Add(
                maxId + 1,
                eventName,
                venue,
                dtpEventDate.Value.ToString("yyyy-MM-dd"),
                "09:00 AM",
                "Upcoming",
                bookings);

            DialogResult = DialogResult.OK;
        }
    }
}
