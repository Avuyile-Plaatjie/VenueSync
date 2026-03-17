using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VenueSync.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSeededVenues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Venues",
                keyColumn: "VenueId",
                keyValue: 1,
                columns: new[] { "VenueName", "Location", "Capacity", "ImageUrl", "Description" },
                values: new object[] {
            "St. Mary's Church Hall",
            "12 Unity Street, Johannesburg",
            250,
            "https://media.istockphoto.com/id/2246315446/photo/scenes-inside-a-bright-church.jpg",
            "A warm and welcoming church hall featuring a bright interior, high ceilings, and a peaceful atmosphere. Ideal for weddings, community gatherings, meetings, and small celebrations, offering a comfortable and serene setting for meaningful events."
                });

            migrationBuilder.UpdateData(
                table: "Venues",
                keyColumn: "VenueId",
                keyValue: 2,
                columns: new[] { "VenueName", "Location", "Capacity", "ImageUrl", "Description" },
                values: new object[] {
            "Metro Grand Stadium",
            "120 Arena Drive, Durban",
            50000,
            "https://images.unsplash.com/photo-1508098682722-e99c43a406b2",
            "A massive open-air stadium designed for large-scale concerts, sporting events, and festivals. Featuring state-of-the-art lighting, sound systems, and expansive seating, it provides an electrifying atmosphere for unforgettable live experiences."
                });

            migrationBuilder.UpdateData(
                table: "Venues",
                keyColumn: "VenueId",
                keyValue: 3,
                columns: new[] { "VenueName", "Location", "Capacity", "ImageUrl", "Description" },
                values: new object[] {
            "Greenfield City Park",
            "78 Park Lane, Pretoria",
            800,
            "https://images.unsplash.com/photo-1506744038136-46273834b3fb",
            "A beautiful open-air city park surrounded by greenery and skyline views, ideal for outdoor events, picnics, festivals, and community gatherings. The venue offers a relaxed and natural atmosphere with plenty of space for creative and flexible event setups."
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Optionally revert back to previous values here
        }
    }
}
