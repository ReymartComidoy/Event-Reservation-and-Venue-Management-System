using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Reservation_and_Venue_Management_System.Services
{
    public enum ViewModule
    {
        Dashboard,
        Events,
        Venues,
        Reservations,
        Clients
    }

    public interface INavigationService
    {
        void NavigateTo(ViewModule module);
    }
}
