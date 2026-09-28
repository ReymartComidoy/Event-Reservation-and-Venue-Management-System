using Event_Reservation_and_Venue_Management_System.DbContext;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Event_Reservation_and_Venue_Management_System.Services
{
    public sealed class EventService
    {
        public DataTable GetAll() => Database.ExecuteTable("dbo.Event_GetAll");

        public void Save(int id, string eventName, int? venueId, DateTime eventDate, TimeSpan? eventTime, int bookings, string status)
        {
            Database.ExecuteNonQuery(
                "dbo.Event_Save",
                new SqlParameter("@Id", SqlDbType.Int) { Value = id == 0 ? DBNull.Value : id },
                new SqlParameter("@EventName", SqlDbType.NVarChar, 200) { Value = eventName },
                new SqlParameter("@VenueId", SqlDbType.Int) { Value = (object?)venueId ?? DBNull.Value },
                new SqlParameter("@EventDate", SqlDbType.Date) { Value = eventDate.Date },
                new SqlParameter("@EventTime", SqlDbType.Time) { Value = (object?)eventTime ?? DBNull.Value },
                new SqlParameter("@Bookings", bookings),
                new SqlParameter("@Status", SqlDbType.NVarChar, 30) { Value = status });
        }

        public void Delete(int id) => Database.ExecuteNonQuery("dbo.Event_Delete", new SqlParameter("@Id", id));
    }
}
