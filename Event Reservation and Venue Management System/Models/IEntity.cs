using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Reservation_and_Venue_Management_System.Models
{
    public interface IEntity
    {
        string Id { get; set; }
        string Status { get; set; }
    }
}
