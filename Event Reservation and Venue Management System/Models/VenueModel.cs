using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Reservation_and_Venue_Management_System.Models
{
    public class VenueModel : IEntity
    {
        public string Id { get; set; }
        public string VenueName { get; set; }
        public int Capacity { get; set; }
        public string Location { get; set; }
        public decimal PricePerHour { get; set; }
        public string Status { get; set; }
    }
}
