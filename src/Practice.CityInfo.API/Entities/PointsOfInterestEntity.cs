using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Practice.CityInfo.API.Entities
{
    public class PointsOfInterestEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        
        [MaxLength(200)]
        public string? Description { get; set; }
        
        [ForeignKey("CityId")]
        public CityEntity? city { get; set; }
        public int CityId { get; set; }
        
        public PointsOfInterestEntity(string name)
        {
            Name = name;
        }
    }
}
