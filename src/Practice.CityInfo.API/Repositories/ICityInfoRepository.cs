using Practice.CityInfo.API.Entities;
using Practice.CityInfo.API.Models;

namespace Practice.CityInfo.API.Repositories
{
    public interface ICityInfoRepository
    {
        Task<IEnumerable<CityDto>> GetCitiesAsync();
        Task<CityDto> GetCityAsync(int cityId, bool includePointsOfInterest);
        Task<IEnumerable<PointsOfInterestDto>> GetPointsOfInterestsAsync(int cityId);
        Task<PointsOfInterestDto> GetPointsOfInterestAsync(int cityId, int pointOfInterest);
        Task<bool> CityExistsAsync(int cityId);
        Task<int> AddPointsOfInterestAsync(PointsOfInterestEntity newPointsOfInterestDto);
        Task<bool> CheckIfUserBelongsToCity(int cityId, string? cityName);
    }
}
