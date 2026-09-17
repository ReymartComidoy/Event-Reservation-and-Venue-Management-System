namespace Event_Reservation_and_Venue_Management_System
{
    partial class ucVenue
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
            btnAddNewVenue = new Button();
            dgvVenues = new DataGridView();
            groupBox1 = new GroupBox();
            btnCancel = new Button();
            btnSave = new Button();
            cmbStatus = new ComboBox();
            label6 = new Label();
            txtMaintenance = new TextBox();
            label5 = new Label();
            txtHourlyRate = new TextBox();
            numCapacity = new NumericUpDown();
            label4 = new Label();
            label3 = new Label();
            txtVenueName = new TextBox();
            label2 = new Label();
            btnDelete = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvVenues).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numCapacity).BeginInit();
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
            label1.Size = new Size(210, 30);
            label1.TabIndex = 2;
            label1.Text = "Venue Management";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(12, 33);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(262, 23);
            txtSearch.TabIndex = 3;
            // 
            // btnAddNewVenue
            // 
            btnAddNewVenue.BackColor = Color.FromArgb(33, 37, 41);
            btnAddNewVenue.ForeColor = SystemColors.Control;
            btnAddNewVenue.Location = new Point(280, 29);
            btnAddNewVenue.Name = "btnAddNewVenue";
            btnAddNewVenue.Size = new Size(122, 29);
            btnAddNewVenue.TabIndex = 5;
            btnAddNewVenue.Text = "+ Add New Venue";
            btnAddNewVenue.UseVisualStyleBackColor = false;
            btnAddNewVenue.Click += btnAddNewVenue_Click;
            // 
            // dgvVenues
            // 
            dgvVenues.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVenues.Location = new Point(12, 62);
            dgvVenues.Name = "dgvVenues";
            dgvVenues.Size = new Size(699, 246);
            dgvVenues.TabIndex = 6;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnDelete);
            groupBox1.Controls.Add(btnCancel);
            groupBox1.Controls.Add(btnSave);
            groupBox1.Controls.Add(cmbStatus);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(txtMaintenance);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(txtHourlyRate);
            groupBox1.Controls.Add(numCapacity);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(txtVenueName);
            groupBox1.Controls.Add(label2);
            groupBox1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(13, 314);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(698, 211);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "Add / Edit Venue Details";
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(33, 37, 41);
            btnCancel.ForeColor = SystemColors.Control;
            btnCancel.Location = new Point(139, 137);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(122, 29);
            btnCancel.TabIndex = 11;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(33, 37, 41);
            btnSave.ForeColor = SystemColors.Control;
            btnSave.Location = new Point(6, 137);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(122, 29);
            btnSave.TabIndex = 10;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // cmbStatus
            // 
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Location = new Point(353, 102);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(328, 29);
            cmbStatus.TabIndex = 9;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(353, 82);
            label6.Name = "label6";
            label6.Size = new Size(43, 17);
            label6.TabIndex = 8;
            label6.Text = "Status";
            // 
            // txtMaintenance
            // 
            txtMaintenance.Location = new Point(353, 50);
            txtMaintenance.Name = "txtMaintenance";
            txtMaintenance.Size = new Size(328, 29);
            txtMaintenance.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(353, 30);
            label5.Name = "label5";
            label5.Size = new Size(128, 17);
            label5.TabIndex = 6;
            label5.Text = "Maintenance (status)";
            // 
            // txtHourlyRate
            // 
            txtHourlyRate.Location = new Point(165, 102);
            txtHourlyRate.Name = "txtHourlyRate";
            txtHourlyRate.Size = new Size(169, 29);
            txtHourlyRate.TabIndex = 5;
            // 
            // numCapacity
            // 
            numCapacity.Location = new Point(6, 102);
            numCapacity.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numCapacity.Name = "numCapacity";
            numCapacity.Size = new Size(142, 29);
            numCapacity.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(165, 82);
            label4.Name = "label4";
            label4.Size = new Size(76, 17);
            label4.TabIndex = 3;
            label4.Text = "Hourly Rate";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(6, 82);
            label3.Name = "label3";
            label3.Size = new Size(57, 17);
            label3.TabIndex = 2;
            label3.Text = "Capacity";
            // 
            // txtVenueName
            // 
            txtVenueName.Location = new Point(6, 50);
            txtVenueName.Name = "txtVenueName";
            txtVenueName.Size = new Size(328, 29);
            txtVenueName.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(6, 30);
            label2.Name = "label2";
            label2.Size = new Size(82, 17);
            label2.TabIndex = 0;
            label2.Text = "Venue Name";
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(33, 37, 41);
            btnDelete.ForeColor = SystemColors.Control;
            btnDelete.Location = new Point(267, 137);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(122, 29);
            btnDelete.TabIndex = 12;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // ucVenue
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBox1);
            Controls.Add(dgvVenues);
            Controls.Add(btnAddNewVenue);
            Controls.Add(txtSearch);
            Controls.Add(label1);
            Name = "ucVenue";
            Size = new Size(764, 550);
            Load += ucVenue_Load;
            ((System.ComponentModel.ISupportInitialize)dgvVenues).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numCapacity).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtSearch;
        private Button btnAddNewVenue;
        private DataGridView dgvVenues;
        private GroupBox groupBox1;
        private TextBox txtVenueName;
        private Label label2;
        private ComboBox cmbStatus;
        private Label label6;
        private TextBox txtMaintenance;
        private Label label5;
        private TextBox txtHourlyRate;
        private NumericUpDown numCapacity;
        private Label label4;
        private Label label3;
        private Button btnSave;
        private Button btnCancel;
        private Button btnDelete;
    }
}
