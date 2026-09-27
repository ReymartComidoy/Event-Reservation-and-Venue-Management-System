namespace Event_Reservation_and_Venue_Management_System.Controls
{
    partial class ClientPaymentsView
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
            pnlMakePayment = new Panel();
            btnSubmitPayment = new Button();
            txtReferenceNo = new TextBox();
            lblReferenceNo = new Label();
            numAmountToPay = new NumericUpDown();
            lblAmountToPay = new Label();
            cmbPaymentMethod = new ComboBox();
            lblPaymentMethod = new Label();
            lblAmountDueVal = new Label();
            lblAmountDue = new Label();
            cmbPendingReservations = new ComboBox();
            lblReservation = new Label();
            lblMakePaymentHeader = new Label();
            pnlHistory = new Panel();
            btnRefresh = new Button();
            dgvPaymentHistory = new DataGridView();
            colPaymentId = new DataGridViewTextBoxColumn();
            colReservationId = new DataGridViewTextBoxColumn();
            colAmount = new DataGridViewTextBoxColumn();
            colMethod = new DataGridViewTextBoxColumn();
            colRefNo = new DataGridViewTextBoxColumn();
            colDate = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            lblHistoryHeader = new Label();
            pnlMakePayment.SuspendLayout();
            ((ISupportInitialize)numAmountToPay).BeginInit();
            pnlHistory.SuspendLayout();
            ((ISupportInitialize)dgvPaymentHistory).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.Black;
            lblTitle.Location = new Point(20, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(164, 25);
            lblTitle.TabIndex = 2;
            lblTitle.Text = "Payments & Billing";
            // 
            // pnlMakePayment
            // 
            pnlMakePayment.BackColor = Color.White;
            pnlMakePayment.BorderStyle = BorderStyle.FixedSingle;
            pnlMakePayment.Controls.Add(btnSubmitPayment);
            pnlMakePayment.Controls.Add(txtReferenceNo);
            pnlMakePayment.Controls.Add(lblReferenceNo);
            pnlMakePayment.Controls.Add(numAmountToPay);
            pnlMakePayment.Controls.Add(lblAmountToPay);
            pnlMakePayment.Controls.Add(cmbPaymentMethod);
            pnlMakePayment.Controls.Add(lblPaymentMethod);
            pnlMakePayment.Controls.Add(lblAmountDueVal);
            pnlMakePayment.Controls.Add(lblAmountDue);
            pnlMakePayment.Controls.Add(cmbPendingReservations);
            pnlMakePayment.Controls.Add(lblReservation);
            pnlMakePayment.Controls.Add(lblMakePaymentHeader);
            pnlMakePayment.Location = new Point(45, 63);
            pnlMakePayment.Name = "pnlMakePayment";
            pnlMakePayment.Size = new Size(240, 410);
            pnlMakePayment.TabIndex = 1;
            // 
            // btnSubmitPayment
            // 
            btnSubmitPayment.BackColor = Color.FromArgb(25, 135, 84);
            btnSubmitPayment.FlatAppearance.BorderSize = 0;
            btnSubmitPayment.FlatStyle = FlatStyle.Flat;
            btnSubmitPayment.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnSubmitPayment.ForeColor = Color.White;
            btnSubmitPayment.Location = new Point(12, 350);
            btnSubmitPayment.Name = "btnSubmitPayment";
            btnSubmitPayment.Size = new Size(212, 35);
            btnSubmitPayment.TabIndex = 0;
            btnSubmitPayment.Text = "Submit Payment";
            btnSubmitPayment.UseVisualStyleBackColor = false;
            btnSubmitPayment.Click += btnSubmitPayment_Click;
            // 
            // txtReferenceNo
            // 
            txtReferenceNo.Font = new Font("Segoe UI", 9F);
            txtReferenceNo.Location = new Point(12, 280);
            txtReferenceNo.Name = "txtReferenceNo";
            txtReferenceNo.PlaceholderText = "e.g., 100239482";
            txtReferenceNo.Size = new Size(212, 23);
            txtReferenceNo.TabIndex = 1;
            // 
            // lblReferenceNo
            // 
            lblReferenceNo.AutoSize = true;
            lblReferenceNo.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblReferenceNo.Location = new Point(12, 260);
            lblReferenceNo.Name = "lblReferenceNo";
            lblReferenceNo.Size = new Size(122, 15);
            lblReferenceNo.TabIndex = 2;
            lblReferenceNo.Text = "Ref / Reference No.:";
            // 
            // numAmountToPay
            // 
            numAmountToPay.DecimalPlaces = 2;
            numAmountToPay.Font = new Font("Segoe UI", 9F);
            numAmountToPay.Location = new Point(12, 225);
            numAmountToPay.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numAmountToPay.Name = "numAmountToPay";
            numAmountToPay.Size = new Size(212, 23);
            numAmountToPay.TabIndex = 3;
            // 
            // lblAmountToPay
            // 
            lblAmountToPay.AutoSize = true;
            lblAmountToPay.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblAmountToPay.Location = new Point(12, 205);
            lblAmountToPay.Name = "lblAmountToPay";
            lblAmountToPay.Size = new Size(92, 15);
            lblAmountToPay.TabIndex = 4;
            lblAmountToPay.Text = "Amount to Pay:";
            // 
            // cmbPaymentMethod
            // 
            cmbPaymentMethod.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPaymentMethod.Font = new Font("Segoe UI", 9F);
            cmbPaymentMethod.FormattingEnabled = true;
            cmbPaymentMethod.Location = new Point(12, 170);
            cmbPaymentMethod.Name = "cmbPaymentMethod";
            cmbPaymentMethod.Size = new Size(212, 23);
            cmbPaymentMethod.TabIndex = 5;
            // 
            // lblPaymentMethod
            // 
            lblPaymentMethod.AutoSize = true;
            lblPaymentMethod.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblPaymentMethod.Location = new Point(12, 150);
            lblPaymentMethod.Name = "lblPaymentMethod";
            lblPaymentMethod.Size = new Size(106, 15);
            lblPaymentMethod.TabIndex = 6;
            lblPaymentMethod.Text = "Payment Method:";
            // 
            // lblAmountDueVal
            // 
            lblAmountDueVal.AutoSize = true;
            lblAmountDueVal.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblAmountDueVal.ForeColor = Color.FromArgb(220, 53, 69);
            lblAmountDueVal.Location = new Point(12, 118);
            lblAmountDueVal.Name = "lblAmountDueVal";
            lblAmountDueVal.Size = new Size(54, 20);
            lblAmountDueVal.TabIndex = 7;
            lblAmountDueVal.Text = "₱ 0.00";
            // 
            // lblAmountDue
            // 
            lblAmountDue.AutoSize = true;
            lblAmountDue.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblAmountDue.Location = new Point(12, 100);
            lblAmountDue.Name = "lblAmountDue";
            lblAmountDue.Size = new Size(81, 15);
            lblAmountDue.TabIndex = 8;
            lblAmountDue.Text = "Amount Due:";
            // 
            // cmbPendingReservations
            // 
            cmbPendingReservations.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPendingReservations.Font = new Font("Segoe UI", 9F);
            cmbPendingReservations.FormattingEnabled = true;
            cmbPendingReservations.Location = new Point(12, 65);
            cmbPendingReservations.Name = "cmbPendingReservations";
            cmbPendingReservations.Size = new Size(212, 23);
            cmbPendingReservations.TabIndex = 9;
            cmbPendingReservations.SelectedIndexChanged += cmbPendingReservations_SelectedIndexChanged;
            // 
            // lblReservation
            // 
            lblReservation.AutoSize = true;
            lblReservation.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblReservation.Location = new Point(12, 45);
            lblReservation.Name = "lblReservation";
            lblReservation.Size = new Size(115, 15);
            lblReservation.TabIndex = 10;
            lblReservation.Text = "Select Reservation:";
            // 
            // lblMakePaymentHeader
            // 
            lblMakePaymentHeader.AutoSize = true;
            lblMakePaymentHeader.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblMakePaymentHeader.Location = new Point(12, 12);
            lblMakePaymentHeader.Name = "lblMakePaymentHeader";
            lblMakePaymentHeader.Size = new Size(119, 19);
            lblMakePaymentHeader.TabIndex = 11;
            lblMakePaymentHeader.Text = "Submit Payment";
            // 
            // pnlHistory
            // 
            pnlHistory.BackColor = Color.White;
            pnlHistory.BorderStyle = BorderStyle.FixedSingle;
            pnlHistory.Controls.Add(btnRefresh);
            pnlHistory.Controls.Add(dgvPaymentHistory);
            pnlHistory.Controls.Add(lblHistoryHeader);
            pnlHistory.Location = new Point(320, 63);
            pnlHistory.Name = "pnlHistory";
            pnlHistory.Size = new Size(388, 410);
            pnlHistory.TabIndex = 0;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.FromArgb(108, 117, 125);
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(296, 10);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(80, 25);
            btnRefresh.TabIndex = 0;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // dgvPaymentHistory
            // 
            dgvPaymentHistory.AllowUserToAddRows = false;
            dgvPaymentHistory.AllowUserToDeleteRows = false;
            dgvPaymentHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPaymentHistory.BackgroundColor = Color.White;
            dgvPaymentHistory.BorderStyle = BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(235, 238, 242);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvPaymentHistory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvPaymentHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPaymentHistory.Columns.AddRange(new DataGridViewColumn[] { colPaymentId, colReservationId, colAmount, colMethod, colRefNo, colDate, colStatus });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 8.5F);
            dataGridViewCellStyle2.ForeColor = Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(13, 110, 253);
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvPaymentHistory.DefaultCellStyle = dataGridViewCellStyle2;
            dgvPaymentHistory.Location = new Point(12, 45);
            dgvPaymentHistory.MultiSelect = false;
            dgvPaymentHistory.Name = "dgvPaymentHistory";
            dgvPaymentHistory.ReadOnly = true;
            dgvPaymentHistory.RowHeadersVisible = false;
            dgvPaymentHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPaymentHistory.Size = new Size(364, 350);
            dgvPaymentHistory.TabIndex = 1;
            // 
            // colPaymentId
            // 
            colPaymentId.FillWeight = 35F;
            colPaymentId.HeaderText = "ID";
            colPaymentId.Name = "colPaymentId";
            colPaymentId.ReadOnly = true;
            // 
            // colReservationId
            // 
            colReservationId.FillWeight = 45F;
            colReservationId.HeaderText = "Res ID";
            colReservationId.Name = "colReservationId";
            colReservationId.ReadOnly = true;
            // 
            // colAmount
            // 
            colAmount.FillWeight = 65F;
            colAmount.HeaderText = "Amount";
            colAmount.Name = "colAmount";
            colAmount.ReadOnly = true;
            // 
            // colMethod
            // 
            colMethod.FillWeight = 65F;
            colMethod.HeaderText = "Method";
            colMethod.Name = "colMethod";
            colMethod.ReadOnly = true;
            // 
            // colRefNo
            // 
            colRefNo.FillWeight = 70F;
            colRefNo.HeaderText = "Ref No.";
            colRefNo.Name = "colRefNo";
            colRefNo.ReadOnly = true;
            // 
            // colDate
            // 
            colDate.FillWeight = 75F;
            colDate.HeaderText = "Date";
            colDate.Name = "colDate";
            colDate.ReadOnly = true;
            // 
            // colStatus
            // 
            colStatus.FillWeight = 55F;
            colStatus.HeaderText = "Status";
            colStatus.Name = "colStatus";
            colStatus.ReadOnly = true;
            // 
            // lblHistoryHeader
            // 
            lblHistoryHeader.AutoSize = true;
            lblHistoryHeader.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblHistoryHeader.Location = new Point(12, 12);
            lblHistoryHeader.Name = "lblHistoryHeader";
            lblHistoryHeader.Size = new Size(122, 19);
            lblHistoryHeader.TabIndex = 2;
            lblHistoryHeader.Text = "Payment History";
            // 
            // ClientPaymentsView
            // 
            BackColor = Color.FromArgb(245, 246, 250);
            Controls.Add(pnlHistory);
            Controls.Add(pnlMakePayment);
            Controls.Add(lblTitle);
            Name = "ClientPaymentsView";
            Size = new Size(747, 512);
            pnlMakePayment.ResumeLayout(false);
            pnlMakePayment.PerformLayout();
            ((ISupportInitialize)numAmountToPay).EndInit();
            pnlHistory.ResumeLayout(false);
            pnlHistory.PerformLayout();
            ((ISupportInitialize)dgvPaymentHistory).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Panel pnlMakePayment;
        private Label lblMakePaymentHeader;
        private Label lblReservation;
        private ComboBox cmbPendingReservations;
        private Label lblAmountDue;
        private Label lblAmountDueVal;
        private Label lblPaymentMethod;
        private ComboBox cmbPaymentMethod;
        private Label lblAmountToPay;
        private NumericUpDown numAmountToPay;
        private Label lblReferenceNo;
        private TextBox txtReferenceNo;
        private Button btnSubmitPayment;

        private Panel pnlHistory;
        private Label lblHistoryHeader;
        private Button btnRefresh;
        private DataGridView dgvPaymentHistory;

        private DataGridViewTextBoxColumn colPaymentId;
        private DataGridViewTextBoxColumn colReservationId;
        private DataGridViewTextBoxColumn colAmount;
        private DataGridViewTextBoxColumn colMethod;
        private DataGridViewTextBoxColumn colRefNo;
        private DataGridViewTextBoxColumn colDate;
        private DataGridViewTextBoxColumn colStatus;
    }
}