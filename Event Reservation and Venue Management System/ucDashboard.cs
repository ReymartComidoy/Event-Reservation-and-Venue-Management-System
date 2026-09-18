using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Event_Reservation_and_Venue_Management_System
{
    public partial class ucDashboard : UserControl
    {
        private DataTable dashboardTable;
        private readonly INavigationService _navigationService;
        public ucDashboard()
        {
            InitializeComponent();

            // Run setup directly in constructor to guarantee immediate load
            ConfigureGrid();

            // Register Event Handlers
            txtSearch.TextChanged += FilterEvents;
            btnSearch.Click += FilterEvents;
            dgvDashboardEvents.CellPainting += dgvDashboardEvents_CellPainting;
        }
        public ucDashboard(INavigationService navigationService) : this()
        {
            _navigationService = navigationService;
        }
        private void ucDashboard_Load(object sender, EventArgs e)
        {
            // Kept empty to prevent double execution
            RefreshDashboardData();
        }
        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            if (this.Visible)
            {
                RefreshDashboardData();
            }
        }
        public void RefreshDashboardData()
        {
            // Bind Shared Data from Centralized Repository
            dgvDashboardEvents.DataSource = null;
            dgvDashboardEvents.DataSource = DataRepository.EventsTable;

            // Recalculate KPI Summary Cards Dynamically
            UpdateMetrics();
        }

        // --- 1. Grid Configuration & Pre-populated Data ---
        private void ConfigureGrid()
        {
            dgvDashboardEvents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDashboardEvents.RowHeadersVisible = false;
            dgvDashboardEvents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDashboardEvents.AllowUserToAddRows = false;
            dgvDashboardEvents.RowTemplate.Height = 35;
            dgvDashboardEvents.ColumnHeadersHeight = 35;
        }
        public void UpdateMetrics()
        {
            // Dynamic metric counts derived directly from shared tables
            if (DataRepository.EventsTable != null)
            {
                lblActiveEventsCount.Text = DataRepository.EventsTable.Rows.Count.ToString();
            }

            if (DataRepository.ReservationsTable != null)
            {
                lblUpcomingReservationsCount.Text = DataRepository.ReservationsTable.Rows.Count.ToString();
            }

            if (DataRepository.VenuesTable != null)
            {
                int totalVenues = DataRepository.VenuesTable.Rows.Count;
                int availableVenues = DataRepository.VenuesTable.Select("[Status] = 'Available'").Length;
                lblVenuesAvailableCount.Text = $"{availableVenues}"; // Displays count of available venues
            }

            lblTotalBookingsTodayCount.Text = "3"; // Keep or bind to daily bookings query
        }
        // --- 3. Live Search Filtering ---
        private void FilterEvents(object sender, EventArgs e)
        {
            string searchKeyword = txtSearch.Text.Replace("'", "''").Trim();

            if (dgvDashboardEvents.DataSource is DataTable dt)
            {
                if (string.IsNullOrEmpty(searchKeyword))
                {
                    dt.DefaultView.RowFilter = "";
                }
                else
                {
                    dt.DefaultView.RowFilter =
                        $"[Event Name] LIKE '%{searchKeyword}%' OR [Venue] LIKE '%{searchKeyword}%' OR [Status] LIKE '%{searchKeyword}%'";
                }
            }
        }
        private INavigationService GetNav()
        {
            // Uses injected service, or dynamically fetches Form1 if null
            return _navigationService ?? (this.FindForm() as INavigationService);
        }
        // --- 4. Quick Action Buttons ---
        private void btnNewReservation_Click(object sender, EventArgs e)
        {
            //NavigateToModule("RESERVATIONS");
            //_navigationService?.NavigateTo(ViewModule.Reservations);
            GetNav()?.NavigateTo(ViewModule.Reservations);
        }

        private void btnCheckAvailability_Click(object sender, EventArgs e)
        {
            //NavigateToModule("VENUES");
            //_navigationService?.NavigateTo(ViewModule.Venues);
            GetNav()?.NavigateTo(ViewModule.Venues);
        }

        private void btnAddEvent_Click(object sender, EventArgs e)
        {
            //NavigateToModule("EVENTS");
            //_navigationService?.NavigateTo(ViewModule.Events);
            GetNav()?.NavigateTo(ViewModule.Events);
        }

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Generating dashboard summary report...", "Generate Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // --- 5. Status Pill Custom Rendering ---
        private void dgvDashboardEvents_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && dgvDashboardEvents.Columns[e.ColumnIndex].Name == "Status")
            {
                e.PaintBackground(e.CellBounds, true);

                string status = e.Value?.ToString() ?? "";
                Color pillColor;

                switch (status)
                {
                    case "Upcoming":
                        pillColor = Color.FromArgb(40, 167, 69); // Green
                        break;
                    case "Ongoing":
                        pillColor = Color.FromArgb(0, 123, 255); // Blue
                        break;
                    case "Completed":
                        pillColor = Color.FromArgb(108, 117, 125); // Gray
                        break;
                    default:
                        pillColor = Color.FromArgb(255, 193, 7); // Yellow
                        break;
                }

                Rectangle rect = new Rectangle(e.CellBounds.X + 8, e.CellBounds.Y + 6, e.CellBounds.Width - 16, e.CellBounds.Height - 12);

                using (Brush brush = new SolidBrush(pillColor))
                using (GraphicsPath path = GetRoundedPath(rect, 10))
                using (StringFormat sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
                {
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    e.Graphics.FillPath(brush, path);

                    using (Brush textBrush = new SolidBrush(Color.White))
                    {
                        e.Graphics.DrawString(status, dgvDashboardEvents.Font, textBrush, rect, sf);
                    }
                }
                e.Handled = true;
            }
        }

        private GraphicsPath GetRoundedPath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90);
            path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90);
            path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90);
            path.CloseFigure();
            return path;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
