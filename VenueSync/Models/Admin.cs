using System.ComponentModel.DataAnnotations;

namespace VenueSync.Models
{
    public class Admin
    {
        public int AdminId { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}