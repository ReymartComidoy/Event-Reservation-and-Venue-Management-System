namespace Event_Reservation_and_Venue_Management_System.Controls
{
    partial class ucClients
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
            cmbTypeFilter = new ComboBox();
            btnAddNewClient = new Button();
            dgvClients = new DataGridView();
            groupBox1 = new GroupBox();
            btnDelete = new Button();
            btnCancel = new Button();
            btnSave = new Button();
            cmbStatus = new ComboBox();
            cmbClientType = new ComboBox();
            txtPhone = new TextBox();
            txtCompany = new TextBox();
            txtEmail = new TextBox();
            txtFullName = new TextBox();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvClients).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.Control;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(206, 30);
            label1.TabIndex = 4;
            label1.Text = "Client Management";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(3, 33);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(262, 23);
            txtSearch.TabIndex = 5;
            txtSearch.Text = "Search Reservations...";
            // 
            // cmbTypeFilter
            // 
            cmbTypeFilter.FormattingEnabled = true;
            cmbTypeFilter.Location = new Point(271, 33);
            cmbTypeFilter.Name = "cmbTypeFilter";
            cmbTypeFilter.Size = new Size(156, 23);
            cmbTypeFilter.TabIndex = 6;
            // 
            // btnAddNewClient
            // 
            btnAddNewClient.BackColor = Color.FromArgb(33, 37, 41);
            btnAddNewClient.ForeColor = SystemColors.Control;
            btnAddNewClient.Location = new Point(433, 29);
            btnAddNewClient.Name = "btnAddNewClient";
            btnAddNewClient.Size = new Size(123, 29);
            btnAddNewClient.TabIndex = 7;
            btnAddNewClient.Text = "+ Add New Client";
            btnAddNewClient.UseVisualStyleBackColor = false;
            btnAddNewClient.Click += btnAddClient_Click;
            // 
            // dgvClients
            // 
            dgvClients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvClients.BackgroundColor = Color.Gray;
            dgvClients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClients.Location = new Point(3, 62);
            dgvClients.Name = "dgvClients";
            dgvClients.Size = new Size(827, 346);
            dgvClients.TabIndex = 8;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnDelete);
            groupBox1.Controls.Add(btnCancel);
            groupBox1.Controls.Add(btnSave);
            groupBox1.Controls.Add(cmbStatus);
            groupBox1.Controls.Add(cmbClientType);
            groupBox1.Controls.Add(txtPhone);
            groupBox1.Controls.Add(txtCompany);
            groupBox1.Controls.Add(txtEmail);
            groupBox1.Controls.Add(txtFullName);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(3, 316);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(727, 215);
            groupBox1.TabIndex = 9;
            groupBox1.TabStop = false;
            groupBox1.Text = "Client Details";
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(33, 37, 41);
            btnDelete.ForeColor = SystemColors.Control;
            btnDelete.Location = new Point(278, 159);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(122, 29);
            btnDelete.TabIndex = 18;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(33, 37, 41);
            btnCancel.ForeColor = SystemColors.Control;
            btnCancel.Location = new Point(150, 159);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(122, 29);
            btnCancel.TabIndex = 17;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(33, 37, 41);
            btnSave.ForeColor = SystemColors.Control;
            btnSave.Location = new Point(17, 159);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(122, 29);
            btnSave.TabIndex = 16;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // cmbStatus
            // 
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Location = new Point(475, 114);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(217, 23);
            cmbStatus.TabIndex = 11;
            // 
            // cmbClientType
            // 
            cmbClientType.FormattingEnabled = true;
            cmbClientType.Location = new Point(475, 79);
            cmbClientType.Name = "cmbClientType";
            cmbClientType.Size = new Size(217, 23);
            cmbClientType.TabIndex = 10;
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(475, 41);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(217, 25);
            txtPhone.TabIndex = 9;
            // 
            // txtCompany
            // 
            txtCompany.Location = new Point(124, 117);
            txtCompany.Name = "txtCompany";
            txtCompany.Size = new Size(217, 25);
            txtCompany.TabIndex = 8;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(124, 79);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(217, 25);
            txtEmail.TabIndex = 7;
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(124, 41);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(217, 25);
            txtFullName.TabIndex = 6;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(413, 117);
            label7.Name = "label7";
            label7.Size = new Size(49, 17);
            label7.TabIndex = 5;
            label7.Text = "Status:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(386, 82);
            label6.Name = "label6";
            label6.Size = new Size(77, 17);
            label6.TabIndex = 4;
            label6.Text = "Client Type:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(364, 44);
            label5.Name = "label5";
            label5.Size = new Size(105, 17);
            label5.TabIndex = 3;
            label5.Text = "Phone Number:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(8, 117);
            label4.Name = "label4";
            label4.Size = new Size(109, 17);
            label4.TabIndex = 2;
            label4.Text = "Company Name:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(21, 82);
            label3.Name = "label3";
            label3.Size = new Size(96, 17);
            label3.TabIndex = 1;
            label3.Text = "Email Address:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(41, 44);
            label2.Name = "label2";
            label2.Size = new Size(72, 17);
            label2.TabIndex = 0;
            label2.Text = "Full Name:";
            // 
            // ucClients
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dgvClients);
            Controls.Add(btnAddNewClient);
            Controls.Add(cmbTypeFilter);
            Controls.Add(txtSearch);
            Controls.Add(label1);
            Name = "ucClients";
            Size = new Size(830, 586);
            Load += ucClients_Load;
            ((System.ComponentModel.ISupportInitialize)dgvClients).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtSearch;
        private ComboBox cmbTypeFilter;
        private Button btnAddNewClient;
        private DataGridView dgvClients;
        private GroupBox groupBox1;
        private TextBox txtEmail;
        private TextBox txtFullName;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private TextBox txtCompany;
        private ComboBox cmbStatus;
        private ComboBox cmbClientType;
        private TextBox txtPhone;
        private Button btnDelete;
        private Button btnCancel;
        private Button btnSave;
    }
}
