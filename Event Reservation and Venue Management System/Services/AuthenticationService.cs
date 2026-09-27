using Event_Reservation_and_Venue_Management_System.DbContext;
using Event_Reservation_and_Venue_Management_System.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Event_Reservation_and_Venue_Management_System.Services
{
    public sealed class AuthenticationService
    {
        public User? Login(string email, string password, string role)
        {
            DataTable table = Database.ExecuteTable(
                "dbo.User_Login",
                new SqlParameter("@Email", SqlDbType.NVarChar, 255) { Value = email },
                new SqlParameter("@PasswordHash", SqlDbType.NVarChar, 128) { Value = PasswordHasher.Hash(password) });

            if (table.Rows.Count == 0)
                return null;

            DataRow row = table.Rows[0];
            if (!string.Equals(row["Role"].ToString(), role, StringComparison.OrdinalIgnoreCase))
                return null;

            return new User
            {
                Id = Convert.ToInt32(row["Id"]),
                Username = row["Username"].ToString() ?? email,
                FullName = row["FullName"].ToString() ?? string.Empty,
                Role = row["Role"].ToString() ?? role
            };
        }
    }
}
