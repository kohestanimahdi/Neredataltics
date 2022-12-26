using Grpc.Net.Client;
using Microsoft.Extensions.Options;
using Neredataltics.SmartFeatures.Models.Options;
using Neredataltics.SmartFeatures.Services.WeatherServices.Models;

namespace Neredataltics.SmartFeatures.Services.WeatherServices
{
    public class WeatherService : IWeatherService
    {
        private readonly Shared.WeatherService.WeatherServiceClient _weatherServiceClient;
        public WeatherService(IOptions<SmartModelOptions> options)
        {
            var grpcChannel = GrpcChannel.ForAddress(options.Value.HttpsUrl);
            _weatherServiceClient = new Shared.WeatherService.WeatherServiceClient(grpcChannel);
        }

        public async Task<GetCurrentWeatherResponse> GetCurrentWeatherAsync(string country, string city, CancellationToken cancellationToken = default)
        {
            var result = await _weatherServiceClient
                .GetWeatherForLocationAsync(new Shared.WeatherConditionRequest { City = city, Country = country }, cancellationToken: cancellationToken);

            return new GetCurrentWeatherResponse
            {
                Country = country,
                City = city,
                AirCondition = result.Condition,
                Temperature = result.Temperature
            };
        }
    }
}
