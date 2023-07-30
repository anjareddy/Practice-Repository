using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Practice.CityInfo.API.DBContext;
using Practice.CityInfo.API.Entities;
using Practice.CityInfo.API.Models;

namespace Practice.CityInfo.API.Repositories
{
    public class CityInfoRepository : ICityInfoRepository
    {
        private readonly CityInfoDbContext _cityInfoDbContext;
        private readonly IMapper _mapper;
        public CityInfoRepository(CityInfoDbContext cityInfoDbContext, IMapper mapper)
        {
            _cityInfoDbContext = cityInfoDbContext;
            _mapper = mapper;
        }

        public async Task<int> AddPointsOfInterestAsync(PointsOfInterestEntity newPointsOfInterestDto)
        {
            _cityInfoDbContext.PointsOfInterests.Add(newPointsOfInterestDto);
            await _cityInfoDbContext.SaveChangesAsync();
            return newPointsOfInterestDto.Id;
        }

        public async Task<bool> CheckIfUserBelongsToCity(int cityId, string? cityName)
        {

            return await _cityInfoDbContext.Cities.AnyAsync(x => x.Id == cityId && x.Name == cityName);
        }

        public async Task<bool> CityExistsAsync(int cityId)
        {
            return await _cityInfoDbContext.Cities.AnyAsync(x => x.Id == cityId);
        }

        public async Task<IEnumerable<CityDto>> GetCitiesAsync()
        {
            List<CityDto> cityDtos = new List<CityDto>();
            var cities = await _cityInfoDbContext.Cities.OrderBy(x => x.Name).ToListAsync();
            cityDtos = _mapper.Map<List<CityDto>>(cities);
            return cityDtos;
        }

        public async Task<CityDto> GetCityAsync(int cityId, bool includePointsOfInterest)
        {
            CityEntity? cityEntity = null;

            if (includePointsOfInterest)
            {
                cityEntity = await _cityInfoDbContext.Cities.Include(c => c.PointsOfInterests).FirstOrDefaultAsync(x => x.Id == cityId);
            }

            cityEntity = await _cityInfoDbContext.Cities.FirstOrDefaultAsync(x => x.Id == cityId);
            CityDto cityDto = _mapper.Map<CityDto>(cityEntity);
            cityDto.PointsOfInterests = _mapper.Map<List<PointsOfInterestDto>>(cityEntity.PointsOfInterests);
            return cityDto;
        }

        public async Task<PointsOfInterestDto> GetPointsOfInterestAsync(int cityId, int pointOfInterestId)
        {
            var pointsOfInterestEntity = await _cityInfoDbContext.PointsOfInterests.FirstOrDefaultAsync(x => x.Id == pointOfInterestId && x.CityId == cityId);
            return _mapper.Map<PointsOfInterestDto>(pointsOfInterestEntity);
        }

        public async Task<IEnumerable<PointsOfInterestDto>> GetPointsOfInterestsAsync(int cityId)
        {
            var pointsOfInterests = await _cityInfoDbContext.PointsOfInterests.Where(x => x.CityId == cityId).ToListAsync();
            var pointsOfInterestsDto = _mapper.Map<IEnumerable<PointsOfInterestDto>>(pointsOfInterests);
            return pointsOfInterestsDto;
        }
    }
}
