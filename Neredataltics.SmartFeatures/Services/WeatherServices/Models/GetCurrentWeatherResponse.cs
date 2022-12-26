using Neredataltics.Shared;
using Neredataltics.SmartFeatures.Models.Entities.WeatherAggregates.Enums;

namespace Neredataltics.SmartFeatures.Services.WeatherServices.Models
{
    public class GetCurrentWeatherResponse
    {
        public WeatherAirConditions AirCondition { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public int Temperature { get; set; }
    }
}
