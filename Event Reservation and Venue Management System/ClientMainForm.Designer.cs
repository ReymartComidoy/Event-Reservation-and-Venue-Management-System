namespace Event_Reservation_and_Venue_Management_System
{
    partial class ClientMainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(ClientMainForm));
            pnlSidebar = new Panel();
            btnLogout = new Button();
            btnPayments = new Button();
            btnMyReservations = new Button();
            btnMakeReservation = new Button();
            btnCheckAvailability = new Button();
            btnBrowseVenues = new Button();
            pictureBox1 = new PictureBox();
            btnHome = new Button();
            pnlContent = new Panel();
            panel1 = new Panel();
            lblUserRole = new Label();
            lblWelcome = new Label();
            pnlSidebar.SuspendLayout();
            ((ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // pnlSidebar
            // 
            pnlSidebar.BackColor = Color.FromArgb(33, 37, 41);
            pnlSidebar.Controls.Add(btnLogout);
            pnlSidebar.Controls.Add(btnPayments);
            pnlSidebar.Controls.Add(btnMyReservations);
            pnlSidebar.Controls.Add(btnMakeReservation);
            pnlSidebar.Controls.Add(btnCheckAvailability);
            pnlSidebar.Controls.Add(btnBrowseVenues);
            pnlSidebar.Controls.Add(pictureBox1);
            pnlSidebar.Controls.Add(btnHome);
            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.Location = new Point(0, 0);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Size = new Size(219, 590);
            pnlSidebar.TabIndex = 0;
            // 
            // btnLogout
            // 
            btnLogout.Anchor = AnchorStyles.None;
            btnLogout.BackColor = Color.FromArgb(33, 37, 41);
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogout.ForeColor = Color.Tomato;
            btnLogout.Location = new Point(49, 502);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(112, 37);
            btnLogout.TabIndex = 13;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnPayments
            // 
            btnPayments.Anchor = AnchorStyles.None;
            btnPayments.BackColor = Color.FromArgb(33, 37, 41);
            btnPayments.FlatAppearance.BorderSize = 0;
            btnPayments.FlatStyle = FlatStyle.Flat;
            btnPayments.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPayments.ForeColor = Color.White;
            btnPayments.Location = new Point(-3, 434);
            btnPayments.Name = "btnPayments";
            btnPayments.Size = new Size(225, 53);
            btnPayments.TabIndex = 12;
            btnPayments.Text = "Payments";
            btnPayments.UseVisualStyleBackColor = false;
            btnPayments.Click += btnPayments_Click;
            // 
            // btnMyReservations
            // 
            btnMyReservations.Anchor = AnchorStyles.None;
            btnMyReservations.BackColor = Color.FromArgb(33, 37, 41);
            btnMyReservations.FlatAppearance.BorderSize = 0;
            btnMyReservations.FlatStyle = FlatStyle.Flat;
            btnMyReservations.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnMyReservations.ForeColor = Color.White;
            btnMyReservations.Location = new Point(-3, 375);
            btnMyReservations.Name = "btnMyReservations";
            btnMyReservations.Size = new Size(225, 53);
            btnMyReservations.TabIndex = 11;
            btnMyReservations.Text = "My Reservations";
            btnMyReservations.UseVisualStyleBackColor = false;
            btnMyReservations.Click += btnMyReservations_Click;
            // 
            // btnMakeReservation
            // 
            btnMakeReservation.Anchor = AnchorStyles.None;
            btnMakeReservation.BackColor = Color.FromArgb(33, 37, 41);
            btnMakeReservation.FlatAppearance.BorderSize = 0;
            btnMakeReservation.FlatStyle = FlatStyle.Flat;
            btnMakeReservation.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnMakeReservation.ForeColor = Color.White;
            btnMakeReservation.Location = new Point(-3, 316);
            btnMakeReservation.Name = "btnMakeReservation";
            btnMakeReservation.Size = new Size(225, 53);
            btnMakeReservation.TabIndex = 10;
            btnMakeReservation.Text = "Make Reservation";
            btnMakeReservation.UseVisualStyleBackColor = false;
            btnMakeReservation.Click += btnMakeReservation_Click;
            // 
            // btnCheckAvailability
            // 
            btnCheckAvailability.Anchor = AnchorStyles.None;
            btnCheckAvailability.BackColor = Color.FromArgb(33, 37, 41);
            btnCheckAvailability.FlatAppearance.BorderSize = 0;
            btnCheckAvailability.FlatStyle = FlatStyle.Flat;
            btnCheckAvailability.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCheckAvailability.ForeColor = Color.White;
            btnCheckAvailability.Location = new Point(-3, 257);
            btnCheckAvailability.Name = "btnCheckAvailability";
            btnCheckAvailability.Size = new Size(225, 53);
            btnCheckAvailability.TabIndex = 9;
            btnCheckAvailability.Text = "Check Availability";
            btnCheckAvailability.UseVisualStyleBackColor = false;
            btnCheckAvailability.Click += btnCheckAvailability_Click;
            // 
            // btnBrowseVenues
            // 
            btnBrowseVenues.Anchor = AnchorStyles.None;
            btnBrowseVenues.BackColor = Color.FromArgb(33, 37, 41);
            btnBrowseVenues.FlatAppearance.BorderSize = 0;
            btnBrowseVenues.FlatStyle = FlatStyle.Flat;
            btnBrowseVenues.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBrowseVenues.ForeColor = Color.White;
            btnBrowseVenues.Location = new Point(-3, 198);
            btnBrowseVenues.Name = "btnBrowseVenues";
            btnBrowseVenues.Size = new Size(225, 53);
            btnBrowseVenues.TabIndex = 8;
            btnBrowseVenues.Text = "Browse Venues";
            btnBrowseVenues.UseVisualStyleBackColor = false;
            btnBrowseVenues.Click += btnBrowseVenues_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Top;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(219, 108);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // btnHome
            // 
            btnHome.Anchor = AnchorStyles.None;
            btnHome.BackColor = Color.FromArgb(33, 37, 41);
            btnHome.FlatAppearance.BorderSize = 0;
            btnHome.FlatStyle = FlatStyle.Flat;
            btnHome.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnHome.ForeColor = Color.White;
            btnHome.Location = new Point(-3, 139);
            btnHome.Name = "btnHome";
            btnHome.Size = new Size(225, 53);
            btnHome.TabIndex = 7;
            btnHome.Text = "Home";
            btnHome.UseVisualStyleBackColor = false;
            btnHome.Click += btnHome_Click;
            // 
            // pnlContent
            // 
            pnlContent.Dock = DockStyle.Bottom;
            pnlContent.Location = new Point(219, 78);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new Size(747, 512);
            pnlContent.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.Controls.Add(lblUserRole);
            panel1.Controls.Add(lblWelcome);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(219, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(747, 78);
            panel1.TabIndex = 2;
            // 
            // lblUserRole
            // 
            lblUserRole.AutoSize = true;
            lblUserRole.Font = new Font("Segoe UI", 9.75F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblUserRole.Location = new Point(6, 30);
            lblUserRole.Name = "lblUserRole";
            lblUserRole.Size = new Size(88, 17);
            lblUserRole.TabIndex = 1;
            lblUserRole.Text = "Client Account";
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblWelcome.Location = new Point(6, 9);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(148, 21);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "Welcome, [Name]";
            // 
            // ClientMainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(966, 590);
            Controls.Add(panel1);
            Controls.Add(pnlContent);
            Controls.Add(pnlSidebar);
            Name = "ClientMainForm";
            Text = "ClientMainForm";
            pnlSidebar.ResumeLayout(false);
            ((ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlSidebar;
        private Button btnPayments;
        private Button btnMyReservations;
        private Button btnMakeReservation;
        private Button btnCheckAvailability;
        private Button btnBrowseVenues;
        private PictureBox pictureBox1;
        private Button btnHome;
        private Button btnLogout;
        private Panel pnlContent;
        private Panel panel1;
        private Label lblUserRole;
        private Label lblWelcome;
    }
}