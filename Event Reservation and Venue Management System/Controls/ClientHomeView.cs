using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Event_Reservation_and_Venue_Management_System.Models;

namespace Event_Reservation_and_Venue_Management_System.Controls
{
    public partial class ClientHomeView : UserControl, IClientUserContextAware
    {
        private User? _currentUser;

        public ClientHomeView()
        {
            InitializeComponent();
        }

        public void SetCurrentUser(User user)
        {
            _currentUser = user;
            LoadDashboardData();
        }

        private void LoadDashboardData()
        {
            // Populate sample metrics or pull from your database
            lblActiveBookingsVal.Text = "0";
            lblPendingBalanceVal.Text = "₱ 15,000.00";
            lblAvailableVenuesVal.Text = "0";

            // Clear and optionally populate data grid rows
            dgvRecentReservations.Rows.Clear();
        }
    }
}
