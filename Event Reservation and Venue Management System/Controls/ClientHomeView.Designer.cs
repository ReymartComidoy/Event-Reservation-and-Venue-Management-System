namespace Event_Reservation_and_Venue_Management_System.Controls
{
    partial class ClientHomeView
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
            lblCard1Title = new Label();
            lblActiveReservationsCount = new Label();
            lblCard2Title = new Label();
            lblPendingPaymentsCount = new Label();
            lblCard3Title = new Label();
            lblAvailableVenuesCount = new Label();
            lblRecentTitle = new Label();
            dgvRecentReservations = new DataGridView();
            colResId = new DataGridViewTextBoxColumn();
            colVenue = new DataGridViewTextBoxColumn();
            colDate = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            colAmount = new DataGridViewTextBoxColumn();
            panel1 = new Panel();
            panel4 = new Panel();
            lblAvailableVenuesVal = new Label();
            label5 = new Label();
            panel3 = new Panel();
            lblPendingBalanceVal = new Label();
            label3 = new Label();
            panel2 = new Panel();
            lblActiveBookingsVal = new Label();
            label1 = new Label();
            ((ISupportInitialize)dgvRecentReservations).BeginInit();
            panel1.SuspendLayout();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // lblCard1Title
            // 
            lblCard1Title.Location = new Point(0, 0);
            lblCard1Title.Name = "lblCard1Title";
            lblCard1Title.Size = new Size(100, 23);
            lblCard1Title.TabIndex = 0;
            // 
            // lblActiveReservationsCount
            // 
            lblActiveReservationsCount.Location = new Point(0, 0);
            lblActiveReservationsCount.Name = "lblActiveReservationsCount";
            lblActiveReservationsCount.Size = new Size(100, 23);
            lblActiveReservationsCount.TabIndex = 0;
            // 
            // lblCard2Title
            // 
            lblCard2Title.Location = new Point(0, 0);
            lblCard2Title.Name = "lblCard2Title";
            lblCard2Title.Size = new Size(100, 23);
            lblCard2Title.TabIndex = 0;
            // 
            // lblPendingPaymentsCount
            // 
            lblPendingPaymentsCount.Location = new Point(0, 0);
            lblPendingPaymentsCount.Name = "lblPendingPaymentsCount";
            lblPendingPaymentsCount.Size = new Size(100, 23);
            lblPendingPaymentsCount.TabIndex = 0;
            // 
            // lblCard3Title
            // 
            lblCard3Title.Location = new Point(0, 0);
            lblCard3Title.Name = "lblCard3Title";
            lblCard3Title.Size = new Size(100, 23);
            lblCard3Title.TabIndex = 0;
            // 
            // lblAvailableVenuesCount
            // 
            lblAvailableVenuesCount.Location = new Point(0, 0);
            lblAvailableVenuesCount.Name = "lblAvailableVenuesCount";
            lblAvailableVenuesCount.Size = new Size(100, 23);
            lblAvailableVenuesCount.TabIndex = 0;
            // 
            // lblRecentTitle
            // 
            lblRecentTitle.AutoSize = true;
            lblRecentTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblRecentTitle.ForeColor = Color.FromArgb(33, 37, 41);
            lblRecentTitle.Location = new Point(0, 193);
            lblRecentTitle.Name = "lblRecentTitle";
            lblRecentTitle.Size = new Size(220, 21);
            lblRecentTitle.TabIndex = 1;
            lblRecentTitle.Text = "Recent Reservation Activity";
            // 
            // dgvRecentReservations
            // 
            dgvRecentReservations.AllowUserToAddRows = false;
            dgvRecentReservations.AllowUserToDeleteRows = false;
            dgvRecentReservations.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRecentReservations.BackgroundColor = Color.White;
            dgvRecentReservations.BorderStyle = BorderStyle.None;
            dgvRecentReservations.ColumnHeadersHeight = 35;
            dgvRecentReservations.Columns.AddRange(new DataGridViewColumn[] { colResId, colVenue, colDate, colStatus, colAmount });
            dgvRecentReservations.Location = new Point(7, 227);
            dgvRecentReservations.MultiSelect = false;
            dgvRecentReservations.Name = "dgvRecentReservations";
            dgvRecentReservations.ReadOnly = true;
            dgvRecentReservations.RowHeadersVisible = false;
            dgvRecentReservations.RowTemplate.Height = 30;
            dgvRecentReservations.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRecentReservations.Size = new Size(727, 271);
            dgvRecentReservations.TabIndex = 0;
            // 
            // colResId
            // 
            colResId.HeaderText = "Booking ID";
            colResId.Name = "colResId";
            colResId.ReadOnly = true;
            // 
            // colVenue
            // 
            colVenue.HeaderText = "Venue Name";
            colVenue.Name = "colVenue";
            colVenue.ReadOnly = true;
            // 
            // colDate
            // 
            colDate.HeaderText = "Event Date";
            colDate.Name = "colDate";
            colDate.ReadOnly = true;
            // 
            // colStatus
            // 
            colStatus.HeaderText = "Status";
            colStatus.Name = "colStatus";
            colStatus.ReadOnly = true;
            // 
            // colAmount
            // 
            colAmount.HeaderText = "Total Fee";
            colAmount.Name = "colAmount";
            colAmount.ReadOnly = true;
            // 
            // panel1
            // 
            panel1.Controls.Add(panel4);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(747, 190);
            panel1.TabIndex = 2;
            // 
            // panel4
            // 
            panel4.Controls.Add(lblAvailableVenuesVal);
            panel4.Controls.Add(label5);
            panel4.Location = new Point(533, 25);
            panel4.Name = "panel4";
            panel4.Size = new Size(188, 131);
            panel4.TabIndex = 1;
            // 
            // lblAvailableVenuesVal
            // 
            lblAvailableVenuesVal.AutoSize = true;
            lblAvailableVenuesVal.Font = new Font("Segoe UI", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAvailableVenuesVal.ForeColor = Color.FromArgb(33, 37, 41);
            lblAvailableVenuesVal.Location = new Point(28, 56);
            lblAvailableVenuesVal.Name = "lblAvailableVenuesVal";
            lblAvailableVenuesVal.Size = new Size(43, 50);
            lblAvailableVenuesVal.TabIndex = 5;
            lblAvailableVenuesVal.Text = "0";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label5.ForeColor = Color.FromArgb(33, 37, 41);
            label5.Location = new Point(19, 20);
            label5.Name = "label5";
            label5.Size = new Size(141, 21);
            label5.TabIndex = 6;
            label5.Text = "Available Venues";
            // 
            // panel3
            // 
            panel3.Controls.Add(lblPendingBalanceVal);
            panel3.Controls.Add(label3);
            panel3.Location = new Point(279, 25);
            panel3.Name = "panel3";
            panel3.Size = new Size(188, 131);
            panel3.TabIndex = 1;
            // 
            // lblPendingBalanceVal
            // 
            lblPendingBalanceVal.AutoSize = true;
            lblPendingBalanceVal.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPendingBalanceVal.ForeColor = Color.FromArgb(33, 37, 41);
            lblPendingBalanceVal.Location = new Point(20, 67);
            lblPendingBalanceVal.Name = "lblPendingBalanceVal";
            lblPendingBalanceVal.Size = new Size(116, 25);
            lblPendingBalanceVal.TabIndex = 5;
            lblPendingBalanceVal.Text = "₱ 15,000.00";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label3.ForeColor = Color.FromArgb(33, 37, 41);
            label3.Location = new Point(20, 20);
            label3.Name = "label3";
            label3.Size = new Size(138, 21);
            label3.TabIndex = 5;
            label3.Text = "Pending Balance";
            // 
            // panel2
            // 
            panel2.Controls.Add(lblActiveBookingsVal);
            panel2.Controls.Add(label1);
            panel2.Location = new Point(20, 25);
            panel2.Name = "panel2";
            panel2.Size = new Size(188, 131);
            panel2.TabIndex = 0;
            // 
            // lblActiveBookingsVal
            // 
            lblActiveBookingsVal.AutoSize = true;
            lblActiveBookingsVal.Font = new Font("Segoe UI", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblActiveBookingsVal.ForeColor = Color.FromArgb(33, 37, 41);
            lblActiveBookingsVal.Location = new Point(18, 56);
            lblActiveBookingsVal.Name = "lblActiveBookingsVal";
            lblActiveBookingsVal.Size = new Size(43, 50);
            lblActiveBookingsVal.TabIndex = 4;
            lblActiveBookingsVal.Text = "0";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(33, 37, 41);
            label1.Location = new Point(18, 20);
            label1.Name = "label1";
            label1.Size = new Size(133, 21);
            label1.TabIndex = 3;
            label1.Text = "Active Bookings";
            // 
            // ClientHomeView
            // 
            BackColor = Color.FromArgb(245, 246, 250);
            Controls.Add(panel1);
            Controls.Add(dgvRecentReservations);
            Controls.Add(lblRecentTitle);
            Name = "ClientHomeView";
            Size = new Size(747, 512);
            ((ISupportInitialize)dgvRecentReservations).EndInit();
            panel1.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private void CreateMetricCard(Panel pnl, Label lblTitle, Label lblCount, string titleText, string defaultVal, int x, int y, Color bg, Color accentColor)
        {
            pnl.BackColor = bg;
            pnl.Controls.Add(lblCount);
            pnl.Controls.Add(lblTitle);
            pnl.Location = new Point(x, y);
            pnl.Name = "pnlCard_" + titleText;
            pnl.Size = new Size(230, 100);

            lblTitle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblTitle.ForeColor = Color.Gray;
            lblTitle.Location = new Point(15, 15);
            lblTitle.Size = new Size(200, 20);
            lblTitle.Text = titleText;

            lblCount.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblCount.ForeColor = accentColor;
            lblCount.Location = new Point(15, 45);
            lblCount.Size = new Size(200, 35);
            lblCount.Text = defaultVal;
        }

        #endregion
        private Label lblCard1Title;
        private Label lblActiveReservationsCount;
        private Label lblCard2Title;
        private Label lblPendingPaymentsCount;
        private Label lblCard3Title;
        private Label lblAvailableVenuesCount;
        private Label lblRecentTitle;
        private DataGridView dgvRecentReservations;
        private DataGridViewTextBoxColumn colResId;
        private DataGridViewTextBoxColumn colVenue;
        private DataGridViewTextBoxColumn colDate;
        private DataGridViewTextBoxColumn colStatus;
        private DataGridViewTextBoxColumn colAmount;
        private Panel panel1;
        private Panel panel4;
        private Panel panel3;
        private Panel panel2;
        private Label lblAvailableVenuesVal;
        private Label label5;
        private Label lblPendingBalanceVal;
        private Label label3;
        private Label lblActiveBookingsVal;
        private Label label1;
    }
}