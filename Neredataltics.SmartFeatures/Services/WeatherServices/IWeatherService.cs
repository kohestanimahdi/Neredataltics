using Neredataltics.SmartFeatures.Models.Dtos;
using Neredataltics.SmartFeatures.Services.WeatherServices.Models;

namespace Neredataltics.SmartFeatures.Services.WeatherServices
{
    public interface IWeatherService
    {
        Task<GetCurrentWeatherResponse> GetCurrentWeatherAsync(string country, string city, CancellationToken cancellationToken = default);
        Task<List<GetWeatherHistoryResponse>> GetWeatherHistoryAsync(string country, string city, DateTime? fromTime, DateTime? toTime, CancellationToken cancellationToken = default);
    }
}