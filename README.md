Event Reservation and Venue Management System
A desktop management software built with C# and Windows Forms (.NET 8.0) designed for venue operators and event planners to streamline client registrations, venue bookings, event scheduling, and reservations.

Features
Dashboard Overview: Real-time system metrics (Active Events, Upcoming Reservations, Total Bookings, Venue Availability) and live search capabilities across current schedule records.

Event Management: Full CRUD (Create, Read, Update, Delete) operations for tracking events, scheduling dates, assigning venues, and monitoring attendance numbers.

Reservation System: Interconnected booking workflow linking registered clients, available venues, and scheduled events with status tracking (Confirmed, Pending, Completed).

Venue Management: Interface for managing venue capacities, location details, hourly pricing rates, and availability statuses.

Client Directory: Customer Relationship Management (CRM) tab to store client contact information, company details, client classification (Corporate vs. Individual), and account status.

Report Generation: Built-in tool to export system schedules and metrics into CSV spreadsheets.

System Architecture & Design Patterns
This project follows software design principles to ensure scalability and ease of database integration:

Event-Reservation-and-Venue-Management-System/
│
├── Controls/               # UI Layer (User Controls)
│   ├── ucDashboard.cs
│   ├── ucEvents.cs
│   ├── ucReservations.cs
│   ├── ucVenue.cs
│   └── ucClients.cs
│
├── Models/                 # Domain Model Layer
│   ├── IEntity.cs          # Base contract for primary keys and status fields
│   ├── ClientModel.cs
│   ├── EventModel.cs
│   ├── ReservationModel.cs
│   └── VenueModel.cs
│
├── Repositories/           # Data Access Layer
│   ├── IRepository.cs      # Generic CRUD repository interface
│   ├── DataRepository.cs   # In-Memory Data Store (or MySQL Connection Manager)
│   ├── ClientRepository.cs
│   ├── EventRepository.cs
│   ├── ReservationRepository.cs
│   └── VenueRepository.cs
│
└── Services/               # Application Business Logic & Helpers
    ├── INavigationService.cs
    └── NavigationService.cs
Architectural Highlights
Repository Pattern (IRepository<T>): Standardizes data access methods across all entities (GetDataTable, Add, Update, Delete), abstracting the user interface away from the underlying storage mechanism.

Interface Abstraction (IEntity): Enforces consistency across data models by ensuring all entities implement common tracking fields (Id and Status).

Decoupled User Controls: Navigation between tabs is handled dynamically via a custom INavigationService, eliminating UI lag and messy form transitions.

Technologies Used
Language: C#

Framework: .NET 8.0 Windows Desktop Application (WinForms)

Data Storage: In-Memory DataTable collection (Ready for MySQL integration)

IDE: Microsoft Visual Studio 2022

Getting Started
Prerequisites
Visual Studio 2022 with the .NET Desktop Development workload installed.

.NET 8.0 SDK or higher.

Installation & Execution
Clone the Repository:

Bash
git clone https://github.com/ReymartComidoy/Event-Reservation-and-Venue-Management-System.git
Open the Project:

Double-click Event Reservation and Venue Management System.sln to open it in Visual Studio.

Build the Solution:

Press Ctrl + Shift + B or navigate to Build > Rebuild Solution in the top menu.

Run the Application:

Press F5 or click the green Start button to run the application.

Future Roadmap / Planned Upgrades
[ ] Database Integration: Connect DataRepository.cs to a MySQL database using MySql.Data.

[ ] User Authentication: Add login/signup forms with Role-Based Access Control (Admin vs. Staff).

[ ] Advanced Filtering: Add custom date-range filters across reservation and event views.

License
This project was developed for educational and portfolio presentation purposes.
