using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Practice.CityInfo.API.Models;
using Practice.CityInfo.API.Repositories;

namespace Practice.CityInfo.API.Controllers
{
    [Route("api/v{version:ApiVersion}/cities/{cityId}/pointsofinterest")]
    [ApiController]
    [ApiVersion("2.0")]
    [Authorize]
    public class PointsOfInterestController : ControllerBase
    {
        CitiesDataStore _citiesDataStore;
        private readonly ILogger<PointsOfInterestController> _logger;
        private readonly ICityInfoRepository _cityInfoRepository;
        private readonly IMapper _mapper;
        public PointsOfInterestController(
            ILogger<PointsOfInterestController> logger, 
            CitiesDataStore citiesDataStore,
            ICityInfoRepository cityInfoRepository, IMapper mapper)
        {
            //_ = HttpContext.RequestServices.GetService(typeof(ILogger<PointsOfInterestController>));
            _citiesDataStore = citiesDataStore;
            _logger = logger;
            _cityInfoRepository = cityInfoRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PointsOfInterestDto>>> GetPointsOfInterestAsync(int cityId)
        {
            var pointsOfInterestDtos = await _cityInfoRepository.GetPointsOfInterestsAsync(cityId);
            return Ok(pointsOfInterestDtos);
        }

        [HttpGet("{pointofinterestId}", Name = "GetPointOfInterest")]
        public async Task<ActionResult<PointsOfInterestDto>> GetPointOfInterestAsync(int cityId, int pointofinterestId)
        {
            var pointsOfInterestDto = await _cityInfoRepository.GetPointsOfInterestAsync(cityId, pointofinterestId);
            return Ok(pointsOfInterestDto);
        }

        /// <summary>
        /// This is to add multiple routes
        /// </summary>
        /// <param name="cityId"></param>
        /// <param name="pointofinterestId"></param>
        /// <returns></returns>
        [HttpGet("{pointofinterestId}/GetPointOfInterestOfLast", Name = "GetPointOfInterestOfLast")]
        public async Task<ActionResult<PointsOfInterestDto>> GetPointOfInterestOfLast(int cityId, int pointofinterestId)
        {
            var pointsOfInterestDto = await _cityInfoRepository.GetPointsOfInterestAsync(cityId, pointofinterestId);
            return Ok(pointsOfInterestDto);
        }

        [HttpPost]
        public async Task<ActionResult<PointsOfInterestDto>> CreatePointOfInterest(int cityId, PointsOfInterestCreateDto pointOfInterest)
        {
            if (! await _cityInfoRepository.CityExistsAsync(cityId))
            {
                return NotFound(nameof(CityDto));
            }

            var newPointsOfInterestDto = _mapper.Map<Entities.PointsOfInterestEntity>(pointOfInterest);

            var newPointOfInterestId = await _cityInfoRepository.AddPointsOfInterestAsync(newPointsOfInterestDto);

            return CreatedAtRoute("GetPointOfInterest", new
            {
                cityId,
                pointOfInterestId = newPointOfInterestId
            }, newPointsOfInterestDto);
        }

        [HttpPut("{pointofinterestId}")]
        public ActionResult<PointsOfInterestDto> UpdatePointOfInterest(int cityId, int pointofinterestId, [FromBody] PointsOfInterestUpdateDto pointOfInterest)
        {
            var city = _citiesDataStore.Cities.FirstOrDefault(x => x.Id == cityId);
            if (city == null)
            {
                return NotFound(nameof(CityDto));
            }

            var pointOfInterestToUpdate = city.PointsOfInterests.FirstOrDefault(x => x.Id == pointofinterestId);
            if (pointOfInterestToUpdate == null)
            {
                return NotFound(nameof(PointsOfInterestDto));
            }

            pointOfInterestToUpdate.Name = pointOfInterest.Name;
            pointOfInterestToUpdate.Description = pointOfInterest.Description;

            return NoContent();
        }

        [HttpPatch("{pointofinterestId}")]
        public ActionResult<PointsOfInterestDto> PartiallyUpdatePointOfInterest(int cityId, int pointofinterestId, JsonPatchDocument<PointsOfInterestUpdateDto> patchDocument)
        {
            var city = _citiesDataStore.Cities.FirstOrDefault(x => x.Id == cityId);
            if (city == null)
            {
                return NotFound(nameof(CityDto));
            }

            var pointOfInterestToUpdate = city.PointsOfInterests.FirstOrDefault(x => x.Id == pointofinterestId);
            if (pointOfInterestToUpdate == null)
            {
                return NotFound(nameof(PointsOfInterestDto));
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
        public ActionResult<PointsOfInterestDto> DeletePointOfInterest(int cityId, int pointofinterestId)
        {
            var city = _citiesDataStore.Cities.FirstOrDefault(x => x.Id == cityId);
            if (city == null)
            {
                return NotFound(nameof(CityDto));
            }

            var pointOfInterestToDelete = city.PointsOfInterests.FirstOrDefault(x => x.Id == pointofinterestId);
            if (pointOfInterestToDelete == null)
            {
                return NotFound(nameof(PointsOfInterestDto));
            }

            city.PointsOfInterests.Remove(pointOfInterestToDelete);

            return NoContent();
        }
    }
}
