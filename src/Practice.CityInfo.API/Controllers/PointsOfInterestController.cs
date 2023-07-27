using Microsoft.AspNetCore.Mvc;
using Practice.CityInfo.API.Models;

namespace Practice.CityInfo.API.Controllers
{
    [Route("api/cities/{cityId}/pointsofinterest")]
    [ApiController]
    public class PointsOfInterestController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<PointsOfInterestDto>> GetPointsOfInterest(int cityId)
        {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(x => x.Id == cityId);

            if (city == null)
            {
                return NotFound();
            }

            var pointsOfInterests = city.PointsOfInterest;
            return Ok(pointsOfInterests);
        }

        [HttpGet("{pointofinterestId}")]
        public ActionResult<PointsOfInterestDto> GetPointOfInterest(int cityId, int pointofinterestId)
        {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(x => x.Id == cityId);

            if (city == null)
            {
                return NotFound();
            }

            var pointsOfInterest = city.PointsOfInterest.FirstOrDefault(x => x.Id == pointofinterestId);

            if (pointsOfInterest == null)
            {
                return NotFound();
            }
            return Ok(pointsOfInterest);
        }
    }
}
