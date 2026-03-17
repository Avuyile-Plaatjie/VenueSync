using Microsoft.EntityFrameworkCore;
using VenueSync.Models;

namespace VenueSync.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Venue> Venues { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Admin> Admins { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure Booking relationships
            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Venue)
                .WithMany(v => v.Bookings)
                .HasForeignKey(b => b.VenueId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Event)
                .WithMany(e => e.Bookings)
                .HasForeignKey(b => b.EventId)
                .OnDelete(DeleteBehavior.Restrict);

            // Seed Admin
            modelBuilder.Entity<Admin>().HasData(
                new Admin
                {
                    AdminId = 1,
                    Username = "admin",
                    Password = "password123"
                }
            );

            // Seed Venues
            modelBuilder.Entity<Venue>().HasData(
                new Venue
                {
                    VenueId = 1,
                    VenueName = "St. Mary's Church Hall",
                    Location = "12 Unity Street, Johannesburg",
                    Capacity = 250,
                    ImageUrl = "https://images.unsplash.com/photo-1677051286670-1e83ec52d87e?w=600&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8M3x8Y2h1cmNoJTIwaGFsbHxlbnwwfHwwfHx8MA%3D%3D",
                    Description = "A warm and welcoming church hall featuring a bright interior, high ceilings, and a peaceful atmosphere. Ideal for weddings, community gatherings, meetings, and small celebrations, offering a comfortable and serene setting for meaningful events."
                },
                new Venue
                {
                    VenueId = 2,
                    VenueName = "Metro Grand Stadium",
                    Location = "120 Arena Drive, Durban",
                    Capacity = 50000,
                    ImageUrl = "https://images.unsplash.com/photo-1540747913346-19e32dc3e97e?w=600&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8OHx8c3RhZGl1bXxlbnwwfHwwfHx8MA%3D%3D",
                    Description = "A massive open-air stadium designed for large-scale concerts, sporting events, and festivals. Featuring state-of-the-art lighting, sound systems, and expansive seating, it provides an electrifying atmosphere for unforgettable live experiences."
                },
                new Venue
                {
                    VenueId = 3,
                    VenueName = "Greenfield City Park",
                    Location = "78 Park Lane, Pretoria",
                    Capacity = 800,
                    ImageUrl = "https://images.unsplash.com/photo-1696079196661-a5cbfb884255?w=600&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8N3x8Y2l0eSUyMHBhcmt8ZW58MHx8MHx8fDA%3D",
                    Description = "A beautiful open-air city park surrounded by greenery and skyline views, ideal for outdoor events, picnics, festivals, and community gatherings. The venue offers a relaxed and natural atmosphere with plenty of space for creative and flexible event setups."
                }
            );
        }
    }
}