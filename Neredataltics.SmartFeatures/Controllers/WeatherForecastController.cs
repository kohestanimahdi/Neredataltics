using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Neredataltics.SmartFeatures.Models.Dtos;
using Neredataltics.SmartFeatures.Services.WeatherServices;
using Neredataltics.SmartFeatures.Services.WeatherServices.Models;
using System.ComponentModel.DataAnnotations;

namespace Neredataltics.SmartFeatures.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {


        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWeatherService _weatherService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherService weatherService)
        {
            _logger = logger;
            _weatherService = weatherService;
        }


        [AllowAnonymous]
        [HttpGet]
        [Route("CurrentWeatherForecast")]
        [ProducesResponseType(typeof(GetCurrentWeatherResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetWeatherForecasts([FromQuery, Required] string country = "Iran", [FromQuery, Required] string city = "Isfahan", CancellationToken cancellationToken = default)
        {
            var result = await _weatherService.GetCurrentWeatherAsync(country, city, cancellationToken);
            return Ok(result);
        }


        [AllowAnonymous]
        [HttpGet]
        [Route("WeatherHistory")]
        [ProducesResponseType(typeof(List<GetWeatherHistoryResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetWeatherHistory([FromQuery] GetWeatherHistoryRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _weatherService.GetWeatherHistoryAsync(request.Country, request.City, request.FromTime, request.ToTime, cancellationToken);
            return Ok(result);
        }
    }
}