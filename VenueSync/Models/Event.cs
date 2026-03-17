using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VenueSync.Models
{
    public class Event
    {
        public int EventId { get; set; }

        [Required(ErrorMessage = "Event name is required.")]
        [StringLength(150)]
        [Display(Name = "Event Name")]
        public string EventName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Event date is required.")]
        [Display(Name = "Event Date")]
        public DateTime EventDate { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Venue selection is required.")]
        [Display(Name = "Venue")]
        public int VenueId { get; set; }

        // Navigation
        public Venue? Venue { get; set; }
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}