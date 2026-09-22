using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Event_Reservation_and_Venue_Management_System.Services;

namespace Event_Reservation_and_Venue_Management_System.Controls
{
    public partial class ucDashboard : UserControl
    {
        private readonly INavigationService? _navigationService;
        private DataTable _eventsDataTable = DataRepository.EventsTable;

        // Parameterless constructor for WinForms Designer
        public ucDashboard()
        {
            InitializeComponent();
            WireUpEvents();
        }

        // Navigation constructor called by Form1.cs
        public ucDashboard(INavigationService navigationService) : this()
        {
            _navigationService = navigationService;
        }

        private void WireUpEvents()
        {
            this.Load += ucDashboard_Load;
            this.VisibleChanged += ucDashboard_VisibleChanged;

            // Search events
            btnSearch.Click += btnSearch_Click;
            txtSearch.TextChanged += txtSearch_TextChanged;

            // Quick Actions navigation & report
            btnNewReservation.Click += btnNewReservation_Click;
            btnCheckAvailability.Click += btnCheckAvailability_Click;
            btnAddEvent.Click += btnAddEvent_Click;
            btnGenerateReport.Click += btnGenerateReport_Click;
        }

        private void ucDashboard_Load(object? sender, EventArgs e)
        {
            LoadDashboardData();
        }

        private void ucDashboard_VisibleChanged(object? sender, EventArgs e)
        {
            if (this.Visible)
            {
                LoadDashboardData();
            }
        }

        public void LoadDashboardData()
        {
            // Bind shared Events table
            _eventsDataTable = DataRepository.EventsTable;
            dgvDashboardEvents.DataSource = _eventsDataTable;

            // Dynamically calculate counts across all interconnected sections
            lblActiveEventsCount.Text = DataRepository.EventsTable.Select("Status = 'Upcoming' OR Status = 'Active'").Length.ToString();
            lblUpcomingReservationsCount.Text = DataRepository.ReservationsTable.Select("Status = 'Confirmed' OR Status = 'Pending'").Length.ToString();
            lblTotalBookingsTodayCount.Text = DataRepository.ReservationsTable.Rows.Count.ToString();
            lblVenuesAvailableCount.Text = $"{DataRepository.VenuesTable.Select("Status = 'Available'").Length}";
        }



        #region Search Logic

        private void btnSearch_Click(object? sender, EventArgs e)
        {
            ApplySearchFilter();
        }

        private void txtSearch_TextChanged(object? sender, EventArgs e)
        {
            ApplySearchFilter();
        }

        private void ApplySearchFilter()
        {
            if (_eventsDataTable == null) return;

            string query = txtSearch.Text.Trim().Replace("'", "''");
            if (string.IsNullOrEmpty(query))
            {
                _eventsDataTable.DefaultView.RowFilter = string.Empty;
            }
            else
            {
                _eventsDataTable.DefaultView.RowFilter = $"[EventName] LIKE '%{query}%' OR [Venue] LIKE '%{query}%'";
            }
        }

        #endregion

        #region Quick Action Navigation

        private void btnNewReservation_Click(object? sender, EventArgs e)
        {
            _navigationService?.NavigateTo(ViewModule.Reservations);
        }

        private void btnCheckAvailability_Click(object? sender, EventArgs e)
        {
            _navigationService?.NavigateTo(ViewModule.Venues);
        }

        private void btnAddEvent_Click(object? sender, EventArgs e)
        {
            _navigationService?.NavigateTo(ViewModule.Events);
        }

        private void btnGenerateReport_Click(object? sender, EventArgs e)
        {
            ExportToCSV();
        }

        #endregion

        #region Report Generation

        private void ExportToCSV()
        {
            if (dgvDashboardEvents.Rows.Count == 0)
            {
                MessageBox.Show("No data available to generate report.", "Report", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "CSV File (*.csv)|*.csv";
                sfd.FileName = $"Dashboard_Report_{DateTime.Now:yyyyMMdd_HHmmss}.csv";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (StreamWriter sw = new StreamWriter(sfd.FileName))
                        {
                            var headers = dgvDashboardEvents.Columns.Cast<DataGridViewColumn>()
                                .Select(col => $"\"{col.HeaderText}\"");
                            sw.WriteLine(string.Join(",", headers));

                            foreach (DataGridViewRow row in dgvDashboardEvents.Rows)
                            {
                                if (!row.IsNewRow)
                                {
                                    var cells = row.Cells.Cast<DataGridViewCell>()
                                        .Select(cell => $"\"{cell.Value?.ToString()?.Replace("\"", "\"\"")}\"");
                                    sw.WriteLine(string.Join(",", cells));
                                }
                            }
                        }

                        MessageBox.Show("Dashboard report exported successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error generating report: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        #endregion

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}