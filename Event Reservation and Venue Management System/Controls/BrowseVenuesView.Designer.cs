namespace Event_Reservation_and_Venue_Management_System.Controls
{
    partial class BrowseVenuesView
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblSearch = new Label();
            txtSearch = new TextBox();
            lblCategory = new Label();
            cmbCategoryFilter = new ComboBox();
            dgvVenues = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colVenueName = new DataGridViewTextBoxColumn();
            colCategory = new DataGridViewTextBoxColumn();
            colCapacity = new DataGridViewTextBoxColumn();
            colRate = new DataGridViewTextBoxColumn();
            colLocation = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            btnBookSelected = new Button();
            ((ISupportInitialize)dgvVenues).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.Black;
            lblTitle.Location = new Point(20, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(200, 25);
            lblTitle.TabIndex = 6;
            lblTitle.Text = "Browse Event Venues";
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblSearch.Location = new Point(20, 60);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(52, 17);
            lblSearch.TabIndex = 5;
            lblSearch.Text = "Search:";
            // 
            // txtSearch
            // 
            txtSearch.Font = new Font("Segoe UI", 9.5F);
            txtSearch.Location = new Point(20, 82);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Search by venue name or location...";
            txtSearch.Size = new Size(280, 24);
            txtSearch.TabIndex = 4;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblCategory.Location = new Point(320, 60);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(68, 17);
            lblCategory.TabIndex = 3;
            lblCategory.Text = "Category:";
            // 
            // cmbCategoryFilter
            // 
            cmbCategoryFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategoryFilter.Font = new Font("Segoe UI", 9.5F);
            cmbCategoryFilter.FormattingEnabled = true;
            cmbCategoryFilter.Location = new Point(320, 82);
            cmbCategoryFilter.Name = "cmbCategoryFilter";
            cmbCategoryFilter.Size = new Size(232, 25);
            cmbCategoryFilter.TabIndex = 2;
            cmbCategoryFilter.SelectedIndexChanged += cmbCategoryFilter_SelectedIndexChanged;
            // 
            // dgvVenues
            // 
            dgvVenues.AllowUserToAddRows = false;
            dgvVenues.AllowUserToDeleteRows = false;
            dgvVenues.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvVenues.BackgroundColor = Color.White;
            dgvVenues.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVenues.Columns.AddRange(new DataGridViewColumn[] { colId, colVenueName, colCategory, colCapacity, colRate, colLocation, colStatus });
            dgvVenues.Location = new Point(20, 125);
            dgvVenues.MultiSelect = false;
            dgvVenues.Name = "dgvVenues";
            dgvVenues.ReadOnly = true;
            dgvVenues.RowHeadersVisible = false;
            dgvVenues.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVenues.Size = new Size(707, 362);
            dgvVenues.TabIndex = 1;
            // 
            // colId
            // 
            colId.HeaderText = "ID";
            colId.Name = "colId";
            colId.ReadOnly = true;
            colId.Visible = false;
            // 
            // colVenueName
            // 
            colVenueName.HeaderText = "Venue Name";
            colVenueName.Name = "colVenueName";
            colVenueName.ReadOnly = true;
            // 
            // colCategory
            // 
            colCategory.HeaderText = "Category";
            colCategory.Name = "colCategory";
            colCategory.ReadOnly = true;
            // 
            // colCapacity
            // 
            colCapacity.HeaderText = "Capacity";
            colCapacity.Name = "colCapacity";
            colCapacity.ReadOnly = true;
            // 
            // colRate
            // 
            colRate.HeaderText = "Rate / Hour";
            colRate.Name = "colRate";
            colRate.ReadOnly = true;
            // 
            // colLocation
            // 
            colLocation.HeaderText = "Location";
            colLocation.Name = "colLocation";
            colLocation.ReadOnly = true;
            // 
            // colStatus
            // 
            colStatus.HeaderText = "Status";
            colStatus.Name = "colStatus";
            colStatus.ReadOnly = true;
            // 
            // btnBookSelected
            // 
            btnBookSelected.BackColor = Color.FromArgb(13, 110, 253);
            btnBookSelected.FlatAppearance.BorderSize = 0;
            btnBookSelected.FlatStyle = FlatStyle.Flat;
            btnBookSelected.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnBookSelected.ForeColor = Color.White;
            btnBookSelected.Location = new Point(592, 82);
            btnBookSelected.Name = "btnBookSelected";
            btnBookSelected.Size = new Size(135, 30);
            btnBookSelected.TabIndex = 0;
            btnBookSelected.Text = "Book Selected";
            btnBookSelected.UseVisualStyleBackColor = false;
            btnBookSelected.Click += btnBookSelected_Click;
            // 
            // BrowseVenuesView
            // 
            BackColor = Color.FromArgb(245, 246, 250);
            Controls.Add(btnBookSelected);
            Controls.Add(dgvVenues);
            Controls.Add(cmbCategoryFilter);
            Controls.Add(lblCategory);
            Controls.Add(txtSearch);
            Controls.Add(lblSearch);
            Controls.Add(lblTitle);
            Name = "BrowseVenuesView";
            Size = new Size(747, 512);
            ((ISupportInitialize)dgvVenues).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblSearch;
        private TextBox txtSearch;
        private Label lblCategory;
        private ComboBox cmbCategoryFilter;
        private DataGridView dgvVenues;
        private Button btnBookSelected;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colVenueName;
        private DataGridViewTextBoxColumn colCategory;
        private DataGridViewTextBoxColumn colCapacity;
        private DataGridViewTextBoxColumn colRate;
        private DataGridViewTextBoxColumn colLocation;
        private DataGridViewTextBoxColumn colStatus;
    }
}