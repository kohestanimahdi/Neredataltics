using Neredataltics.SmartFeatures.Services.WeatherServices.Models;

namespace Neredataltics.SmartFeatures.Services.WeatherServices
{
    public interface IWeatherService
    {
        Task<GetCurrentWeatherResponse> GetCurrentWeatherAsync(string country, string city, CancellationToken cancellationToken = default);
    }
}