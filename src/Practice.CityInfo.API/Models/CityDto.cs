using System.Collections;

namespace Practice.CityInfo.API.Models
{
    public class CityEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }

        public int NumberOfPointsOfInterest
        {
            get
            {
                return PointsOfInterests.Count;
            }
        }

        public ICollection<PointsOfInterestEntity> PointsOfInterests { get; set; } = new List<PointsOfInterestEntity>();
    }
}
