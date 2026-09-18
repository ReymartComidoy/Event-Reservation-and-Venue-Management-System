namespace Event_Reservation_and_Venue_Management_System
{
    partial class ucDashboard
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucDashboard));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            panel1 = new Panel();
            panel5 = new Panel();
            label12 = new Label();
            lblVenuesAvailableCount = new Label();
            pictureBox4 = new PictureBox();
            label9 = new Label();
            panel4 = new Panel();
            lblTotalBookingsTodayCount = new Label();
            pictureBox3 = new PictureBox();
            label8 = new Label();
            panel3 = new Panel();
            label7 = new Label();
            lblUpcomingReservationsCount = new Label();
            label5 = new Label();
            pictureBox2 = new PictureBox();
            panel2 = new Panel();
            label4 = new Label();
            lblActiveEventsCount = new Label();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            panel6 = new Panel();
            groupBox2 = new GroupBox();
            btnNewReservation = new Button();
            btnCheckAvailability = new Button();
            btnAddEvent = new Button();
            btnGenerateReport = new Button();
            groupBox1 = new GroupBox();
            dgvDashboardEvents = new DataGridView();
            btnSearch = new Button();
            txtSearch = new TextBox();
            panel1.SuspendLayout();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel6.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDashboardEvents).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(224, 224, 224);
            panel1.Controls.Add(panel5);
            panel1.Controls.Add(panel4);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(820, 187);
            panel1.TabIndex = 0;
            // 
            // panel5
            // 
            panel5.BackColor = Color.White;
            panel5.Controls.Add(label12);
            panel5.Controls.Add(lblVenuesAvailableCount);
            panel5.Controls.Add(pictureBox4);
            panel5.Controls.Add(label9);
            panel5.Location = new Point(624, 45);
            panel5.Name = "panel5";
            panel5.Size = new Size(179, 117);
            panel5.TabIndex = 2;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label12.Location = new Point(73, 87);
            label12.Name = "label12";
            label12.Size = new Size(58, 17);
            label12.TabIndex = 3;
            label12.Text = "Out of 8";
            // 
            // lblVenuesAvailableCount
            // 
            lblVenuesAvailableCount.AutoSize = true;
            lblVenuesAvailableCount.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblVenuesAvailableCount.Location = new Point(73, 43);
            lblVenuesAvailableCount.Name = "lblVenuesAvailableCount";
            lblVenuesAvailableCount.Size = new Size(33, 37);
            lblVenuesAvailableCount.TabIndex = 4;
            lblVenuesAvailableCount.Text = "0";
            // 
            // pictureBox4
            // 
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(12, 43);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(55, 54);
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.TabIndex = 4;
            pictureBox4.TabStop = false;
            pictureBox4.Click += pictureBox4_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label9.Location = new Point(3, 9);
            label9.Name = "label9";
            label9.Size = new Size(128, 20);
            label9.TabIndex = 2;
            label9.Text = "Venues Available";
            // 
            // panel4
            // 
            panel4.BackColor = Color.White;
            panel4.Controls.Add(lblTotalBookingsTodayCount);
            panel4.Controls.Add(pictureBox3);
            panel4.Controls.Add(label8);
            panel4.Location = new Point(419, 45);
            panel4.Name = "panel4";
            panel4.Size = new Size(174, 117);
            panel4.TabIndex = 2;
            // 
            // lblTotalBookingsTodayCount
            // 
            lblTotalBookingsTodayCount.AutoSize = true;
            lblTotalBookingsTodayCount.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalBookingsTodayCount.Location = new Point(80, 43);
            lblTotalBookingsTodayCount.Name = "lblTotalBookingsTodayCount";
            lblTotalBookingsTodayCount.Size = new Size(33, 37);
            lblTotalBookingsTodayCount.TabIndex = 3;
            lblTotalBookingsTodayCount.Text = "0";
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(3, 43);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(61, 54);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 2;
            pictureBox3.TabStop = false;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label8.Location = new Point(3, 9);
            label8.Name = "label8";
            label8.Size = new Size(154, 20);
            label8.TabIndex = 2;
            label8.Text = "Total Bookings Today";
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.Controls.Add(label7);
            panel3.Controls.Add(lblUpcomingReservationsCount);
            panel3.Controls.Add(label5);
            panel3.Controls.Add(pictureBox2);
            panel3.Location = new Point(221, 45);
            panel3.Name = "panel3";
            panel3.Size = new Size(174, 117);
            panel3.TabIndex = 2;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(74, 87);
            label7.Name = "label7";
            label7.Size = new Size(75, 17);
            label7.TabIndex = 2;
            label7.Text = "this Month";
            // 
            // lblUpcomingReservationsCount
            // 
            lblUpcomingReservationsCount.AutoSize = true;
            lblUpcomingReservationsCount.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUpcomingReservationsCount.Location = new Point(74, 43);
            lblUpcomingReservationsCount.Name = "lblUpcomingReservationsCount";
            lblUpcomingReservationsCount.Size = new Size(33, 37);
            lblUpcomingReservationsCount.TabIndex = 2;
            lblUpcomingReservationsCount.Text = "0";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label5.Location = new Point(3, 9);
            label5.Name = "label5";
            label5.Size = new Size(169, 20);
            label5.TabIndex = 2;
            label5.Text = "Upcoming Reservations";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(-10, 22);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(88, 95);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 2;
            pictureBox2.TabStop = false;
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(label4);
            panel2.Controls.Add(lblActiveEventsCount);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(pictureBox1);
            panel2.Location = new Point(20, 45);
            panel2.Name = "panel2";
            panel2.Size = new Size(174, 117);
            panel2.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(75, 87);
            label4.Name = "label4";
            label4.Size = new Size(82, 17);
            label4.TabIndex = 1;
            label4.Text = "Last 30 days";
            // 
            // lblActiveEventsCount
            // 
            lblActiveEventsCount.AutoSize = true;
            lblActiveEventsCount.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblActiveEventsCount.Location = new Point(75, 43);
            lblActiveEventsCount.Name = "lblActiveEventsCount";
            lblActiveEventsCount.Size = new Size(33, 37);
            lblActiveEventsCount.TabIndex = 1;
            lblActiveEventsCount.Text = "0";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.Location = new Point(9, 9);
            label2.Name = "label2";
            label2.Size = new Size(99, 20);
            label2.TabIndex = 1;
            label2.Text = "Active Events";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(3, 32);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(66, 72);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(224, 224, 224);
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(217, 30);
            label1.TabIndex = 0;
            label1.Text = "Dashboard Overview";
            // 
            // panel6
            // 
            panel6.Controls.Add(groupBox2);
            panel6.Controls.Add(groupBox1);
            panel6.Dock = DockStyle.Fill;
            panel6.Location = new Point(0, 187);
            panel6.Name = "panel6";
            panel6.Size = new Size(820, 400);
            panel6.TabIndex = 1;
            panel6.Paint += panel6_Paint;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnNewReservation);
            groupBox2.Controls.Add(btnCheckAvailability);
            groupBox2.Controls.Add(btnAddEvent);
            groupBox2.Controls.Add(btnGenerateReport);
            groupBox2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox2.Location = new Point(601, 6);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(216, 258);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Quick Actions";
            // 
            // btnNewReservation
            // 
            btnNewReservation.BackColor = Color.FromArgb(33, 37, 41);
            btnNewReservation.ForeColor = Color.White;
            btnNewReservation.Location = new Point(6, 39);
            btnNewReservation.Name = "btnNewReservation";
            btnNewReservation.Size = new Size(204, 52);
            btnNewReservation.TabIndex = 6;
            btnNewReservation.Text = "NEW RESERVATION";
            btnNewReservation.UseVisualStyleBackColor = false;
            btnNewReservation.Click += btnNewReservation_Click;
            // 
            // btnCheckAvailability
            // 
            btnCheckAvailability.BackColor = Color.FromArgb(33, 37, 41);
            btnCheckAvailability.ForeColor = Color.White;
            btnCheckAvailability.Location = new Point(6, 88);
            btnCheckAvailability.Name = "btnCheckAvailability";
            btnCheckAvailability.Size = new Size(204, 52);
            btnCheckAvailability.TabIndex = 5;
            btnCheckAvailability.Text = "CHECK AVAILABILITY";
            btnCheckAvailability.UseVisualStyleBackColor = false;
            btnCheckAvailability.Click += btnCheckAvailability_Click;
            // 
            // btnAddEvent
            // 
            btnAddEvent.BackColor = Color.FromArgb(33, 37, 41);
            btnAddEvent.ForeColor = Color.White;
            btnAddEvent.Location = new Point(6, 135);
            btnAddEvent.Name = "btnAddEvent";
            btnAddEvent.Size = new Size(204, 52);
            btnAddEvent.TabIndex = 4;
            btnAddEvent.Text = "ADD EVENT";
            btnAddEvent.UseVisualStyleBackColor = false;
            btnAddEvent.Click += btnAddEvent_Click;
            // 
            // btnGenerateReport
            // 
            btnGenerateReport.BackColor = Color.FromArgb(33, 37, 41);
            btnGenerateReport.ForeColor = Color.White;
            btnGenerateReport.Location = new Point(6, 181);
            btnGenerateReport.Name = "btnGenerateReport";
            btnGenerateReport.Size = new Size(204, 52);
            btnGenerateReport.TabIndex = 3;
            btnGenerateReport.Text = "GENERATE REPORT";
            btnGenerateReport.UseVisualStyleBackColor = false;
            btnGenerateReport.Click += btnGenerateReport_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dgvDashboardEvents);
            groupBox1.Controls.Add(btnSearch);
            groupBox1.Controls.Add(txtSearch);
            groupBox1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(3, 6);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(590, 258);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Current and Upcomming Events";
            // 
            // dgvDashboardEvents
            // 
            dgvDashboardEvents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvDashboardEvents.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvDashboardEvents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvDashboardEvents.DefaultCellStyle = dataGridViewCellStyle2;
            dgvDashboardEvents.Dock = DockStyle.Bottom;
            dgvDashboardEvents.Location = new Point(3, 74);
            dgvDashboardEvents.Name = "dgvDashboardEvents";
            dgvDashboardEvents.RowHeadersVisible = false;
            dgvDashboardEvents.Size = new Size(584, 181);
            dgvDashboardEvents.TabIndex = 2;
            // 
            // btnSearch
            // 
            btnSearch.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSearch.Location = new Point(373, 28);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(75, 21);
            btnSearch.TabIndex = 1;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            // 
            // txtSearch
            // 
            txtSearch.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSearch.Location = new Point(6, 28);
            txtSearch.Multiline = true;
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(361, 21);
            txtSearch.TabIndex = 0;
            // 
            // ucDashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel6);
            Controls.Add(panel1);
            Name = "ucDashboard";
            Size = new Size(820, 587);
            Click += ucDashboard_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel6.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDashboardEvents).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Panel panel2;
        private Panel panel5;
        private Panel panel4;
        private Panel panel3;
        private PictureBox pictureBox1;
        private Label label2;
        private Label lblActiveEventsCount;
        private Label label4;
        private PictureBox pictureBox2;
        private Label label5;
        private Label label7;
        private Label lblUpcomingReservationsCount;
        private Label label8;
        private Label label9;
        private PictureBox pictureBox3;
        private Label lblTotalBookingsTodayCount;
        private PictureBox pictureBox4;
        private Label label12;
        private Label lblVenuesAvailableCount;
        private Panel panel6;
        private GroupBox groupBox2;
        private GroupBox groupBox1;
        private DataGridView dgvDashboardEvents;
        private Button btnSearch;
        private TextBox txtSearch;
        private Button btnNewReservation;
        private Button btnCheckAvailability;
        private Button btnAddEvent;
        private Button btnGenerateReport;
    }
}
