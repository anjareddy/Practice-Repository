using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Practice.CityInfo.API.Models;

namespace Practice.CityInfo.API.Controllers
{
    [Route("api/cities/{cityId}/pointsofinterest")]
    [ApiController]
    public class PointsOfInterestController : ControllerBase
    {
        private readonly ILogger<PointsOfInterestController> _logger;
        public CitiesDataStore _citiesDataStore;
        public PointsOfInterestController(ILogger<PointsOfInterestController> logger, CitiesDataStore citiesDataStore)
        {
            _logger = logger;
            _citiesDataStore = citiesDataStore;
            //_ = HttpContext.RequestServices.GetService(typeof(ILogger<PointsOfInterestController>));
        }

        [HttpGet]
        public ActionResult<IEnumerable<PointsOfInterestEntity>> GetPointsOfInterest(int cityId)
        {
            var city = _citiesDataStore.Cities.FirstOrDefault(x => x.Id == cityId);

            if (city == null)
            {
                return NotFound();
            }

            var pointsOfInterests = city.PointsOfInterests;
            return Ok(pointsOfInterests);
        }

        [HttpGet("{pointofinterestId}", Name = "GetPointOfInterest")]
        public ActionResult<PointsOfInterestEntity> GetPointOfInterest(int cityId, int pointofinterestId)
        {
            var city = _citiesDataStore.Cities.FirstOrDefault(x => x.Id == cityId);

            if (city == null)
            {
                return NotFound();
            }

            var pointsOfInterest = city.PointsOfInterests.FirstOrDefault(x => x.Id == pointofinterestId);

            if (pointsOfInterest == null)
            {
                return NotFound();
            }
            return Ok(pointsOfInterest);
        }

        /// <summary>
        /// This is add multiple routes
        /// </summary>
        /// <param name="cityId"></param>
        /// <param name="pointofinterestId"></param>
        /// <returns></returns>
        [HttpGet("{pointofinterestId}/GetPointOfInterestOfLast", Name = "GetPointOfInterestOfLast")]
        public ActionResult<PointsOfInterestEntity> GetPointOfInterestOfLast(int cityId, int pointofinterestId)
        {
            var city = _citiesDataStore.Cities.FirstOrDefault(x => x.Id == cityId);

            if (city == null)
            {
                return NotFound();
            }

            var pointsOfInterest = city.PointsOfInterests.FirstOrDefault(x => x.Id == pointofinterestId);

            if (pointsOfInterest == null)
            {
                return NotFound();
            }
            return Ok(pointsOfInterest);
        }

        [HttpPost]
        public ActionResult<PointsOfInterestEntity> CreatePointOfInterest(int cityId, PointsOfInterestCreateDto pointOfInterest)
        {
            var city = _citiesDataStore.Cities.FirstOrDefault(x => x.Id == cityId);
            if (city == null)
            {
                return NotFound(nameof(CityEntity));
            }

            int maxPointOfInterestId = _citiesDataStore.Cities.SelectMany(c => c.PointsOfInterests).Max(x => x.Id);
            var newPointsOfInterestDto = new PointsOfInterestEntity
            {
                Id = ++maxPointOfInterestId,
                Name = pointOfInterest.Name,
                Description = pointOfInterest.Description,
            };

            city.PointsOfInterests.Add(newPointsOfInterestDto);
            return CreatedAtRoute("GetPointOfInterest", new
            {
                cityId,
                pointOfInterestId = maxPointOfInterestId
            }, newPointsOfInterestDto);
        }

        [HttpPut("{pointofinterestId}")]
        public ActionResult<PointsOfInterestEntity> UpdatePointOfInterest(int cityId, int pointofinterestId, [FromBody] PointsOfInterestUpdateDto pointOfInterest)
        {
            var city = _citiesDataStore.Cities.FirstOrDefault(x => x.Id == cityId);
            if (city == null)
            {
                return NotFound(nameof(CityEntity));
            }

            var pointOfInterestToUpdate = city.PointsOfInterests.FirstOrDefault(x => x.Id == pointofinterestId);
            if (pointOfInterestToUpdate == null)
            {
                return NotFound(nameof(PointsOfInterestEntity));
            }

            pointOfInterestToUpdate.Name = pointOfInterest.Name;
            pointOfInterestToUpdate.Description = pointOfInterest.Description;

            return NoContent();
        }

        [HttpPatch("{pointofinterestId}")]
        public ActionResult<PointsOfInterestEntity> PartiallyUpdatePointOfInterest(int cityId, int pointofinterestId, JsonPatchDocument<PointsOfInterestUpdateDto> patchDocument)
        {
            var city = _citiesDataStore.Cities.FirstOrDefault(x => x.Id == cityId);
            if (city == null)
            {
                return NotFound(nameof(CityEntity));
            }

            var pointOfInterestToUpdate = city.PointsOfInterests.FirstOrDefault(x => x.Id == pointofinterestId);
            if (pointOfInterestToUpdate == null)
            {
                return NotFound(nameof(PointsOfInterestEntity));
            }

            var pointOfInterestToPatch = new PointsOfInterestUpdateDto()
            {
                Name = pointOfInterestToUpdate.Name,
                Description = pointOfInterestToUpdate.Description
            };

            patchDocument.ApplyTo(pointOfInterestToPatch, (Microsoft.AspNetCore.JsonPatch.Adapters.IObjectAdapter)ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (!TryValidateModel(pointOfInterestToPatch))
            {
                return BadRequest();
            }

            pointOfInterestToUpdate.Name = pointOfInterestToPatch.Name;
            pointOfInterestToUpdate.Description = pointOfInterestToPatch.Description;

            return NoContent();
        }


        [HttpDelete("{pointofinterestId}")]
        public ActionResult<PointsOfInterestEntity> DeletePointOfInterest(int cityId, int pointofinterestId)
        {
            var city = _citiesDataStore.Cities.FirstOrDefault(x => x.Id == cityId);
            if (city == null)
            {
                return NotFound(nameof(CityEntity));
            }

            var pointOfInterestToDelete = city.PointsOfInterests.FirstOrDefault(x => x.Id == pointofinterestId);
            if (pointOfInterestToDelete == null)
            {
                return NotFound(nameof(PointsOfInterestEntity));
            }

            city.PointsOfInterests.Remove(pointOfInterestToDelete);

            return NoContent();
        }
    }
}
