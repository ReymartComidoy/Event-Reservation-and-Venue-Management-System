using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using User = Event_Reservation_and_Venue_Management_System.Models.User;

namespace Event_Reservation_and_Venue_Management_System.Controls
{
    public partial class BrowseVenuesView : UserControl, IClientUserContextAware
    {
        private User? _currentUser;
        private DataTable _venueTable = new DataTable();

        public BrowseVenuesView()
        {
            InitializeComponent();
            InitializeCategories();
            InitializeVenueData();
        }

        public void SetCurrentUser(User user)
        {
            _currentUser = user;
        }

        private void InitializeCategories()
        {
            cmbCategoryFilter.Items.Clear();
            cmbCategoryFilter.Items.Add("All Categories");
            cmbCategoryFilter.Items.Add("Auditorium / Hall");
            cmbCategoryFilter.Items.Add("Convention Center");
            cmbCategoryFilter.Items.Add("Outdoor / Park");
            cmbCategoryFilter.Items.Add("Function Room");
            cmbCategoryFilter.SelectedIndex = 0;
        }

        private void InitializeVenueData()
        {
            // Set up internal data structure
            _venueTable.Columns.Clear();
            _venueTable.Columns.Add("Id", typeof(int));
            _venueTable.Columns.Add("Name", typeof(string));
            _venueTable.Columns.Add("Category", typeof(string));
            _venueTable.Columns.Add("Capacity", typeof(int));
            _venueTable.Columns.Add("HourlyRate", typeof(decimal));
            _venueTable.Columns.Add("Location", typeof(string));
            _venueTable.Columns.Add("Status", typeof(string));

            // Populate sample venue rows
            _venueTable.Rows.Add(1, "Tagum City Hall Atrium", "Auditorium / Hall", 500, 2500.00m, "JV Ayala Ave, Tagum City", "Available");
            _venueTable.Rows.Add(2, "Mankilam Cultural Center", "Convention Center", 1000, 4500.00m, "Mankilam, Tagum City", "Available");
            _venueTable.Rows.Add(3, "Rotary Park Pavilion", "Outdoor / Park", 300, 1200.00m, "Magugpo Central, Tagum City", "Available");
            _venueTable.Rows.Add(4, "Tagum Trade & Cultural Center", "Convention Center", 800, 3500.00m, "Rizal St, Tagum City", "Under Maintenance");
            _venueTable.Rows.Add(5, "Energy Park Amphitheater", "Outdoor / Park", 1500, 3000.00m, "Apokon, Tagum City", "Available");

            ApplyFilters();
        }

        private void ApplyFilters()
        {
            string searchKeyword = txtSearch.Text.Trim().ToLower();
            string selectedCategory = cmbCategoryFilter.SelectedItem?.ToString() ?? "All Categories";

            dgvVenues.Rows.Clear();

            foreach (DataRow row in _venueTable.Rows)
            {
                string venueName = row["Name"].ToString() ?? "";
                string category = row["Category"].ToString() ?? "";
                string location = row["Location"].ToString() ?? "";

                bool matchesSearch = string.IsNullOrEmpty(searchKeyword) ||
                                     venueName.ToLower().Contains(searchKeyword) ||
                                     location.ToLower().Contains(searchKeyword);

                bool matchesCategory = selectedCategory == "All Categories" || category == selectedCategory;

                if (matchesSearch && matchesCategory)
                {
                    dgvVenues.Rows.Add(
                        row["Id"],
                        row["Name"],
                        row["Category"],
                        $"{Convert.ToInt32(row["Capacity"]):N0} pax",
                        $"₱ {Convert.ToDecimal(row["HourlyRate"]):N2} / hr",
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