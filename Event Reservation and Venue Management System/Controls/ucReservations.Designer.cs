namespace Event_Reservation_and_Venue_Management_System.Controls
{
    partial class ucReservations
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            txtSearch = new TextBox();
            cmbStatusFilter = new ComboBox();
            btnAddNewReservation = new Button();
            dgvReservations = new DataGridView();
            grpDetails = new GroupBox();
            cmbVenue = new ComboBox();
            numTotalAmount = new NumericUpDown();
            btnDelete = new Button();
            btnCancel = new Button();
            btnSave = new Button();
            label7 = new Label();
            cmbStatus = new ComboBox();
            label6 = new Label();
            label5 = new Label();
            dtpReservationDate = new DateTimePicker();
            cmbEvent = new ComboBox();
            cmbClient = new ComboBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvReservations).BeginInit();
            grpDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numTotalAmount).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.Control;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(264, 30);
            label1.TabIndex = 3;
            label1.Text = "Reservation Management";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(3, 33);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(262, 23);
            txtSearch.TabIndex = 4;
            txtSearch.Text = "Search Reservations...";
            // 
            // cmbStatusFilter
            // 
            cmbStatusFilter.FormattingEnabled = true;
            cmbStatusFilter.Location = new Point(271, 33);
            cmbStatusFilter.Name = "cmbStatusFilter";
            cmbStatusFilter.Size = new Size(156, 23);
            cmbStatusFilter.TabIndex = 5;
            // 
            // btnAddNewReservation
            // 
            btnAddNewReservation.BackColor = Color.FromArgb(33, 37, 41);
            btnAddNewReservation.ForeColor = SystemColors.Control;
            btnAddNewReservation.Location = new Point(433, 27);
            btnAddNewReservation.Name = "btnAddNewReservation";
            btnAddNewReservation.Size = new Size(151, 29);
            btnAddNewReservation.TabIndex = 6;
            btnAddNewReservation.Text = "+ Add New Reservation";
            btnAddNewReservation.UseVisualStyleBackColor = false;
            btnAddNewReservation.Click += btnAddReservation_Click;
            // 
            // dgvReservations
            // 
            dgvReservations.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReservations.Location = new Point(3, 62);
            dgvReservations.Name = "dgvReservations";
            dgvReservations.Size = new Size(743, 223);
            dgvReservations.TabIndex = 7;
            // 
            // grpDetails
            // 
            grpDetails.Controls.Add(cmbVenue);
            grpDetails.Controls.Add(numTotalAmount);
            grpDetails.Controls.Add(btnDelete);
            grpDetails.Controls.Add(btnCancel);
            grpDetails.Controls.Add(btnSave);
            grpDetails.Controls.Add(label7);
            grpDetails.Controls.Add(cmbStatus);
            grpDetails.Controls.Add(label6);
            grpDetails.Controls.Add(label5);
            grpDetails.Controls.Add(dtpReservationDate);
            grpDetails.Controls.Add(cmbEvent);
            grpDetails.Controls.Add(cmbClient);
            grpDetails.Controls.Add(label4);
            grpDetails.Controls.Add(label3);
            grpDetails.Controls.Add(label2);
            grpDetails.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpDetails.Location = new Point(3, 291);
            grpDetails.Name = "grpDetails";
            grpDetails.Size = new Size(743, 228);
            grpDetails.TabIndex = 8;
            grpDetails.TabStop = false;
            grpDetails.Text = "Reservation Details";
            // 
            // cmbVenue
            // 
            cmbVenue.FormattingEnabled = true;
            cmbVenue.Location = new Point(465, 107);
            cmbVenue.Name = "cmbVenue";
            cmbVenue.Size = new Size(217, 25);
            cmbVenue.TabIndex = 17;
            // 
            // numTotalAmount
            // 
            numTotalAmount.DecimalPlaces = 2;
            numTotalAmount.Location = new Point(465, 35);
            numTotalAmount.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numTotalAmount.Name = "numTotalAmount";
            numTotalAmount.Size = new Size(217, 25);
            numTotalAmount.TabIndex = 16;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(33, 37, 41);
            btnDelete.ForeColor = SystemColors.Control;
            btnDelete.Location = new Point(289, 161);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(122, 29);
            btnDelete.TabIndex = 15;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(33, 37, 41);
            btnCancel.ForeColor = SystemColors.Control;
            btnCancel.Location = new Point(161, 161);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(122, 29);
            btnCancel.TabIndex = 14;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(33, 37, 41);
            btnSave.ForeColor = SystemColors.Control;
            btnSave.Location = new Point(28, 161);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(122, 29);
            btnSave.TabIndex = 13;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(403, 110);
            label7.Name = "label7";
            label7.Size = new Size(48, 17);
            label7.TabIndex = 10;
            label7.Text = "Venue:";
            // 
            // cmbStatus
            // 
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Location = new Point(465, 71);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(217, 25);
            cmbStatus.TabIndex = 8;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(403, 74);
            label6.Name = "label6";
            label6.Size = new Size(49, 17);
            label6.TabIndex = 7;
            label6.Text = "Status:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(365, 38);
            label5.Name = "label5";
            label5.Size = new Size(94, 17);
            label5.TabIndex = 6;
            label5.Text = "Total Amount:";
            // 
            // dtpReservationDate
            // 
            dtpReservationDate.Location = new Point(140, 107);
            dtpReservationDate.Name = "dtpReservationDate";
            dtpReservationDate.Size = new Size(200, 25);
            dtpReservationDate.TabIndex = 5;
            // 
            // cmbEvent
            // 
            cmbEvent.FormattingEnabled = true;
            cmbEvent.Location = new Point(140, 68);
            cmbEvent.Name = "cmbEvent";
            cmbEvent.Size = new Size(199, 25);
            cmbEvent.TabIndex = 4;
            // 
            // cmbClient
            // 
            cmbClient.FormattingEnabled = true;
            cmbClient.Location = new Point(140, 34);
            cmbClient.Name = "cmbClient";
            cmbClient.Size = new Size(199, 25);
            cmbClient.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(9, 113);
            label4.Name = "label4";
            label4.Size = new Size(115, 17);
            label4.TabIndex = 2;
            label4.Text = "Reservation Date:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(28, 74);
            label3.Name = "label3";
            label3.Size = new Size(89, 17);
            label3.TabIndex = 1;
            label3.Text = "Event Name: ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(28, 38);
            label2.Name = "label2";
            label2.Size = new Size(89, 17);
            label2.TabIndex = 0;
            label2.Text = "Client Name: ";
            // 
            // ucReservations
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(grpDetails);
            Controls.Add(dgvReservations);
            Controls.Add(btnAddNewReservation);
            Controls.Add(cmbStatusFilter);
            Controls.Add(txtSearch);
            Controls.Add(label1);
            Name = "ucReservations";
            Size = new Size(826, 555);
            Load += ucReservations_Load;
            ((System.ComponentModel.ISupportInitialize)dgvReservations).EndInit();
            grpDetails.ResumeLayout(false);
            grpDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numTotalAmount).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtSearch;
        private ComboBox cmbStatusFilter;
        private Button btnAddNewReservation;
        private DataGridView dgvReservations;
        private GroupBox grpDetails;
        private DateTimePicker dtpReservationDate;
        private ComboBox cmbEvent;
        private ComboBox cmbClient;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label7;
        private ComboBox cmbStatus;
        private Label label6;
        private Label label5;
        private Button btnDelete;
        private Button btnCancel;
        private Button btnSave;
        private NumericUpDown numTotalAmount;
        private ComboBox cmbVenue;
    }
}
