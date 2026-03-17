 VenueSync

VenueSync is a web-based venue and event management system built with ASP.NET Core MVC and Entity Framework Core. The application allows administrators to manage venues, events, and bookings efficiently. It provides a professional interface to prevent double bookings, maintain venue details, and streamline event management.



 Features

- Venue Management
  - Add, edit, and delete venues.
  - Store venue details including name, location, capacity, description, and images.
  
- Event Management
  - Add, edit, and delete events.
  - Assign events to specific venues with date validation to prevent double bookings.

- Booking System
  - Book events at available venues.
  - Prevent booking conflicts at the same venue and date.

- Admin Login
  - Secure login system for administrators.
  - Only logged-in admins can access venue and event management pages.
  - Session-based authentication for managing admin access.



 Admin Login

The app uses a simple username and password system for admin access:

- Default credentials (configured in the database seeding):
  - Username: `admin`
  - Password: `password123`

 How it works:
1. Navigate to the login page (`/Account/Login`).
2. Enter the admin username and password.
3. If credentials are correct, a session is created, granting access to admin pages like Venues and Events.
4. To log out, click the Logout button, which clears the session.

> Only admins can perform create, edit, or delete operations. Visitors cannot access these pages without logging in.



 Tech Stack

- Backend: ASP.NET Core MVC  
- Database: SQL Server with Entity Framework Core  
- Frontend: Razor Views, HTML, CSS  
- Authentication: Session-based admin login  



 Installation

1. Clone the repository:
   bash
   git clone <your-repo-url>
