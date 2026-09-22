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
            pnlMainContainer = new Panel();
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
            pnlSidebar.Size = new Size(200, 526);
            pnlSidebar.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(12, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(167, 112);
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
            btnClients.Location = new Point(0, 321);
            btnClients.Name = "btnClients";
            btnClients.Size = new Size(200, 45);
            btnClients.TabIndex = 5;
            btnClients.Text = "CLIENTS";
            btnClients.UseVisualStyleBackColor = true;
            
            // 
            // btnReservations
            // 
            btnReservations.FlatAppearance.BorderSize = 0;
            btnReservations.FlatStyle = FlatStyle.Flat;
            btnReservations.Font = new Font("Segoe UI", 9.5F);
            btnReservations.ForeColor = Color.White;
            btnReservations.Location = new Point(0, 219);
            btnReservations.Name = "btnReservations";
            btnReservations.Size = new Size(200, 45);
            btnReservations.TabIndex = 4;
            btnReservations.Text = "RESERVATIONS";
            btnReservations.UseVisualStyleBackColor = true;
            
            // 
            // btnVenues
            // 
            btnVenues.FlatAppearance.BorderSize = 0;
            btnVenues.FlatStyle = FlatStyle.Flat;
            btnVenues.Font = new Font("Segoe UI", 9.5F);
            btnVenues.ForeColor = Color.White;
            btnVenues.Location = new Point(0, 270);
            btnVenues.Name = "btnVenues";
            btnVenues.Size = new Size(200, 45);
            btnVenues.TabIndex = 3;
            btnVenues.Text = "VENUES";
            btnVenues.UseVisualStyleBackColor = true;
            
            // 
            // btnEvents
            // 
            btnEvents.FlatAppearance.BorderSize = 0;
            btnEvents.FlatStyle = FlatStyle.Flat;
            btnEvents.Font = new Font("Segoe UI", 9.5F);
            btnEvents.ForeColor = Color.White;
            btnEvents.Location = new Point(0, 168);
            btnEvents.Name = "btnEvents";
            btnEvents.Size = new Size(200, 45);
            btnEvents.TabIndex = 2;
            btnEvents.Text = "EVENTS";
            btnEvents.UseVisualStyleBackColor = true;
            
            // 
            // btnDashboard
            // 
            btnDashboard.FlatAppearance.BorderSize = 0;
            btnDashboard.FlatStyle = FlatStyle.Flat;
            btnDashboard.Font = new Font("Segoe UI", 9.5F);
            btnDashboard.ForeColor = Color.White;
            btnDashboard.Location = new Point(0, 118);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.Size = new Size(200, 45);
            btnDashboard.TabIndex = 1;
            btnDashboard.Text = "DASHBOARD";
            btnDashboard.UseVisualStyleBackColor = true;
            
            // 
            // pnlMainContainer
            // 
            pnlMainContainer.Dock = DockStyle.Fill;
            pnlMainContainer.Location = new Point(200, 0);
            pnlMainContainer.Name = "pnlMainContainer";
            pnlMainContainer.Size = new Size(821, 526);
            pnlMainContainer.TabIndex = 1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1021, 526);
            Controls.Add(pnlMainContainer);
            Controls.Add(pnlSidebar);
            Name = "Form1";
            ShowIcon = false;
            Text = string.Empty;
            Load += Form1_Load;
            pnlSidebar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlSidebar;
        private Button btnEvents;
        private Button btnDashboard;
        private Panel pnlMainContainer;
        private Button btnReservations;
        private Button btnVenues;
        private Button btnClients;
        private PictureBox pictureBox1;
    }
}
