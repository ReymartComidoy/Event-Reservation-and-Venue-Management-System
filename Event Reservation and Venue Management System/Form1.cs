using System;
using System.Drawing;
using System.Windows.Forms;

namespace Event_Reservation_and_Venue_Management_System
{
    public partial class Form1 : Form, INavigationService
    {
        private readonly Dictionary<ViewModule, UserControl> _views = new Dictionary<ViewModule, UserControl>();
        private Button currentActiveButton;
        public Form1()
        {
            InitializeComponent();
            InitializeNavigation();
            NavigateTo(ViewModule.Dashboard); // Default view on startup
            // Load default view on startup
            LoadView(new ucDashboard());

        }
        private void InitializeNavigation()
        {
            // Register views passing 'this' (INavigationService) for dependency inversion
            _views[ViewModule.Dashboard] = new ucDashboard(this);
            _views[ViewModule.Events] = new ucEvents();
            _views[ViewModule.Venues] = new ucVenue();
            _views[ViewModule.Reservations] = new ucReservations();
            _views[ViewModule.Clients] = new ucClients();

            // Register Sidebar Button Click Events
            btnDashboard.Click += (s, e) => NavigateTo(ViewModule.Dashboard);
            btnEvents.Click += (s, e) => NavigateTo(ViewModule.Events);
            btnVenues.Click += (s, e) => NavigateTo(ViewModule.Venues);
            btnReservations.Click += (s, e) => NavigateTo(ViewModule.Reservations);
            btnClients.Click += (s, e) => NavigateTo(ViewModule.Clients);
        }
        public void NavigateTo(ViewModule module)
        {
            if (!_views.ContainsKey(module)) return;

            // 1. Swap active control in main panel
            UserControl activeView = _views[module];
            pnlMainContainer.Controls.Clear(); // Change to your actual main panel name
            activeView.Dock = DockStyle.Fill;
            pnlMainContainer.Controls.Add(activeView);
            activeView.BringToFront();

            // 2. Update Sidebar Highlight Button State
            HighlightSidebarButton(module);
        }
        private void HighlightSidebarButton(ViewModule activeModule)
        {
            ResetSidebarButtons();

            Button activeButton = null;
            switch (activeModule)
            {
                case ViewModule.Dashboard: activeButton = btnDashboard; break;
                case ViewModule.Events: activeButton = btnEvents; break;
                case ViewModule.Venues: activeButton = btnVenues; break;
                case ViewModule.Reservations: activeButton = btnReservations; break;
                case ViewModule.Clients: activeButton = btnClients; break;
            }

            if (activeButton != null)
            {
                activeButton.BackColor = Color.FromArgb(0, 122, 204); // Active Highlight Blue
                activeButton.ForeColor = Color.White;
                activeButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            }
        }
        private void ResetSidebarButtons()
        {
            foreach (Control ctrl in pnlSidebar.Controls) // Change to your sidebar panel name
            {
                if (ctrl is Button btn)
                {
                    btn.BackColor = Color.FromArgb(33, 37, 41); // Default Sidebar Background
                    btn.ForeColor = Color.White;
                    btn.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular);
                }
            }
        }

        private void LoadView(UserControl userControl)
        {
            pnlMainContainer.Controls.Clear();          // Remove existing view
            userControl.Dock = DockStyle.Fill;        // Stretch view to fit main panel
            pnlMainContainer.Controls.Add(userControl); // Add new view
            userControl.BringToFront();
        }
        private void btnDashboard_Click(object sender, EventArgs e)
        {
            LoadView(new ucDashboard());
            ActivateButton(sender);
            // Load Dashboard UserControl into your main container panel here

        }
        private void btnEvents_Click(object sender, EventArgs e)
        {
            LoadView(new ucEvents());
            ActivateButton(sender);
            // Load Events UserControl here
        }
        private void btnVenues_Click(object sender, EventArgs e)
        {
            LoadView(new ucVenue());
            ActivateButton(sender);
            // Load Events UserControl here
        }
        private void btnReservations_Click(object sender, EventArgs e)
        {
            LoadView(new ucReservations());
            ActivateButton(sender);
            // Load Events UserControl here
        }
        private void btnClients_Click(object sender, EventArgs e)
        {
            LoadView(new ucClients());
            ActivateButton(sender);
            // Load Events UserControl here
        }
        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentActiveButton != (Button)btnSender)
                {
                    DisableButtonHighlight();

                    // Highlight active button
                    currentActiveButton = (Button)btnSender;
                    currentActiveButton.BackColor = Color.FromArgb(0, 122, 204); // Highlight blue
                    currentActiveButton.ForeColor = Color.White;
                    currentActiveButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                }
            }
        }
        private void DisableButtonHighlight()
        {
            foreach (Control previousBtn in pnlSidebar.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(33, 37, 41); // Default sidebar color
                    previousBtn.ForeColor = Color.White;
                    previousBtn.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular);
                }
            }
        }
        // Public method that ucDashboard (or other controls) can call to switch screens
        public void SwitchUserControl(UserControl uc)
        {
            pnlMainContainer.Controls.Clear(); // Replace 'panelMainContainer' with your actual main panel name
            uc.Dock = DockStyle.Fill;
            pnlMainContainer.Controls.Add(uc);
            uc.BringToFront();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
