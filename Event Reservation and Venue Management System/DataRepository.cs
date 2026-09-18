using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Reservation_and_Venue_Management_System
{
    public static class DataRepository
    {
        public static DataTable EventsTable { get; private set; }
        public static DataTable VenuesTable { get; private set; }
        public static DataTable ReservationsTable { get; private set; }
        public static DataTable ClientsTable { get; private set; }

        static DataRepository()
        {
            InitializeEvents();
            InitializeVenues();
            InitializeReservations();
            InitializeClients();
        }

        private static void InitializeEvents()
        {
            EventsTable = new DataTable();
            EventsTable.Columns.Add("Event Name", typeof(string));
            EventsTable.Columns.Add("Venue", typeof(string));
            EventsTable.Columns.Add("Date", typeof(string));
            EventsTable.Columns.Add("Time", typeof(string));
            EventsTable.Columns.Add("Status", typeof(string));
            EventsTable.Columns.Add("Bookings", typeof(int));

            EventsTable.Rows.Add("Annual Tech Summit", "Grand Ballroom", "2026-10-15", "09:00 AM", "Upcoming", 120);
            EventsTable.Rows.Add("Corporate Gala", "Auditorium", "2026-11-02", "06:00 PM", "Upcoming", 85);
            EventsTable.Rows.Add("Product Launch", "Garden Terrace", "2026-09-01", "02:00 PM", "Completed", 45);
            EventsTable.Rows.Add("Executive Meeting", "Executive Boardroom", "2026-09-10", "10:00 AM", "Completed", 15);
            EventsTable.Rows.Add("Wedding Reception", "Outdoor Pavilion", "2026-12-05", "05:00 PM", "Upcoming", 150);
        }

        private static void InitializeVenues()
        {
            VenuesTable = new DataTable();
            VenuesTable.Columns.Add("Venue Name", typeof(string));
            VenuesTable.Columns.Add("Capacity", typeof(int));
            VenuesTable.Columns.Add("Hourly Rate", typeof(string));
            VenuesTable.Columns.Add("Status", typeof(string));

            VenuesTable.Rows.Add("Grand Ballroom", 300, "$30.00", "Available");
            VenuesTable.Rows.Add("Auditorium", 200, "$35.00", "Available");
            VenuesTable.Rows.Add("Garden Terrace", 100, "$45.00", "Booked");
            VenuesTable.Rows.Add("Executive Boardroom", 20, "$50.00", "Available");
            VenuesTable.Rows.Add("Outdoor Pavilion", 250, "$30.00", "Maintenance");
        }

        private static void InitializeReservations()
        {
            ReservationsTable = new DataTable();
            ReservationsTable.Columns.Add("Reservation ID", typeof(string));
            ReservationsTable.Columns.Add("Client Name", typeof(string));
            ReservationsTable.Columns.Add("Event Name", typeof(string));
            ReservationsTable.Columns.Add("Venue", typeof(string));
            ReservationsTable.Columns.Add("Date", typeof(string));
            ReservationsTable.Columns.Add("Status", typeof(string));

            ReservationsTable.Rows.Add("RES-001", "John Doe", "Annual Tech Summit", "Grand Ballroom", "2026-10-15", "Confirmed");
            ReservationsTable.Rows.Add("RES-002", "Jane Smith", "Corporate Gala", "Auditorium", "2026-11-02", "Pending");
        }

        private static void InitializeClients()
        {
            ClientsTable = new DataTable();
            ClientsTable.Columns.Add("Client ID", typeof(string));
            ClientsTable.Columns.Add("Client Name", typeof(string));
            ClientsTable.Columns.Add("Email Address", typeof(string));
            ClientsTable.Columns.Add("Phone Number", typeof(string));
            ClientsTable.Columns.Add("Company Name", typeof(string));
            ClientsTable.Columns.Add("Client Type", typeof(string));
            ClientsTable.Columns.Add("Status", typeof(string));

            ClientsTable.Rows.Add("CLT-1001", "Alice Smith", "alice@techcorp.com", "(555) 019-2831", "TechCorp Inc.", "Corporate", "Active");
            ClientsTable.Rows.Add("CLT-1002", "Bob Johnson", "b.johnson@gmail.com", "(555) 014-4920", "N/A", "Individual", "Active");
            ClientsTable.Rows.Add("CLT-1003", "Carol White", "cwhite@innovatex.io", "(555) 018-3319", "InnovateX", "Corporate", "Inactive");
            ClientsTable.Rows.Add("CLT-1004", "David Lee", "david.lee@outlook.com", "(555) 012-7743", "Board Inc.", "Individual", "Active");
        }
    }
}
