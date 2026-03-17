using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VenueSync.Migrations
{
    /// <inheritdoc />
    public partial class UpdateVenueImages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Venues",
                keyColumn: "VenueId",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://media.istockphoto.com/id/2246315446/photo/scenes-inside-a-bright-church-gm2246315446-660281627.jpg?s=1024x1024&w=is&k=20&c=Vvqf7Z5uFchssWXZkM-XimEZFpqXb1QykT_eZfX_YrM=");

            migrationBuilder.UpdateData(
                table: "Venues",
                keyColumn: "VenueId",
                keyValue: 2,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1508098682722-e99c43a406b2?ixlib=rb-4.0.3&auto=format&fit=crop&w=1000&q=80");

            migrationBuilder.UpdateData(
                table: "Venues",
                keyColumn: "VenueId",
                keyValue: 3,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1506744038136-46273834b3fb?ixlib=rb-4.0.3&auto=format&fit=crop&w=1000&q=80");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Venues",
                keyColumn: "VenueId",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://media.istockphoto.com/id/2246315446/photo/scenes-inside-a-bright-church.jpg");

            migrationBuilder.UpdateData(
                table: "Venues",
                keyColumn: "VenueId",
                keyValue: 2,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1508098682722-e99c43a406b2");

            migrationBuilder.UpdateData(
                table: "Venues",
                keyColumn: "VenueId",
                keyValue: 3,
                column: "ImageUrl",
                value: "https://images.unsplash.com/photo-1506744038136-46273834b3fb");
        }
    }
}