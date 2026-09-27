namespace Event_Reservation_and_Venue_Management_System.Controls
{
    partial class MakeReservationView
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
            lblVenue = new Label();
            cmbVenue = new ComboBox();
            lblDate = new Label();
            dtpReservationDate = new DateTimePicker();
            lblTimeSlot = new Label();
            cmbTimeSlot = new ComboBox();
            lblEventTitle = new Label();
            txtEventTitle = new TextBox();
            lblGuestCount = new Label();
            numGuestCount = new NumericUpDown();
            lblSpecialRequests = new Label();
            txtSpecialRequests = new TextBox();
            lblTotalFeeHeader = new Label();
            lblTotalFeeVal = new Label();
            btnSubmitReservation = new Button();
            btnClear = new Button();
            ((ISupportInitialize)numGuestCount).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.Black;
            lblTitle.Location = new Point(14, 19);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(201, 25);
            lblTitle.TabIndex = 16;
            lblTitle.Text = "Book an Event Venue";
            // 
            // lblVenue
            // 
            lblVenue.AutoSize = true;
            lblVenue.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblVenue.Location = new Point(20, 60);
            lblVenue.Name = "lblVenue";
            lblVenue.Size = new Size(90, 17);
            lblVenue.TabIndex = 15;
            lblVenue.Text = "Select Venue:";
            // 
            // cmbVenue
            // 
            cmbVenue.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbVenue.Font = new Font("Segoe UI", 9.5F);
            cmbVenue.FormattingEnabled = true;
            cmbVenue.Location = new Point(20, 92);
            cmbVenue.Name = "cmbVenue";
            cmbVenue.Size = new Size(300, 25);
            cmbVenue.TabIndex = 14;
            cmbVenue.SelectedIndexChanged += cmbVenue_SelectedIndexChanged;
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblDate.Location = new Point(393, 67);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(118, 17);
            lblDate.TabIndex = 13;
            lblDate.Text = "Reservation Date:";
            // 
            // dtpReservationDate
            // 
            dtpReservationDate.Font = new Font("Segoe UI", 9.5F);
            dtpReservationDate.Format = DateTimePickerFormat.Short;
            dtpReservationDate.Location = new Point(393, 89);
            dtpReservationDate.Name = "dtpReservationDate";
            dtpReservationDate.Size = new Size(310, 24);
            dtpReservationDate.TabIndex = 12;
            // 
            // lblTimeSlot
            // 
            lblTimeSlot.AutoSize = true;
            lblTimeSlot.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblTimeSlot.Location = new Point(20, 120);
            lblTimeSlot.Name = "lblTimeSlot";
            lblTimeSlot.Size = new Size(71, 17);
            lblTimeSlot.TabIndex = 11;
            lblTimeSlot.Text = "Time Slot:";
            // 
            // cmbTimeSlot
            // 
            cmbTimeSlot.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTimeSlot.Font = new Font("Segoe UI", 9.5F);
            cmbTimeSlot.FormattingEnabled = true;
            cmbTimeSlot.Location = new Point(20, 152);
            cmbTimeSlot.Name = "cmbTimeSlot";
            cmbTimeSlot.Size = new Size(300, 25);
            cmbTimeSlot.TabIndex = 10;
            cmbTimeSlot.SelectedIndexChanged += cmbTimeSlot_SelectedIndexChanged;
            // 
            // lblEventTitle
            // 
            lblEventTitle.AutoSize = true;
            lblEventTitle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblEventTitle.Location = new Point(20, 198);
            lblEventTitle.Name = "lblEventTitle";
            lblEventTitle.Size = new Size(171, 17);
            lblEventTitle.TabIndex = 9;
            lblEventTitle.Text = "Event Name / Description:";
            // 
            // txtEventTitle
            // 
            txtEventTitle.Font = new Font("Segoe UI", 9.5F);
            txtEventTitle.Location = new Point(20, 234);
            txtEventTitle.Name = "txtEventTitle";
            txtEventTitle.PlaceholderText = "e.g., Annual Birthday Gala, Business Conference...";
            txtEventTitle.Size = new Size(683, 24);
            txtEventTitle.TabIndex = 8;
            // 
            // lblGuestCount
            // 
            lblGuestCount.AutoSize = true;
            lblGuestCount.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblGuestCount.Location = new Point(393, 127);
            lblGuestCount.Name = "lblGuestCount";
            lblGuestCount.Size = new Size(118, 17);
            lblGuestCount.TabIndex = 7;
            lblGuestCount.Text = "Estimated Guests:";
            // 
            // numGuestCount
            // 
            numGuestCount.Font = new Font("Segoe UI", 9.5F);
            numGuestCount.Location = new Point(393, 149);
            numGuestCount.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numGuestCount.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numGuestCount.Name = "numGuestCount";
            numGuestCount.Size = new Size(310, 24);
            numGuestCount.TabIndex = 6;
            numGuestCount.Value = new decimal(new int[] { 50, 0, 0, 0 });
            // 
            // lblSpecialRequests
            // 
            lblSpecialRequests.AutoSize = true;
            lblSpecialRequests.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblSpecialRequests.Location = new Point(20, 275);
            lblSpecialRequests.Name = "lblSpecialRequests";
            lblSpecialRequests.Size = new Size(195, 17);
            lblSpecialRequests.TabIndex = 5;
            lblSpecialRequests.Text = "Special Requests / Equipment:";
            // 
            // txtSpecialRequests
            // 
            txtSpecialRequests.Font = new Font("Segoe UI", 9.5F);
            txtSpecialRequests.Location = new Point(20, 309);
            txtSpecialRequests.Multiline = true;
            txtSpecialRequests.Name = "txtSpecialRequests";
            txtSpecialRequests.PlaceholderText = "Sound system, projector setup, seating arrangements...";
            txtSpecialRequests.Size = new Size(683, 98);
            txtSpecialRequests.TabIndex = 4;
            // 
            // lblTotalFeeHeader
            // 
            lblTotalFeeHeader.AutoSize = true;
            lblTotalFeeHeader.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTotalFeeHeader.ForeColor = Color.DimGray;
            lblTotalFeeHeader.Location = new Point(20, 424);
            lblTotalFeeHeader.Name = "lblTotalFeeHeader";
            lblTotalFeeHeader.Size = new Size(147, 19);
            lblTotalFeeHeader.TabIndex = 3;
            lblTotalFeeHeader.Text = "Calculated Total Fee:";
            // 
            // lblTotalFeeVal
            // 
            lblTotalFeeVal.AutoSize = true;
            lblTotalFeeVal.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTotalFeeVal.ForeColor = Color.FromArgb(13, 110, 253);
            lblTotalFeeVal.Location = new Point(20, 446);
            lblTotalFeeVal.Name = "lblTotalFeeVal";
            lblTotalFeeVal.Size = new Size(123, 30);
            lblTotalFeeVal.TabIndex = 2;
            lblTotalFeeVal.Text = "₱ 2,500.00";
            // 
            // btnSubmitReservation
            // 
            btnSubmitReservation.BackColor = Color.FromArgb(13, 110, 253);
            btnSubmitReservation.FlatAppearance.BorderSize = 0;
            btnSubmitReservation.FlatStyle = FlatStyle.Flat;
            btnSubmitReservation.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSubmitReservation.ForeColor = Color.White;
            btnSubmitReservation.Location = new Point(533, 438);
            btnSubmitReservation.Name = "btnSubmitReservation";
            btnSubmitReservation.Size = new Size(170, 38);
            btnSubmitReservation.TabIndex = 1;
            btnSubmitReservation.Text = "Submit Booking";
            btnSubmitReservation.UseVisualStyleBackColor = false;
            btnSubmitReservation.Click += btnSubmitReservation_Click;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.FromArgb(108, 117, 125);
            btnClear.FlatAppearance.BorderSize = 0;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnClear.ForeColor = Color.White;
            btnClear.Location = new Point(413, 438);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(110, 38);
            btnClear.TabIndex = 0;
            btnClear.Text = "Reset Form";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // MakeReservationView
            // 
            BackColor = Color.FromArgb(245, 246, 250);
            Controls.Add(btnClear);
            Controls.Add(btnSubmitReservation);
            Controls.Add(lblTotalFeeVal);
            Controls.Add(lblTotalFeeHeader);
            Controls.Add(txtSpecialRequests);
            Controls.Add(lblSpecialRequests);
            Controls.Add(numGuestCount);
            Controls.Add(lblGuestCount);
            Controls.Add(txtEventTitle);
            Controls.Add(lblEventTitle);
            Controls.Add(cmbTimeSlot);
            Controls.Add(lblTimeSlot);
            Controls.Add(dtpReservationDate);
            Controls.Add(lblDate);
            Controls.Add(cmbVenue);
            Controls.Add(lblVenue);
            Controls.Add(lblTitle);
            Name = "MakeReservationView";
            Size = new Size(747, 512);
            ((ISupportInitialize)numGuestCount).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblVenue;
        private ComboBox cmbVenue;
        private Label lblDate;
        private DateTimePicker dtpReservationDate;
        private Label lblTimeSlot;
        private ComboBox cmbTimeSlot;
        private Label lblGuestCount;
        private NumericUpDown numGuestCount;
        private Label lblEventTitle;
        private TextBox txtEventTitle;
        private Label lblSpecialRequests;
        private TextBox txtSpecialRequests;
        private Label lblTotalFeeHeader;
        private Label lblTotalFeeVal;
        private Button btnSubmitReservation;
        private Button btnClear;
    }
}