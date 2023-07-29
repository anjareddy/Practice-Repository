using System.ComponentModel.DataAnnotations;

namespace Practice.CityInfo.API.Models
{
    public class PointsOfInterestCreateDto
    {
        [Required(ErrorMessage = "Name is requuired")]
        public string Name { get; set; } = string.Empty;
        
        [Required]
        [MaxLength(100)]
        public string? Description { get; set; }
    }
}
