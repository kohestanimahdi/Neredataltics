using Neredataltics.SmartFeatures.Models.Entities.WeatherAggregates.Enums;

namespace Neredataltics.SmartFeatures.Models.Dtos
{
    public class GetWeatherHistoryResponse
    {
        public class GetWeatherHistoryDetailResponse
        {
            public WeatherAirConditions AirCondition { get; set; }
            public int Temperature { get; set; }
            public DateTime Time { get; set; }
        }
        public string Country { get; set; }
        public string City { get; set; }
        public double AverageTemprature { get; set; }
        public List<GetWeatherHistoryDetailResponse> Detail { get; set; }

    }
}
