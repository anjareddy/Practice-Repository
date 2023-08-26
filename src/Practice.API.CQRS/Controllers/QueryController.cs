using Microsoft.AspNetCore.Mvc;

namespace Practice.API.CQRS.Controllers
{
    [ApiController]
    [Route("api/query")]
    public class QueryController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<PingController> _logger;

        public QueryController(ILogger<PingController> logger)
        {
            _logger = logger;
        }

        public IActionResult Get()
        {
            return Ok(Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray());
        }
    }
}