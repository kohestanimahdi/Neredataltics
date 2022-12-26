namespace Neredataltics.SmartFeatures.Models.Dtos
{
    public class GetWeatherHistoryRequest
    {
        public string Country { get; set; }
        public string City { get; set; }
        public DateTime? FromTime { get; set; }
        public DateTime? ToTime { get; set; }
    }
}
