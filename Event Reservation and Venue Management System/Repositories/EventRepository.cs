using Event_Reservation_and_Venue_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Reservation_and_Venue_Management_System.Repositories
{
    public class EventRepository : IRepository<EventModel>
    {
        public DataTable GetDataTable() => DataRepository.EventsTable;

        public void Add(EventModel evt)
        {
            DataRepository.EventsTable.Rows.Add(
                evt.EventName,
                evt.Venue,
                evt.Date,
                evt.Time,
                evt.Status,
                evt.Bookings
            );
        }

        public void Update(int rowIndex, EventModel evt)
        {
            if (rowIndex >= 0 && rowIndex < DataRepository.EventsTable.Rows.Count)
            {
                DataRow row = DataRepository.EventsTable.Rows[rowIndex];
                row["Event Name"] = evt.EventName;
                row["Venue"] = evt.Venue;
                row["Date"] = evt.Date;
                row["Time"] = evt.Time;
                row["Status"] = evt.Status;
                row["Bookings"] = evt.Bookings;
            }
        }

        public void Delete(int rowIndex)
        {
            if (rowIndex >= 0 && rowIndex < DataRepository.EventsTable.Rows.Count)
            {
                DataRepository.EventsTable.Rows.RemoveAt(rowIndex);
            }
        }
    }
}
