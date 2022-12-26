using Neredataltics.Shared;

namespace Neredataltics.SmartFeatures.Services.WeatherServices.Models
{
    public class GetCurrentWeatherResponse
    {
        public AirConditions AirCondition { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public int Temperature { get; set; }
    }
}
