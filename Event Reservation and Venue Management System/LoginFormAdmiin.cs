using System;
using System.Drawing;
using System.Text.RegularExpressions;
using Event_Reservation_and_Venue_Management_System.Models;
using Event_Reservation_and_Venue_Management_System.Services;
using System.Windows.Forms;

namespace Event_Reservation_and_Venue_Management_System
{
    public partial class LoginFormAdmiin : Form
    {
        private readonly bool _clientMode;
        private readonly AuthenticationService _authenticationService = new();

        public User? AuthenticatedUser { get; private set; }

        public LoginFormAdmiin()
            : this(false)
        {
        }

        protected LoginFormAdmiin(bool clientMode)
        {
            _clientMode = clientMode;
            InitializeComponent();
            ConfigureLoginMode();
            button2.Click += LoginButton_Click;
            button4.Click += SwitchLoginModeButton_Click;

            Button closeButton = new()
            {
                Text = "×",
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.Transparent,
                ForeColor = Color.DimGray,
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                Size = new Size(32, 28),
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Location = new Point(ClientSize.Width - 40, 8)
            };
            closeButton.FlatAppearance.BorderSize = 0;
            closeButton.Click += (_, _) => Close();
            Controls.Add(closeButton);
            closeButton.BringToFront();
        }

        private void ConfigureLoginMode()
        {
            kryptonLabel1.Values.Text = _clientMode
                ? "Let's get Started on Your Client Account."
                : "Let's get Started on Your Admin Account.";
            button2.Text = "Login";
            button4.Text = _clientMode ? "Login Admin" : "Login Client";
        }

        private void LoginButton_Click(object? sender, EventArgs e)
        {
            string email = button1.Text.Trim();
            string password = button3.Text;

            if (!Regex.IsMatch(email, @"^[^\s@]+@[^\s@]+\.[^\s@]+$"))
            {
                MessageBox.Show("Enter a valid email address containing @ and a domain.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                button1.Focus();
                return;
            }

            if (!Regex.IsMatch(password, @"^(?=.*[A-Z])(?=.*\d)(?=.*[^a-zA-Z0-9]).{8,}$"))
            {
                MessageBox.Show("Password must be at least 8 characters and include one capital letter, one number, and one special character.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                button3.Focus();
                return;
            }

            try
            {
                AuthenticatedUser = _authenticationService.Login(email, password, _clientMode ? "Client" : "Admin");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Database connection failed. Run DbContext\\DatabaseSchema.sql first.\n\n{ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (AuthenticatedUser == null)
            {
                MessageBox.Show("The email or password is incorrect.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void SwitchLoginModeButton_Click(object? sender, EventArgs e)
        {
            if (_clientMode)
            {
                using LoginFormAdmiin adminLogin = new();
                Hide();
                if (adminLogin.ShowDialog() == DialogResult.OK)
                {
                    AuthenticatedUser = adminLogin.AuthenticatedUser;
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    Show();
                }
                return;
            }

            using ClientLoginForm clientLogin = new();
            Hide();
            if (clientLogin.ShowDialog() == DialogResult.OK)
            {
                AuthenticatedUser = clientLogin.AuthenticatedUser;
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }

    public sealed class ClientLoginForm : LoginFormAdmiin
    {
        public ClientLoginForm()
            : base(true)
        {
        }
    }
}
