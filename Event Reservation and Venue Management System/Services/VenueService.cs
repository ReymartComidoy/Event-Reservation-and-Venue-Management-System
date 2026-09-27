using Event_Reservation_and_Venue_Management_System.DbContext;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Event_Reservation_and_Venue_Management_System.Services
{
    public sealed class VenueService
    {
        public DataTable GetAll() => Database.ExecuteTable("dbo.Venue_GetAll");

        public void Save(int id, string name, string type, int capacity, string location, decimal hourlyRate, string status, string? imagePath, int? createdBy)
        {
            Database.ExecuteNonQuery(
                "dbo.Venue_Save",
                new SqlParameter("@Id", SqlDbType.Int) { Value = id == 0 ? DBNull.Value : id },
                new SqlParameter("@VenueName", SqlDbType.NVarChar, 150) { Value = name },
                new SqlParameter("@VenueType", SqlDbType.NVarChar, 50) { Value = type },
                new SqlParameter("@Capacity", SqlDbType.Int) { Value = capacity },
                new SqlParameter("@Location", SqlDbType.NVarChar, 250) { Value = location },
                new SqlParameter("@PricePerHour", SqlDbType.Decimal) { Precision = 18, Scale = 2, Value = hourlyRate },
                new SqlParameter("@Status", SqlDbType.NVarChar, 30) { Value = status },
                new SqlParameter("@ImagePath", SqlDbType.NVarChar, 500) { Value = (object?)imagePath ?? DBNull.Value },
                new SqlParameter("@CreatedBy", SqlDbType.Int) { Value = (object?)createdBy ?? DBNull.Value });
        }

        public void Delete(int id) => Database.ExecuteNonQuery("dbo.Venue_Delete", new SqlParameter("@Id", id));
    }
}
