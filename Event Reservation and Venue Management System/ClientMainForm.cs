using System;
using System.Drawing;
using System.Windows.Forms;
using Event_Reservation_and_Venue_Management_System.Controls;
using User = Event_Reservation_and_Venue_Management_System.Models.User;

namespace Event_Reservation_and_Venue_Management_System
{
    public partial class ClientMainForm : Form
    {
        private UserControl? _currentView;
        private Button? _activeNavButton;
        private User _currentUser = null!;

        public ClientMainForm()
        {
            InitializeComponent();

            // Set default active button and view on form open
            SetActiveNavButton(btnHome);
            NavigateTo<ClientHomeView>();
        }

        public void SetUserSession(User user)
        {
            _currentUser = user;
            lblWelcome.Text = $"Welcome, {user.FullName}";
            lblUserRole.Text = "Client Account";

            // Pass user context to current view if applicable
            if (_currentView is IClientUserContextAware userContextAware)
            {
                userContextAware.SetCurrentUser(_currentUser);
            }
        }

        #region Navigation Router

        private void NavigateTo<T>() where T : UserControl, new()
        {
            if (_currentView != null)
            {
                pnlContent.Controls.Remove(_currentView);
                _currentView.Dispose();
            }

            // Instantiate UserControl directly
            _currentView = new T();

            if (_currentUser != null && _currentView is IClientUserContextAware userContextAware)
            {
                userContextAware.SetCurrentUser(_currentUser);
            }

            _currentView.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(_currentView);
        }

        private void SetActiveNavButton(Button btn)
        {
            if (_activeNavButton != null)
            {
                _activeNavButton.ForeColor = Color.White; // Reset default text color
                _activeNavButton.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            }

            _activeNavButton = btn;
            _activeNavButton.ForeColor = Color.FromArgb(13, 110, 253); // Highlight active button
        }

        #endregion

        #region Sidebar Event Handlers

        private void btnHome_Click(object sender, EventArgs e)
        {
            SetActiveNavButton((Button)sender);
            NavigateTo<ClientHomeView>();
        }

        private void btnBrowseVenues_Click(object sender, EventArgs e)
        {
            SetActiveNavButton((Button)sender);
            NavigateTo<BrowseVenuesView>();
        }

        private void btnCheckAvailability_Click(object sender, EventArgs e)
        {
            SetActiveNavButton((Button)sender);
            NavigateTo<CheckAvailabilityView>();
        }

        private void btnMakeReservation_Click(object sender, EventArgs e)
        {
            SetActiveNavButton((Button)sender);
            NavigateTo<MakeReservationView>();
        }

        private void btnMyReservations_Click(object sender, EventArgs e)
        {
            SetActiveNavButton((Button)sender);
            NavigateTo<MyReservationsView>();
        }

        private void btnPayments_Click(object sender, EventArgs e)
        {
            SetActiveNavButton((Button)sender);
            NavigateTo<ClientPaymentsView>();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to log out?", "Logout",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        #endregion
    }

    public interface IClientUserContextAware
    {
        void SetCurrentUser(User user);
    }
}