using System;
using System.Drawing;
using System.Windows.Forms;

namespace Event_Reservation_and_Venue_Management_System
{
    public partial class Form1 : Form
    {
        private Button currentActiveButton;
        public Form1()
        {
            InitializeComponent();

            // Load default view on startup
            LoadView(new ucDashboard());
        }

        private void LoadView(UserControl userControl)
        {
            pnlMainContent.Controls.Clear();          // Remove existing view
            userControl.Dock = DockStyle.Fill;        // Stretch view to fit main panel
            pnlMainContent.Controls.Add(userControl); // Add new view
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
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
