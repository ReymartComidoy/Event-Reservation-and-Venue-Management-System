namespace Event_Reservation_and_Venue_Management_System
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            pnlSidebar = new Panel();
            pictureBox1 = new PictureBox();
            btnClients = new Button();
            btnReservations = new Button();
            btnVenues = new Button();
            btnEvents = new Button();
            btnDashboard = new Button();
            pnlMainContent = new Panel();
            pnlSidebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pnlSidebar
            // 
            pnlSidebar.BackColor = Color.FromArgb(33, 37, 41);
            pnlSidebar.Controls.Add(pictureBox1);
            pnlSidebar.Controls.Add(btnClients);
            pnlSidebar.Controls.Add(btnReservations);
            pnlSidebar.Controls.Add(btnVenues);
            pnlSidebar.Controls.Add(btnEvents);
            pnlSidebar.Controls.Add(btnDashboard);
            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.Location = new Point(0, 0);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Size = new Size(200, 495);
            pnlSidebar.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(29, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(131, 88);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // btnClients
            // 
            btnClients.FlatAppearance.BorderSize = 0;
            btnClients.FlatStyle = FlatStyle.Flat;
            btnClients.Font = new Font("Segoe UI", 9.5F);
            btnClients.ForeColor = Color.White;
            btnClients.Location = new Point(0, 275);
            btnClients.Name = "btnClients";
            btnClients.Size = new Size(200, 45);
            btnClients.TabIndex = 5;
            btnClients.Text = "CLIENTS";
            btnClients.UseVisualStyleBackColor = true;
            btnClients.Click += btnClients_Click;
            // 
            // btnReservations
            // 
            btnReservations.FlatAppearance.BorderSize = 0;
            btnReservations.FlatStyle = FlatStyle.Flat;
            btnReservations.Font = new Font("Segoe UI", 9.5F);
            btnReservations.ForeColor = Color.White;
            btnReservations.Location = new Point(0, 233);
            btnReservations.Name = "btnReservations";
            btnReservations.Size = new Size(200, 45);
            btnReservations.TabIndex = 4;
            btnReservations.Text = "RESERVATIONS";
            btnReservations.UseVisualStyleBackColor = true;
            btnReservations.Click += btnReservations_Click;
            // 
            // btnVenues
            // 
            btnVenues.FlatAppearance.BorderSize = 0;
            btnVenues.FlatStyle = FlatStyle.Flat;
            btnVenues.Font = new Font("Segoe UI", 9.5F);
            btnVenues.ForeColor = Color.White;
            btnVenues.Location = new Point(0, 191);
            btnVenues.Name = "btnVenues";
            btnVenues.Size = new Size(200, 45);
            btnVenues.TabIndex = 3;
            btnVenues.Text = "VENUES";
            btnVenues.UseVisualStyleBackColor = true;
            btnVenues.Click += btnVenues_Click;
            // 
            // btnEvents
            // 
            btnEvents.FlatAppearance.BorderSize = 0;
            btnEvents.FlatStyle = FlatStyle.Flat;
            btnEvents.Font = new Font("Segoe UI", 9.5F);
            btnEvents.ForeColor = Color.White;
            btnEvents.Location = new Point(0, 149);
            btnEvents.Name = "btnEvents";
            btnEvents.Size = new Size(200, 45);
            btnEvents.TabIndex = 2;
            btnEvents.Text = "EVENTS";
            btnEvents.UseVisualStyleBackColor = true;
            btnEvents.Click += btnEvents_Click;
            // 
            // btnDashboard
            // 
            btnDashboard.FlatAppearance.BorderSize = 0;
            btnDashboard.FlatStyle = FlatStyle.Flat;
            btnDashboard.Font = new Font("Segoe UI", 9.5F);
            btnDashboard.ForeColor = Color.White;
            btnDashboard.Location = new Point(0, 107);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.Size = new Size(200, 45);
            btnDashboard.TabIndex = 1;
            btnDashboard.Text = "DASHBOARD";
            btnDashboard.UseVisualStyleBackColor = true;
            btnDashboard.Click += btnDashboard_Click;
            // 
            // pnlMainContent
            // 
            pnlMainContent.Dock = DockStyle.Fill;
            pnlMainContent.Location = new Point(200, 0);
            pnlMainContent.Name = "pnlMainContent";
            pnlMainContent.Size = new Size(821, 495);
            pnlMainContent.TabIndex = 1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1021, 495);
            Controls.Add(pnlMainContent);
            Controls.Add(pnlSidebar);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            pnlSidebar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlSidebar;
        private Button btnEvents;
        private Button btnDashboard;
        private Panel pnlMainContent;
        private Button btnReservations;
        private Button btnVenues;
        private Button btnClients;
        private PictureBox pictureBox1;
    }
}
