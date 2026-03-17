using System;
using System.ComponentModel.DataAnnotations;

namespace VenueSync.Models
{
    public class Booking
    {
        public int BookingId { get; set; }

        [Required]
        [Display(Name = "Venue")]
        public int VenueId { get; set; }

        [Required]
        [Display(Name = "Event")]
        public int EventId { get; set; }

        [Required]
        [Display(Name = "Booking Date")]
        public DateTime BookingDate { get; set; } = DateTime.Now;

        // Navigation
        public Venue? Venue { get; set; }
        public Event? Event { get; set; }
    }
}