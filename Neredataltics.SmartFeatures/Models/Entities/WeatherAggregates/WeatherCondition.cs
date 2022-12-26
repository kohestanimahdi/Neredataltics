using Neredataltics.SmartFeatures.Models.Entities.WeatherAggregates.Enums;

namespace Neredataltics.SmartFeatures.Models.Entities.WeatherAggregates
{
    public class WeatherCondition
    {
        public WeatherAirConditions AirCondition { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public int Temperature { get; set; }
        public DateTime Time { get; set; }
        public int Id { get; set; }
    }
}
