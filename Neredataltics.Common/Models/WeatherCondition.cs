using Neredataltics.Common.Models.Enums;

namespace Neredataltics.Common.Models
{
    public class WeatherCondition
    {
        public string Country { get; set; }
        public string City { get; set; }
        public int Temperature { get; set; }
        public AirConditions Condition { get; set; }
    }
}
