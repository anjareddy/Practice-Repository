using Microsoft.AspNetCore.Mvc;
using Practice.CityInfo.API.Models;

namespace Practice.CityInfo.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CitiesController : ControllerBase
    {
        ILogger<CitiesController> _logger;
        CitiesDataStore _citiesDataStore;
        public CitiesController(ILogger<CitiesController> logger, CitiesDataStore citiesDataStore)
        {
            _logger = logger;
            _citiesDataStore = citiesDataStore;
        }

        [HttpGet]
        //[HttpGet("api/cities")]
        public ActionResult<IEnumerable<CityEntity>> GetCities()
        {
            _logger.LogInformation($"{nameof(GetCities)} called");
            return Ok(_citiesDataStore.Cities);
        }

        [HttpGet("{id}")]
        public ActionResult<CityEntity> GetCity(int id)
        {
            var city = _citiesDataStore.Cities.FirstOrDefault(x => x.Id == id);
            if (city == null)
            {
                _logger.LogInformation($"{nameof(GetCity)} called: No City found");
                return NotFound();
            }

            return Ok(city);
        }
    }
}
