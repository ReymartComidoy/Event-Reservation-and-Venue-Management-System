namespace Event_Reservation_and_Venue_Management_System.Controls
{
    partial class MyReservationsView
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            lblTitle = new Label();
            lblSearch = new Label();
            txtSearch = new TextBox();
            lblStatusFilter = new Label();
            cmbStatusFilter = new ComboBox();
            btnRefresh = new Button();
            btnCancelReservation = new Button();
            dgvMyReservations = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colVenue = new DataGridViewTextBoxColumn();
            colEventTitle = new DataGridViewTextBoxColumn();
            colDate = new DataGridViewTextBoxColumn();
            colTimeSlot = new DataGridViewTextBoxColumn();
            colGuests = new DataGridViewTextBoxColumn();
            colTotalFee = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            ((ISupportInitialize)dgvMyReservations).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.Black;
            lblTitle.Location = new Point(20, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(158, 25);
            lblTitle.TabIndex = 7;
            lblTitle.Text = "My Reservations";
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblSearch.Location = new Point(20, 62);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(48, 15);
            lblSearch.TabIndex = 6;
            lblSearch.Text = "Search:";
            // 
            // txtSearch
            // 
            txtSearch.Font = new Font("Segoe UI", 9.5F);
            txtSearch.Location = new Point(72, 58);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Filter by venue or event title...";
            txtSearch.Size = new Size(220, 24);
            txtSearch.TabIndex = 5;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // lblStatusFilter
            // 
            lblStatusFilter.AutoSize = true;
            lblStatusFilter.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblStatusFilter.Location = new Point(310, 62);
            lblStatusFilter.Name = "lblStatusFilter";
            lblStatusFilter.Size = new Size(45, 15);
            lblStatusFilter.TabIndex = 4;
            lblStatusFilter.Text = "Status:";
            // 
            // cmbStatusFilter
            // 
            cmbStatusFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatusFilter.Font = new Font("Segoe UI", 9.5F);
            cmbStatusFilter.FormattingEnabled = true;
            cmbStatusFilter.Location = new Point(360, 58);
            cmbStatusFilter.Name = "cmbStatusFilter";
            cmbStatusFilter.Size = new Size(195, 25);
            cmbStatusFilter.TabIndex = 3;
            cmbStatusFilter.SelectedIndexChanged += cmbStatusFilter_SelectedIndexChanged;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.FromArgb(108, 117, 125);
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(627, 56);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(90, 28);
            btnRefresh.TabIndex = 1;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnCancelReservation
            // 
            btnCancelReservation.BackColor = Color.FromArgb(220, 53, 69);
            btnCancelReservation.FlatAppearance.BorderSize = 0;
            btnCancelReservation.FlatStyle = FlatStyle.Flat;
            btnCancelReservation.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnCancelReservation.ForeColor = Color.White;
            btnCancelReservation.Location = new Point(557, 464);
            btnCancelReservation.Name = "btnCancelReservation";
            btnCancelReservation.Size = new Size(160, 34);
            btnCancelReservation.TabIndex = 0;
            btnCancelReservation.Text = "Cancel Booking";
            btnCancelReservation.UseVisualStyleBackColor = false;
            btnCancelReservation.Click += btnCancelReservation_Click;
            // 
            // dgvMyReservations
            // 
            dgvMyReservations.AllowUserToAddRows = false;
            dgvMyReservations.AllowUserToDeleteRows = false;
            dgvMyReservations.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMyReservations.BackgroundColor = Color.White;
            dgvMyReservations.BorderStyle = BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(235, 238, 242);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvMyReservations.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvMyReservations.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMyReservations.Columns.AddRange(new DataGridViewColumn[] { colId, colVenue, colEventTitle, colDate, colTimeSlot, colGuests, colTotalFee, colStatus });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(13, 110, 253);
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvMyReservations.DefaultCellStyle = dataGridViewCellStyle2;
            dgvMyReservations.Location = new Point(20, 96);
            dgvMyReservations.MultiSelect = false;
            dgvMyReservations.Name = "dgvMyReservations";
            dgvMyReservations.ReadOnly = true;
            dgvMyReservations.RowHeadersVisible = false;
            dgvMyReservations.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMyReservations.Size = new Size(697, 349);
            dgvMyReservations.TabIndex = 2;
            // 
            // colId
            // 
            colId.FillWeight = 40F;
            colId.HeaderText = "ID";
            colId.Name = "colId";
            colId.ReadOnly = true;
            // 
            // colVenue
            // 
            colVenue.FillWeight = 110F;
            colVenue.HeaderText = "Venue";
            colVenue.Name = "colVenue";
            colVenue.ReadOnly = true;
            // 
            // colEventTitle
            // 
            colEventTitle.FillWeight = 110F;
            colEventTitle.HeaderText = "Event Title";
            colEventTitle.Name = "colEventTitle";
            colEventTitle.ReadOnly = true;
            // 
            // colDate
            // 
            colDate.FillWeight = 70F;
            colDate.HeaderText = "Date";
            colDate.Name = "colDate";
            colDate.ReadOnly = true;
            // 
            // colTimeSlot
            // 
            colTimeSlot.HeaderText = "Time Slot";
            colTimeSlot.Name = "colTimeSlot";
            colTimeSlot.ReadOnly = true;
            // 
            // colGuests
            // 
            colGuests.FillWeight = 50F;
            colGuests.HeaderText = "Guests";
            colGuests.Name = "colGuests";
            colGuests.ReadOnly = true;
            // 
            // colTotalFee
            // 
            colTotalFee.FillWeight = 75F;
            colTotalFee.HeaderText = "Total Fee";
            colTotalFee.Name = "colTotalFee";
            colTotalFee.ReadOnly = true;
            // 
            // colStatus
            // 
            colStatus.FillWeight = 65F;
            colStatus.HeaderText = "Status";
            colStatus.Name = "colStatus";
            colStatus.ReadOnly = true;
            // 
            // MyReservationsView
            // 
            BackColor = Color.FromArgb(245, 246, 250);
            Controls.Add(btnCancelReservation);
            Controls.Add(btnRefresh);
            Controls.Add(dgvMyReservations);
            Controls.Add(cmbStatusFilter);
            Controls.Add(lblStatusFilter);
            Controls.Add(txtSearch);
            Controls.Add(lblSearch);
            Controls.Add(lblTitle);
            Name = "MyReservationsView";
            Size = new Size(747, 512);
            ((ISupportInitialize)dgvMyReservations).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblSearch;
        private TextBox txtSearch;
        private Label lblStatusFilter;
        private ComboBox cmbStatusFilter;
        private Button btnRefresh;
        private DataGridView dgvMyReservations;
        private Button btnCancelReservation;

        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colVenue;
        private DataGridViewTextBoxColumn colEventTitle;
        private DataGridViewTextBoxColumn colDate;
        private DataGridViewTextBoxColumn colTimeSlot;
        private DataGridViewTextBoxColumn colGuests;
        private DataGridViewTextBoxColumn colTotalFee;
        private DataGridViewTextBoxColumn colStatus;
    }
}