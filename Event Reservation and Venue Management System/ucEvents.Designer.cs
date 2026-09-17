namespace Event_Reservation_and_Venue_Management_System
{
    partial class ucEvents
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
            label1 = new Label();
            txtSearch = new TextBox();
            cmbVenueFilter = new ComboBox();
            btnAddEvent = new Button();
            dgvEvents = new DataGridView();
            groupBox1 = new GroupBox();
            btnDelete = new Button();
            btnCancel = new Button();
            btnSave = new Button();
            txtDescription = new TextBox();
            label5 = new Label();
            label4 = new Label();
            dtpEventDate = new DateTimePicker();
            cmbVenue = new ComboBox();
            label3 = new Label();
            txtEventName = new TextBox();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvEvents).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.Control;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(203, 30);
            label1.TabIndex = 1;
            label1.Text = "Event Management";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(16, 33);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(262, 23);
            txtSearch.TabIndex = 2;
            txtSearch.Text = "Search Events...";
            // 
            // cmbVenueFilter
            // 
            cmbVenueFilter.FormattingEnabled = true;
            cmbVenueFilter.Items.AddRange(new object[] { "All Venues" });
            cmbVenueFilter.Location = new Point(284, 33);
            cmbVenueFilter.Name = "cmbVenueFilter";
            cmbVenueFilter.Size = new Size(121, 23);
            cmbVenueFilter.TabIndex = 3;
            // 
            // btnAddEvent
            // 
            btnAddEvent.BackColor = Color.FromArgb(33, 37, 41);
            btnAddEvent.ForeColor = SystemColors.Control;
            btnAddEvent.Location = new Point(411, 27);
            btnAddEvent.Name = "btnAddEvent";
            btnAddEvent.Size = new Size(122, 29);
            btnAddEvent.TabIndex = 4;
            btnAddEvent.Text = "+ Add New Event";
            btnAddEvent.UseVisualStyleBackColor = false;
            btnAddEvent.Click += btnAddNewEvent_Click;
            // 
            // dgvEvents
            // 
            dgvEvents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEvents.Location = new Point(16, 62);
            dgvEvents.Name = "dgvEvents";
            dgvEvents.Size = new Size(744, 245);
            dgvEvents.TabIndex = 5;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnDelete);
            groupBox1.Controls.Add(btnCancel);
            groupBox1.Controls.Add(btnSave);
            groupBox1.Controls.Add(txtDescription);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(dtpEventDate);
            groupBox1.Controls.Add(cmbVenue);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(txtEventName);
            groupBox1.Controls.Add(label2);
            groupBox1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(16, 313);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(744, 198);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "Event Details";
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(33, 37, 41);
            btnDelete.ForeColor = SystemColors.Control;
            btnDelete.Location = new Point(345, 116);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(122, 29);
            btnDelete.TabIndex = 13;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(33, 37, 41);
            btnCancel.ForeColor = SystemColors.Control;
            btnCancel.Location = new Point(218, 116);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(122, 29);
            btnCancel.TabIndex = 9;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(33, 37, 41);
            btnSave.ForeColor = SystemColors.Control;
            btnSave.Location = new Point(90, 116);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(122, 29);
            btnSave.TabIndex = 8;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // txtDescription
            // 
            txtDescription.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtDescription.Location = new Point(473, 67);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(253, 78);
            txtDescription.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(473, 38);
            label5.Name = "label5";
            label5.Size = new Size(77, 17);
            label5.TabIndex = 6;
            label5.Text = "Description:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(255, 77);
            label4.Name = "label4";
            label4.Size = new Size(38, 17);
            label4.TabIndex = 5;
            label4.Text = "Date:";
            // 
            // dtpEventDate
            // 
            dtpEventDate.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpEventDate.Location = new Point(299, 69);
            dtpEventDate.Name = "dtpEventDate";
            dtpEventDate.Size = new Size(159, 25);
            dtpEventDate.TabIndex = 4;
            // 
            // cmbVenue
            // 
            cmbVenue.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbVenue.FormattingEnabled = true;
            cmbVenue.Location = new Point(90, 69);
            cmbVenue.Name = "cmbVenue";
            cmbVenue.Size = new Size(159, 25);
            cmbVenue.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(41, 75);
            label3.Name = "label3";
            label3.Size = new Size(43, 17);
            label3.TabIndex = 2;
            label3.Text = "Venue";
            // 
            // txtEventName
            // 
            txtEventName.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtEventName.Location = new Point(90, 30);
            txtEventName.Name = "txtEventName";
            txtEventName.Size = new Size(368, 25);
            txtEventName.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(6, 36);
            label2.Name = "label2";
            label2.Size = new Size(78, 17);
            label2.TabIndex = 0;
            label2.Text = "Event Name";
            // 
            // ucEvents
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBox1);
            Controls.Add(dgvEvents);
            Controls.Add(btnAddEvent);
            Controls.Add(cmbVenueFilter);
            Controls.Add(txtSearch);
            Controls.Add(label1);
            Name = "ucEvents";
            Size = new Size(783, 541);
            Click += ucEvents_Load;
            ((System.ComponentModel.ISupportInitialize)dgvEvents).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtSearch;
        private ComboBox cmbVenueFilter;
        private Button btnAddEvent;
        private DataGridView dgvEvents;
        private GroupBox groupBox1;
        private ComboBox cmbVenue;
        private Label label3;
        private TextBox txtEventName;
        private Label label2;
        private TextBox txtDescription;
        private Label label5;
        private Label label4;
        private DateTimePicker dtpEventDate;
        private Button btnCancel;
        private Button btnSave;
        private Button btnDelete;
    }
}
