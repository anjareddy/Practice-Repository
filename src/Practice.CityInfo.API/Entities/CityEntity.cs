using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Practice.CityInfo.API.Entities
{
    public class CityEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        
        [MaxLength(200)]
        public string? Description { get; set; }

        public ICollection<PointsOfInterestEntity> PointsOfInterests { get; set; } = new List<PointsOfInterestEntity>();

        public CityEntity(string name)
        {
            Name = name;
        }
    }
}
