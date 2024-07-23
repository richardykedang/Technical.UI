using System.ComponentModel.DataAnnotations;

namespace Technical.UI.Models
{
    public class LocationDto
    {
        [Required(ErrorMessage = "Location name is required.")]
        public string locationName { get; set; }
    }
}
