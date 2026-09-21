# Event Reservation and Venue Management System

A desktop application built using **C#** and **Windows Forms (.NET 8.0)** designed for venue managers and event planners to handle client management, venue bookings, event scheduling, and reservation workflows.

---

## Features

* **Dashboard Overview:** Displays live operational statistics (Active Events, Upcoming Reservations, Total Bookings Today, and Available Venues) along with quick actions and real-time search filtering.
* **Event Management:** Full CRUD (Create, Read, Update, Delete) capability to organize events, set venue assignments, manage event dates, and track expected attendance.
* **Reservation System:** Links registered clients directly with scheduled events and venues, managing overall pricing, reservation dates, and confirmation statuses.
* **Venue Management:** Manages venue records, location details, guest capacities, hourly rental rates, and maintenance availability.
* **Client Management:** Centralized Client Relationship Management (CRM) directory storing customer contact details, company affiliations, client classifications, and account statuses.
* **Report Generation:** Export system schedule data directly into downloadable CSV format for external analysis or auditing.

---

## Project Structure & Architecture

This project strictly adheres to clean architecture principles and the **Repository Pattern** to decouple the UI controls from business logic and data storage layers:

```text
Event-Reservation-and-Venue-Management-System/
│
├── Controls/               # User Controls (UI Layer)
│   ├── ucDashboard.cs      # Summary metrics and quick action hub
│   ├── ucEvents.cs         # Event management screen
│   ├── ucReservations.cs   # Reservation tracking screen
│   ├── ucVenue.cs          # Venue inventory screen
│   └── ucClients.cs        # Client CRM screen
│
├── Models/                 # Domain Model Definitions
│   ├── IEntity.cs          # Base contract enforcing Id and Status fields
│   ├── ClientModel.cs      # Data properties for Clients
│   ├── EventModel.cs       # Data properties for Events
│   ├── ReservationModel.cs # Data properties for Reservations
│   └── VenueModel.cs       # Data properties for Venues
│
├── Repositories/           # Data Access Layer
│   ├── IRepository.cs      # Generic CRUD interface contract
│   ├── DataRepository.cs   # Centralized data store / Database Connection Manager
│   ├── ClientRepository.cs # Data persistence for Clients
│   ├── EventRepository.cs  # Data persistence for Events
│   ├── ReservationRepository.cs
│   └── VenueRepository.cs  # Data persistence for Venues
│
└── Services/               # Business Logic & Helpers
    ├── INavigationService.cs # Interface for switching views
    └── NavigationService.cs  # Loose coupling navigation controller
