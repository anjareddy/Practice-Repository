using System.Collections;

namespace Practice.CityInfo.API.Models
{
    /// <summary>
    /// City Read Model.
    /// </summary>
    public class CityDto
    {
        /// <summary>
        /// City Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// City Name
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// City Description
        /// </summary>
        public string? Description { get; set; }

        public int NumberOfPointsOfInterest
        {
            get
            {
                return PointsOfInterests.Count;
            }
        }

        public ICollection<PointsOfInterestDto> PointsOfInterests { get; set; } = new List<PointsOfInterestDto>();
    }
}
