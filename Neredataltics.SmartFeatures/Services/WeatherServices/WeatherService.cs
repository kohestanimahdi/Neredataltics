using Grpc.Net.Client;
using Microsoft.Extensions.Options;
using Neredataltics.SmartFeatures.Data.Repositories;
using Neredataltics.SmartFeatures.Models.Dtos;
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

        public async Task<List<GetWeatherHistoryResponse>> GetWeatherHistoryAsync(string country, string city, DateTime? fromTime, DateTime? toTime, CancellationToken cancellationToken = default)
        {
            var weatherHistories = await _weatherConditionRepository.GetWeatherHistoryAsync(country, city, fromTime, toTime, cancellationToken);
            return weatherHistories.GroupBy(i => new { i.Country, i.City }).Select(i => new GetWeatherHistoryResponse
            {
                City = i.Key.City,
                Country = i.Key.Country,
                AverageTemprature = i.Average(i => i.Temperature),
                Detail = i.Select(item => new GetWeatherHistoryResponse.GetWeatherHistoryDetailResponse
                {
                    Temperature = item.Temperature,
                    AirCondition = item.AirCondition,
                    Time = item.Time
                }).ToList()
            }).ToList();
        }

    }
}
