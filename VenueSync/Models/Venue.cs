using System.ComponentModel.DataAnnotations;

namespace VenueSync.Models
{
    public class Venue
    {
        public int VenueId { get; set; }

        [Required]
        [StringLength(150)]
        public string VenueName { get; set; } = string.Empty;

        [Required]
        [StringLength(250)]
        public string Location { get; set; } = string.Empty;

        [Required]
        [Range(1, 100000)]
        public int Capacity { get; set; }

        public string? ImageUrl { get; set; }

        public string? Description { get; set; }

        public ICollection<Event> Events { get; set; } = new List<Event>();

        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}