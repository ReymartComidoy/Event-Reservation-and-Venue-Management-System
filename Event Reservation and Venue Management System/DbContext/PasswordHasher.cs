using System.Security.Cryptography;
using System.Text;

namespace Event_Reservation_and_Venue_Management_System.DbContext
{
    public static class PasswordHasher
    {
        public static string Hash(string password)
        {
            byte[] hash = SHA256.HashData(Encoding.UTF8.GetBytes(password));
            return Convert.ToHexString(hash);
        }
    }
}
