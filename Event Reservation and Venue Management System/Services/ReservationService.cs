using Event_Reservation_and_Venue_Management_System.DbContext;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Event_Reservation_and_Venue_Management_System.Services
{
    public sealed class ReservationService
    {
        public DataTable GetAll() => Database.ExecuteTable("dbo.Reservation_GetAll");

        public void Save(int clientId, int venueId, string eventTitle, DateTime reservationDate, string timeSlot, int guestCount, string specialRequests, decimal totalFee)
        {
            Database.ExecuteNonQuery(
                "dbo.Reservation_Save",
                new SqlParameter("@ClientId", clientId),
                new SqlParameter("@VenueId", venueId),
                new SqlParameter("@EventTitle", SqlDbType.NVarChar, 200) { Value = eventTitle },
                new SqlParameter("@ReservationDate", SqlDbType.Date) { Value = reservationDate.Date },
                new SqlParameter("@TimeSlot", SqlDbType.NVarChar, 100) { Value = timeSlot },
                new SqlParameter("@GuestCount", guestCount),
                new SqlParameter("@SpecialRequests", SqlDbType.NVarChar, 1000) { Value = (object?)specialRequests ?? DBNull.Value },
                new SqlParameter("@TotalFee", SqlDbType.Decimal) { Precision = 18, Scale = 2, Value = totalFee });
        }
    }
}
