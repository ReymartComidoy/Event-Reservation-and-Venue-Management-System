using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Reservation_and_Venue_Management_System.Models
{
    public class EventModel : IEntity
    {
        public string Id { get; set; }
        public string EventName { get; set; }
        public string Venue { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public int Bookings { get; set; }
        public string Status { get; set; }
    }
}
