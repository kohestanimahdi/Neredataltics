using Grpc.Net.Client;
using Microsoft.Extensions.Options;
using Neredataltics.SmartFeatures.Data.Repositories;
using Neredataltics.SmartFeatures.Models.Entities.WeatherAggregates.Enums;
using Neredataltics.SmartFeatures.Models.Options;
using Neredataltics.SmartFeatures.Services.WeatherServices.Models;

namespace Neredataltics.SmartFeatures.Services.WeatherServices
{
    public class WeatherService : IWeatherService
    {
        private readonly Shared.WeatherService.WeatherServiceClient _weatherServiceClient;
        private readonly IWeatherConditionRepository _weatherConditionRepository;

        public WeatherService(IOptions<SmartModelOptions> options, IWeatherConditionRepository weatherConditionRepository)
        {
            var grpcChannel = GrpcChannel.ForAddress(options.Value.HttpsUrl);
            _weatherServiceClient = new Shared.WeatherService.WeatherServiceClient(grpcChannel);
            _weatherConditionRepository = weatherConditionRepository;
        }

        public async Task<GetCurrentWeatherResponse> GetCurrentWeatherAsync(string country, string city, CancellationToken cancellationToken = default)
        {
            var result = await _weatherServiceClient
                .GetWeatherForLocationAsync(new Shared.WeatherConditionRequest { City = city, Country = country }, cancellationToken: cancellationToken);

            await _weatherConditionRepository.AddAsync(new SmartFeatures.Models.Entities.WeatherAggregates.WeatherCondition
            {
                AirCondition = (WeatherAirConditions)result.Condition,
                City = city,
                Country = country,
                Temperature = result.Temperature,
                Time = DateTime.Now
            });

            return new GetCurrentWeatherResponse
            {
                Country = country,
                City = city,
                AirCondition = (WeatherAirConditions)result.Condition,
                Temperature = result.Temperature
            };
        }
    }
}
