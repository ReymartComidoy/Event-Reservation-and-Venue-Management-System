# TagumEvents: Event Reservation and Venue Management System

A dedicated desktop application built with C# WinForms to streamline event scheduling, track venue availability, manage client profiles, and automate reservation workflows. Tailored for venue managers and event planners, the system provides a complete solution for schedule tracking, client records, and role-based reservation management.

---

## 1. Project Overview

TagumEvents is designed for efficiency and ease of use in venue administration. Key capabilities include:

**Dashboard Analytics:** Instant operational insights showing active events, upcoming reservations, total daily bookings, and available venues with dynamic search filtering.

**Event Management:** Complete tracking of upcoming and completed events, including date assignments, room capacity tracking, and status monitoring.

**Reservation Lifecycle System:** Integrated scheduling engine connecting registered clients directly to venues and scheduled events with status tracking (Confirmed, Pending, Completed).

**Venue & Client Directory:** Comprehensive database management for venue hourly rates and capacities alongside a centralized Client Relationship Management (CRM) directory.

---

## 2. System Architecture & Design Patterns

The application follows a clean, modular layer structure using the Repository Pattern:

**User Controls (`Controls/`):** Decoupled Windows Forms components (`ucDashboard`, `ucEvents`, `ucReservations`, `ucVenue`, `ucClients`) managing tab views dynamically.

**Domain Models (`Models/`):** Strongly-typed entity definitions (`ClientModel`, `EventModel`, `ReservationModel`, `VenueModel`) implementing the `IEntity` contract for standardized primary keys and status fields.

**Data Access Layer (`Repositories/`):** Generic repository interface (`IRepository<T>`) and connection managers (`DataRepository`) decoupling UI logic from database storage.

**Navigation Service (`Services/`):** Controller-driven view management eliminating multi-window clutter and UI latency.

---

## 3. Tech Stack

**Language:** C#
**Framework:** .NET 8.0 (Windows Desktop Development)
**UI Engine:** Windows Forms (WinForms)
**Data Storage:** In-Memory DataTables (Architected for MySQL integration)
**IDE:** Microsoft Visual Studio 2022

---

## 4. Getting Started

### Prerequisites
* Visual Studio 2022 with the **.NET desktop development** workload installed.
* **.NET 8.0 SDK** or higher.

### Installation & Execution

1. **Clone the Repository:**
   ```bash
   git clone [https://github.com/ReymartComidoy/Event-Reservation-and-Venue-Management-System.git](https://github.com/ReymartComidoy/Event-Reservation-and-Venue-Management-System.git)
