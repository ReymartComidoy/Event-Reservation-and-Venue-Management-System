using Event_Reservation_and_Venue_Management_System.DbContext;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Event_Reservation_and_Venue_Management_System.Services
{
    public sealed class ClientService
    {
        public DataTable GetAll() => Database.ExecuteTable("dbo.Client_GetAll");

        public void Create(string email, string password, string fullName)
        {
            Database.ExecuteNonQuery(
                "dbo.Client_Create",
                new SqlParameter("@Email", SqlDbType.NVarChar, 255) { Value = email },
                new SqlParameter("@PasswordHash", SqlDbType.NVarChar, 128) { Value = PasswordHasher.Hash(password) },
                new SqlParameter("@FullName", SqlDbType.NVarChar, 150) { Value = fullName });
        }

        public void Update(int id, string fullName, string email, bool isActive)
        {
            Database.ExecuteNonQuery(
                "dbo.Client_Update",
                new SqlParameter("@Id", id),
                new SqlParameter("@FullName", SqlDbType.NVarChar, 150) { Value = fullName },
                new SqlParameter("@Email", SqlDbType.NVarChar, 255) { Value = email },
                new SqlParameter("@IsActive", isActive));
        }

        public void Delete(int id) => Database.ExecuteNonQuery("dbo.Client_Delete", new SqlParameter("@Id", id));
    }
}
