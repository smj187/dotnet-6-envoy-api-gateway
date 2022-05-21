using Microsoft.AspNetCore.Mvc;
using PublicService.Services;

namespace PublicService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PublicController : ControllerBase
    {
        private readonly WeatherService _weatherService;

        public PublicController(WeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        [HttpGet]
        public IActionResult Public()
        {
            var res = $"weather: {_weatherService.GetWeather()}";
            return Ok($"this public endpoint is rate limited by envoy\n\n{res}");
        }
    }
}