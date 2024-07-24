using System.ComponentModel.DataAnnotations;

namespace Technical.UI.Models
{
    public class LocationDto
    {
        public string? LocationId { get; set; }
        [Required]
        public string locationName { get; set; }
    }
}
