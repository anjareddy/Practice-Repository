using AutoMapper;

namespace Practice.CityInfo.API.AutoMapper.Profiles
{
    public class PointsOfInterestProfile: Profile
    {
        public PointsOfInterestProfile() 
        {
            CreateMap<Entities.PointsOfInterestEntity, Models.PointsOfInterestDto>();
        }
    }
}
