namespace Event_Reservation_and_Venue_Management_System.Controls
{
    partial class CheckAvailabilityView
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblSelectVenue = new Label();
            cmbVenueSelect = new ComboBox();
            lblSelectDate = new Label();
            dtpEventDate = new DateTimePicker();
            btnCheck = new Button();
            lblStatusResult = new Label();
            dgvAvailability = new DataGridView();
            colTimeSlot = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            colDetails = new DataGridViewTextBoxColumn();
            btnProceedReservation = new Button();
            ((ISupportInitialize)dgvAvailability).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.Black;
            lblTitle.Location = new Point(20, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(228, 25);
            lblTitle.TabIndex = 8;
            lblTitle.Text = "Check Venue Availability";
            // 
            // lblSelectVenue
            // 
            lblSelectVenue.AutoSize = true;
            lblSelectVenue.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblSelectVenue.Location = new Point(20, 77);
            lblSelectVenue.Name = "lblSelectVenue";
            lblSelectVenue.Size = new Size(90, 17);
            lblSelectVenue.TabIndex = 7;
            lblSelectVenue.Text = "Select Venue:";
            // 
            // cmbVenueSelect
            // 
            cmbVenueSelect.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbVenueSelect.Font = new Font("Segoe UI", 9.5F);
            cmbVenueSelect.FormattingEnabled = true;
            cmbVenueSelect.Location = new Point(20, 97);
            cmbVenueSelect.Name = "cmbVenueSelect";
            cmbVenueSelect.Size = new Size(240, 25);
            cmbVenueSelect.TabIndex = 6;
            // 
            // lblSelectDate
            // 
            lblSelectDate.AutoSize = true;
            lblSelectDate.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblSelectDate.Location = new Point(292, 77);
            lblSelectDate.Name = "lblSelectDate";
            lblSelectDate.Size = new Size(81, 17);
            lblSelectDate.TabIndex = 5;
            lblSelectDate.Text = "Select Date:";
            // 
            // dtpEventDate
            // 
            dtpEventDate.Font = new Font("Segoe UI", 9.5F);
            dtpEventDate.Format = DateTimePickerFormat.Short;
            dtpEventDate.Location = new Point(292, 97);
            dtpEventDate.Name = "dtpEventDate";
            dtpEventDate.Size = new Size(160, 24);
            dtpEventDate.TabIndex = 4;
            // 
            // btnCheck
            // 
            btnCheck.BackColor = Color.FromArgb(13, 110, 253);
            btnCheck.FlatAppearance.BorderSize = 0;
            btnCheck.FlatStyle = FlatStyle.Flat;
            btnCheck.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnCheck.ForeColor = Color.White;
            btnCheck.Location = new Point(582, 96);
            btnCheck.Name = "btnCheck";
            btnCheck.Size = new Size(130, 30);
            btnCheck.TabIndex = 3;
            btnCheck.Text = "Check Schedule";
            btnCheck.UseVisualStyleBackColor = false;
            btnCheck.Click += btnCheck_Click;
            // 
            // lblStatusResult
            // 
            lblStatusResult.AutoSize = true;
            lblStatusResult.Font = new Font("Segoe UI", 9.5F, FontStyle.Italic);
            lblStatusResult.ForeColor = Color.DimGray;
            lblStatusResult.Location = new Point(20, 125);
            lblStatusResult.Name = "lblStatusResult";
            lblStatusResult.Size = new Size(181, 17);
            lblStatusResult.TabIndex = 2;
            lblStatusResult.Text = "Select venue and date to filter...";
            // 
            // dgvAvailability
            // 
            dgvAvailability.AllowUserToAddRows = false;
            dgvAvailability.AllowUserToDeleteRows = false;
            dgvAvailability.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAvailability.BackgroundColor = Color.White;
            dgvAvailability.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAvailability.Columns.AddRange(new DataGridViewColumn[] { colTimeSlot, colStatus, colDetails });
            dgvAvailability.Location = new Point(20, 150);
            dgvAvailability.MultiSelect = false;
            dgvAvailability.Name = "dgvAvailability";
            dgvAvailability.ReadOnly = true;
            dgvAvailability.RowHeadersVisible = false;
            dgvAvailability.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAvailability.Size = new Size(692, 281);
            dgvAvailability.TabIndex = 1;
            // 
            // colTimeSlot
            // 
            colTimeSlot.HeaderText = "Time Slot";
            colTimeSlot.Name = "colTimeSlot";
            colTimeSlot.ReadOnly = true;
            // 
            // colStatus
            // 
            colStatus.HeaderText = "Status";
            colStatus.Name = "colStatus";
            colStatus.ReadOnly = true;
            // 
            // colDetails
            // 
            colDetails.HeaderText = "Remarks / Booking Info";
            colDetails.Name = "colDetails";
            colDetails.ReadOnly = true;
            // 
            // btnProceedReservation
            // 
            btnProceedReservation.BackColor = Color.FromArgb(40, 167, 69);
            btnProceedReservation.FlatAppearance.BorderSize = 0;
            btnProceedReservation.FlatStyle = FlatStyle.Flat;
            btnProceedReservation.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnProceedReservation.ForeColor = Color.White;
            btnProceedReservation.Location = new Point(542, 447);
            btnProceedReservation.Name = "btnProceedReservation";
            btnProceedReservation.Size = new Size(170, 35);
            btnProceedReservation.TabIndex = 0;
            btnProceedReservation.Text = "Reserve Selected Slot";
            btnProceedReservation.UseVisualStyleBackColor = false;
            btnProceedReservation.Click += btnProceedReservation_Click;
            // 
            // CheckAvailabilityView
            // 
            BackColor = Color.FromArgb(245, 246, 250);
            Controls.Add(btnProceedReservation);
            Controls.Add(dgvAvailability);
            Controls.Add(lblStatusResult);
            Controls.Add(btnCheck);
            Controls.Add(dtpEventDate);
            Controls.Add(lblSelectDate);
            Controls.Add(cmbVenueSelect);
            Controls.Add(lblSelectVenue);
            Controls.Add(lblTitle);
            Name = "CheckAvailabilityView";
            Size = new Size(747, 512);
            ((ISupportInitialize)dgvAvailability).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblSelectVenue;
        private ComboBox cmbVenueSelect;
        private Label lblSelectDate;
        private DateTimePicker dtpEventDate;
        private Button btnCheck;
        private Label lblStatusResult;
        private DataGridView dgvAvailability;
        private DataGridViewTextBoxColumn colTimeSlot;
        private DataGridViewTextBoxColumn colStatus;
        private DataGridViewTextBoxColumn colDetails;
        private Button btnProceedReservation;
    }
}