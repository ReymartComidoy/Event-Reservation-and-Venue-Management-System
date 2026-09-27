using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using User = Event_Reservation_and_Venue_Management_System.Models.User;

namespace Event_Reservation_and_Venue_Management_System.Controls
{
    public partial class ClientPaymentsView : UserControl, IClientUserContextAware
    {
        private User? _currentUser;
        private DataTable _paymentsTable = new DataTable();

        public ClientPaymentsView()
        {
            InitializeComponent();
            InitializePaymentMethods();
            InitializeDataSchema();
        }

        public void SetCurrentUser(User user)
        {
            _currentUser = user;
            LoadPendingReservations();
            LoadPaymentHistory();
        }

        private void InitializePaymentMethods()
        {
            cmbPaymentMethod.Items.Clear();
            cmbPaymentMethod.Items.Add("GCash");
            cmbPaymentMethod.Items.Add("Bank Transfer");
            cmbPaymentMethod.Items.Add("Credit / Debit Card");
            cmbPaymentMethod.Items.Add("Cash");
            cmbPaymentMethod.SelectedIndex = 0;
        }

        private void InitializeDataSchema()
        {
            _paymentsTable.Columns.Clear();
            _paymentsTable.Columns.Add("PaymentId", typeof(int));
            _paymentsTable.Columns.Add("ReservationId", typeof(int));
            _paymentsTable.Columns.Add("AmountPaid", typeof(decimal));
            _paymentsTable.Columns.Add("PaymentMethod", typeof(string));
            _paymentsTable.Columns.Add("ReferenceNumber", typeof(string));
            _paymentsTable.Columns.Add("PaymentDate", typeof(DateTime));
            _paymentsTable.Columns.Add("Status", typeof(string));
        }

        public void LoadPendingReservations()
        {
            cmbPendingReservations.Items.Clear();

            if (_currentUser == null) return;

            // TODO: Fetch approved/pending reservations with outstanding balances from DB
            // Example:
            // var pendingList = _reservationRepository.GetUnpaidReservationsByUser(_currentUser.Id);
            // foreach (var item in pendingList) cmbPendingReservations.Items.Add(item);

            if (cmbPendingReservations.Items.Count == 0)
            {
                lblAmountDueVal.Text = "₱ 0.00";
            }
        }

        public void LoadPaymentHistory()
        {
            if (_currentUser == null) return;

            _paymentsTable.Rows.Clear();

            // TODO: Fetch user payment logs from database
            // Example:
            // DataTable dt = _paymentRepository.GetPaymentsByUserId(_currentUser.Id);
            // _paymentsTable = dt;

            ApplyPaymentFilter();
        }

        private void ApplyPaymentFilter()
        {
            dgvPaymentHistory.Rows.Clear();

            foreach (DataRow row in _paymentsTable.Rows)
            {
                DateTime paymentDate = Convert.ToDateTime(row["PaymentDate"]);
                decimal amount = Convert.ToDecimal(row["AmountPaid"]);

                dgvPaymentHistory.Rows.Add(
                    row["PaymentId"],
                    row["ReservationId"],
                    $"₱ {amount:N2}",
                    row["PaymentMethod"],
                    row["ReferenceNumber"],
                    paymentDate.ToString("yyyy-MM-dd HH:mm"),
                    row["Status"]
                );
            }
        }

        private void cmbPendingReservations_SelectedIndexChanged(object sender, EventArgs e)
        {
            // TODO: Extract fee from selected reservation object
            // Example:
            // if (cmbPendingReservations.SelectedItem is Reservation res)
            // {
            //     lblAmountDueVal.Text = $"₱ {res.RemainingBalance:N2}";
            //     numAmountToPay.Value = res.RemainingBalance;
            // }
        }

        private void btnSubmitPayment_Click(object sender, EventArgs e)
        {
            if (cmbPendingReservations.SelectedItem == null)
            {
                MessageBox.Show("Please select a reservation to make a payment for.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (numAmountToPay.Value <= 0)
            {
                MessageBox.Show("Please enter a valid payment amount greater than zero.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numAmountToPay.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtReferenceNo.Text))
            {
                MessageBox.Show("Please enter the payment Transaction / Reference Number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtReferenceNo.Focus();
                return;
            }

            // TODO: Execute DB service call to record payment
            // bool success = _paymentService.ProcessPayment(_currentUser.Id, reservationId, amount, method, refNo);

            MessageBox.Show("Payment submitted successfully! Pending verification.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            txtReferenceNo.Clear();
            numAmountToPay.Value = 0;
            LoadPendingReservations();
            LoadPaymentHistory();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadPendingReservations();
            LoadPaymentHistory();
        }
    }
}