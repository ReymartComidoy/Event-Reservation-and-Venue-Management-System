using System;
using System.Data;

namespace Event_Reservation_and_Venue_Management_System.Services
{
    public static class DataRepository
    {
        public static DataTable EventsTable { get; private set; } = new DataTable();
        public static DataTable ReservationsTable { get; private set; } = new DataTable();
        public static DataTable VenuesTable { get; private set; } = new DataTable();
        public static DataTable ClientsTable { get; private set; } = new DataTable();

        static DataRepository()
        {
            InitializeTables();
            SeedData();
        }

        private static void InitializeTables()
        {
            // Clients
            ClientsTable.Columns.Add("ClientID", typeof(string));
            ClientsTable.Columns.Add("ClientName", typeof(string));
            ClientsTable.Columns.Add("Email", typeof(string));
            ClientsTable.Columns.Add("Phone", typeof(string));
            ClientsTable.Columns.Add("Company", typeof(string));
            ClientsTable.Columns.Add("Type", typeof(string));
            ClientsTable.Columns.Add("Status", typeof(string));

            // Venues
            VenuesTable.Columns.Add("VenueName", typeof(string));
            VenuesTable.Columns.Add("Capacity", typeof(int));
            VenuesTable.Columns.Add("Location", typeof(string));
            VenuesTable.Columns.Add("PricePerHour", typeof(decimal));
            VenuesTable.Columns.Add("Status", typeof(string));

            // Events
            EventsTable.Columns.Add("EventID", typeof(int));
            EventsTable.Columns.Add("EventName", typeof(string));
            EventsTable.Columns.Add("Venue", typeof(string));
            EventsTable.Columns.Add("Date", typeof(string));
            EventsTable.Columns.Add("Time", typeof(string));
            EventsTable.Columns.Add("Status", typeof(string));
            EventsTable.Columns.Add("Bookings", typeof(int));

            // Reservations
            ReservationsTable.Columns.Add("ReservationID", typeof(string));
            ReservationsTable.Columns.Add("ClientName", typeof(string));
            ReservationsTable.Columns.Add("EventName", typeof(string));
            ReservationsTable.Columns.Add("Venue", typeof(string));
            ReservationsTable.Columns.Add("ReservationDate", typeof(string));
            ReservationsTable.Columns.Add("TotalAmount", typeof(decimal));
            ReservationsTable.Columns.Add("Status", typeof(string));
        }

        private static void SeedData()
        {
            // Seed Clients
            ClientsTable.Rows.Add("CLT-1001", "Alice Smith", "alice@techcorp.com", "(555) 019-2831", "TechCorp Inc.", "Corporate", "Active");
            ClientsTable.Rows.Add("CLT-1002", "Bob Johnson", "b.johnson@gmail.com", "(555) 014-4920", "N/A", "Individual", "Active");
            ClientsTable.Rows.Add("CLT-1003", "Carol White", "cwhite@innovate.com", "(555) 018-3319", "InnovateX", "Corporate", "Inactive");

            // Seed Venues
            VenuesTable.Rows.Add("Grand Ballroom", 500, "Main Building - 2nd Floor", 250.00m, "Available");
            VenuesTable.Rows.Add("Auditorium", 300, "East Wing - 1st Floor", 180.00m, "Available");
            VenuesTable.Rows.Add("Garden Terrace", 150, "Outdoor Area North", 120.00m, "Available");

            // Seed Events
            EventsTable.Rows.Add(101, "Annual Tech Summit", "Grand Ballroom", "2026-10-15", "09:00 AM", "Upcoming", 120);
            EventsTable.Rows.Add(102, "Corporate Gala", "Auditorium", "2026-11-02", "06:00 PM", "Upcoming", 85);
            EventsTable.Rows.Add(103, "Product Launch", "Garden Terrace", "2026-09-01", "02:00 PM", "Completed", 45);

            // Seed Reservations
            ReservationsTable.Rows.Add("RES-2001", "Alice Smith", "Annual Tech Summit", "Grand Ballroom", "2026-10-15", 1250.00m, "Confirmed");
            ReservationsTable.Rows.Add("RES-2002", "Carol White", "Corporate Gala", "Auditorium", "2026-11-02", 900.00m, "Pending");
            ReservationsTable.Rows.Add("RES-2003", "Bob Johnson", "Product Launch", "Garden Terrace", "2026-09-01", 480.00m, "Completed");
        }
    }
}