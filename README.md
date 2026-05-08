 VenueSync
VenueSync: Event & Venue Management System
VenueSync is a full-stack web application built with ASP.NET Core MVC designed for venue owners and event organizers. It provides a centralized platform to manage physical spaces, schedule events, and handle client bookings with built-in business logic for data integrity and security.
Features
 Venue & Event Gallery
•	Azure Blob Integration: Dynamically handles venue image uploads and storage using Azure Blob Storage.
•	Responsive UI: A modern, card-based gallery layout for browsing venues and scheduled events.
•	Color-Coded Dashboard: Intuitive yellow-themed navigation for administrative tasks.
Security & Access Control
•	Session-Based Authentication: Management features (Create/Edit/Delete) are locked behind a secure login wall.
•	Dynamic Navigation: The header automatically adjusts to show or hide administrative links based on the user's login status.
Business Logic & Data Integrity
•	Referential Integrity Safeguards: Prevents the deletion of Venues or Events if they are associated with active bookings, ensuring historical data is never lost accidentally.
•	Booking Conflict Detection: Built-in validation to prevent double-booking a venue on the same date.
•	Search Functionality: Robust search filters for the Bookings management table.
 Tech Stack
•	Framework: ASP.NET Core MVC 8.0
•	Language: C#
•	Database: SQL Server (Entity Framework Core)
•	Cloud Storage: Azure Blob Storage (for venue imagery)
•	Frontend: Razor Views, Bootstrap 5, Custom CSS
•	Architecture: Repository-like service patterns 

Setup & Installation
Prerequisites
•	Visual Studio 2022
•	.NET 8.0 SDK
•	SQL Server (LocalDB or Azure SQL)
•	Azure Storage Account (Connection string required)
Configuration
Update your appsettings.json with your specific connection strings:

JSON:

{
  "ConnectionStrings": {
    "DefaultConnection": "Your_SQL_Server_Connection_String"
  },
  "AzureStorage": {
    "ConnectionString": "Your_Azure_Blob_Storage_String",
    "ContainerName": "venue-images"
  }
}

Database Initialization
Run the following commands in the Package Manager Console:
Add-Migration InitialCreate Update-Database

Project Structure
•	/Controllers: Contains logic for Venues, Events, Bookings, and Account management.
•	/Models: Database schemas and ViewModels.
•	/Views: Razor templates (Layouts, Gallery Views, Management Forms).
•	/Services: Specialized logic for Azure Blob uploads and business rules.
•	/wwwroot: Static assets (CSS, Site JavaScript, Bootstrap).

Deployment
This application is designed for seamless deployment to Azure App Service.
1.	Create an Azure App Service and Azure SQL Database.
2.	Configure Application Settings in the Azure Portal to store sensitive connection strings.
3.	Deploy via GitHub Actions or Visual Studio Publish.




