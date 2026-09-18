using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Reservation_and_Venue_Management_System.Models
{
    public class ReservationModel
    {
        public string Client { get; set; } = string.Empty;
        public string Event { get; set; } = string.Empty;
        public string Venue { get; set; } = string.Empty;
        public string Date { get; set; } = string.Empty;
        public decimal TotalAmount { get; set; }
        public string Status { get; set; } = "Pending";

        // Aliases to satisfy ReservationRepository.cs
        public string ClientName
        {
            get => Client;
            set => Client = value;
        }
        public string EventName
        {
            get => Event;
            set => Event = value;
        }
        public string ReservationDate
        {
            get => Date;
            set => Date = value;
        }
    }
}
