namespace Event_Reservation_and_Venue_Management_System
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            using LoginFormAdmiin loginForm = new();
            if (loginForm.ShowDialog() != DialogResult.OK || loginForm.AuthenticatedUser == null)
                return;

            if (string.Equals(loginForm.AuthenticatedUser.Role, "Client", StringComparison.OrdinalIgnoreCase))
            {
                using ClientMainForm clientForm = new();
                clientForm.SetUserSession(loginForm.AuthenticatedUser);
                Application.Run(clientForm);
            }
            else
            {
                Application.Run(new Form1());
            }
        }
    }
}