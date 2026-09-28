using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using User = Event_Reservation_and_Venue_Management_System.Models.User;
using Event_Reservation_and_Venue_Management_System.Services;

namespace Event_Reservation_and_Venue_Management_System.Controls
{
    public partial class BrowseVenuesView : UserControl, IClientUserContextAware
    {
        private User? _currentUser;
        private DataTable _venueTable = new DataTable();
        private readonly VenueService _venueService = new();

        public BrowseVenuesView()
        {
            InitializeComponent();
            InitializeCategories();
            LoadVenueData();
        }

        public void SetCurrentUser(User user)
        {
            _currentUser = user;
        }

        private void InitializeCategories()
        {
            cmbCategoryFilter.Items.Clear();
            cmbCategoryFilter.Items.Add("All Categories");
            cmbCategoryFilter.Items.Add("Golden Palace");
            cmbCategoryFilter.Items.Add("Big 8");
            cmbCategoryFilter.Items.Add("Grand Palm");
            cmbCategoryFilter.SelectedIndex = 0;
        }

        private void LoadVenueData()
        {
            try
            {
                _venueTable = _venueService.GetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unable to load venues.\n\n{ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            ApplyFilters();
        }

        private void ApplyFilters()
        {
            string searchKeyword = txtSearch.Text.Trim().ToLower();
            string selectedCategory = cmbCategoryFilter.SelectedItem?.ToString() ?? "All Categories";

            dgvVenues.Rows.Clear();

            foreach (DataRow row in _venueTable.Rows)
            {
                string venueName = row["VenueName"].ToString() ?? "";
                string category = row["VenueType"].ToString() ?? "";
                string location = row["Location"].ToString() ?? "";

                bool matchesSearch = string.IsNullOrEmpty(searchKeyword) ||
                                     venueName.ToLower().Contains(searchKeyword) ||
                                     location.ToLower().Contains(searchKeyword);

                bool matchesCategory = selectedCategory == "All Categories" || category == selectedCategory;

                if (matchesSearch && matchesCategory)
                {
                    dgvVenues.Rows.Add(
                        row["Id"],
                        row["VenueName"],
                        row["VenueType"],
                        $"{Convert.ToInt32(row["Capacity"]):N0} pax",
                        $"₱ {Convert.ToDecimal(row["PricePerHour"]):N2} / hr",
                        row["Location"],
                        row["Status"]
                    );
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void cmbCategoryFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void btnBookSelected_Click(object sender, EventArgs e)
        {
            if (dgvVenues.SelectedRows.Count > 0)
            {
                string venueName = dgvVenues.SelectedRows[0].Cells["colVenueName"].Value?.ToString() ?? "";
                MessageBox.Show($"Proceeding to book: {venueName}", "Make Reservation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please select a venue from the list first.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}