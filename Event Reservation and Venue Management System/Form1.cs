using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Button = System.Windows.Forms.Button;
using Color = System.Drawing.Color;
using Font = System.Drawing.Font;
using Event_Reservation_and_Venue_Management_System.Controls;
using Event_Reservation_and_Venue_Management_System.Helpers;
using Event_Reservation_and_Venue_Management_System.Services;

namespace Event_Reservation_and_Venue_Management_System
{
    public partial class Form1 : Form, INavigationService
    {
        private readonly Dictionary<ViewModule, UserControl> _views = new Dictionary<ViewModule, UserControl>();

        public Form1()
        {
            InitializeComponent();
            UIHelper.ApplyPoppins(this);
            InitializeNavigation();
            NavigateTo(ViewModule.Dashboard); // Default view on startup
        }

        private void InitializeNavigation()
        {
            // Register view instances passing 'this' for INavigationService dependency
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
            if (!_views.TryGetValue(module, out UserControl activeView)) return;

            // 1. Swap active control in main panel
            pnlMainContainer.Controls.Clear();
            activeView.Dock = DockStyle.Fill;
            pnlMainContainer.Controls.Add(activeView);
            activeView.BringToFront();
            UIHelper.ApplyPoppins(activeView);

            // 2. Update Sidebar Highlight Button State
            HighlightSidebarButton(module);
        }

        private void HighlightSidebarButton(ViewModule activeModule)
        {
            ResetSidebarButtons();

            Button? activeButton = null;
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
                activeButton.Font = new Font(activeButton.Font, FontStyle.Bold);
            }
        }

        private void ResetSidebarButtons()
        {
            foreach (Control ctrl in pnlSidebar.Controls)
            {
                if (ctrl is Button btn)
                {
                    btn.BackColor = Color.FromArgb(33, 37, 41); // Default Sidebar Background
                    btn.ForeColor = Color.White;
                    btn.Font = new Font(btn.Font, FontStyle.Regular);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e) { }
    }
}