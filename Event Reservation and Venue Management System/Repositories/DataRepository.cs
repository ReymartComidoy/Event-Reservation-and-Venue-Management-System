using System.Data;

namespace Event_Reservation_and_Venue_Management_System.Repositories
{
    public static class DataRepository
    {
        public static DataTable EventsTable { get; private set; }
        public static DataTable ClientsTable { get; private set; }
        public static DataTable VenuesTable { get; private set; }
        public static DataTable ReservationsTable { get; private set; }

        static DataRepository()
        {
            InitializeEventsTable();
            InitializeClientsTable();
            InitializeVenuesTable();
            InitializeReservationsTable();
        }

        private static void InitializeEventsTable()
        {
            EventsTable = new DataTable("Events");
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

        private static void InitializeClientsTable()
        {
            ClientsTable = new DataTable("Clients");
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

        private static void InitializeVenuesTable()
        {
            VenuesTable = new DataTable("Venues");
            VenuesTable.Columns.Add("Venue Name", typeof(string));
            VenuesTable.Columns.Add("Capacity", typeof(int));
            VenuesTable.Columns.Add("Location", typeof(string));
            VenuesTable.Columns.Add("Price Per Hour", typeof(decimal));
            VenuesTable.Columns.Add("Status", typeof(string));

            VenuesTable.Rows.Add("Grand Ballroom", 500, "Main Building - 2nd Floor", 250.00m, "Available");
            VenuesTable.Rows.Add("Auditorium", 300, "East Wing - 1st Floor", 180.00m, "Available");
            VenuesTable.Rows.Add("Garden Terrace", 150, "Outdoor Area North", 120.00m, "Available");
            VenuesTable.Rows.Add("Executive Boardroom", 25, "Main Building - 3rd Floor", 75.00m, "Available");
            VenuesTable.Rows.Add("Outdoor Pavilion", 200, "Outdoor Area South", 150.00m, "Available");
        }

        private static void InitializeReservationsTable()
        {
            ReservationsTable = new DataTable("Reservations");
            ReservationsTable.Columns.Add("Reservation ID", typeof(string));
            ReservationsTable.Columns.Add("Client Name", typeof(string));
            ReservationsTable.Columns.Add("Event Name", typeof(string));
            ReservationsTable.Columns.Add("Venue", typeof(string));
            ReservationsTable.Columns.Add("Reservation Date", typeof(string));
            ReservationsTable.Columns.Add("Status", typeof(string));

            ReservationsTable.Rows.Add("RES-2001", "Alice Smith", "Annual Tech Summit", "Grand Ballroom", "2026-10-15", "Confirmed");
            ReservationsTable.Rows.Add("RES-2002", "Carol White", "Corporate Gala", "Auditorium", "2026-11-02", "Pending");
            ReservationsTable.Rows.Add("RES-2003", "Bob Johnson", "Product Launch", "Garden Terrace", "2026-09-01", "Completed");
        }
    }
}