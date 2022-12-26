using Grpc.Core;
using Neredataltics.Shared;

namespace Neredataltics.SmartModel.Services
{
    public class WeatherService : Shared.WeatherService.WeatherServiceBase
    {
        static Random _random = new();
        private int GetRandomTemperature() => _random.Next(-100, 100);
        private AirConditions GetRandomAirConditions() => (AirConditions)_random.Next(4);

        public override Task<WeatherConditionResponse> GetWeatherForLocation(WeatherConditionRequest request, ServerCallContext context)
        {
            return Task.FromResult(new WeatherConditionResponse
            {
                Condition = GetRandomAirConditions(),
                Temperature = GetRandomTemperature(),
            });
        }
    }
}
