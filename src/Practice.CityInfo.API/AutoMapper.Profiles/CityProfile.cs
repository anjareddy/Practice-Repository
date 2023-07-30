using AutoMapper;

namespace Practice.CityInfo.API.AutoMapper.Profiles
{
    public class CityProfile: Profile
    {
        public CityProfile() 
        {
            CreateMap<Entities.CityEntity, Models.CityDto>();
        }
    }
}
