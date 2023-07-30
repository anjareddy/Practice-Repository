using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Practice.CityInfo.API.Models;
using Practice.CityInfo.API.Repositories;

namespace Practice.CityInfo.API.Controllers
{
    [ApiController]
    [Route("api/v{version:ApiVersion}/cities")]
    [Authorize(Policy = "MustBeFromCleveland")]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    public class CitiesController : ControllerBase
    {
        CitiesDataStore _citiesDataStore;
        private readonly ILogger<CitiesController> _logger;
        private readonly ICityInfoRepository _cityInfoRepository;
        public CitiesController(ILogger<CitiesController> logger, CitiesDataStore citiesDataStore, ICityInfoRepository cityInfoRepository)
        {
            _citiesDataStore = citiesDataStore;
            _logger = logger;
            _cityInfoRepository = cityInfoRepository;
        }

        [HttpGet]
        //[HttpGet("api/cities")]
        public async Task<ActionResult<IEnumerable<CityDto>>> GetCities()
        {
            _logger.LogInformation($"{nameof(GetCities)} called");
            var cities = await _cityInfoRepository.GetCitiesAsync();
            return Ok(cities);
        }

        /// <summary>
        /// Gets City information
        /// </summary>
        /// <param name="id">The city Id.</param>
        /// <returns>An ActionResult.</returns>
        /// <response code="200">Returns the city.</response>
        /// <response code="404">Returns when city not found.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CityDto>> GetCity(int id)
        {
            if (! await _cityInfoRepository.CheckIfUserBelongsToCity(id, User.Claims.FirstOrDefault(c => c.Type == "city")?.Value))
            {
                return Forbid();
            }

            //var city = _citiesDataStore.Cities.FirstOrDefault(x => x.Id == id);
            var city = await _cityInfoRepository.GetCityAsync(id, false);
            if (city == null)
            {
                _logger.LogInformation($"{nameof(GetCity)} called: No City found");
                return NotFound();
            }

            return Ok(city);
        }
    }
}
