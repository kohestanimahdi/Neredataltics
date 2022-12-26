using Neredataltics.SmartFeatures.Models.Entities.WeatherAggregates;

namespace Neredataltics.SmartFeatures.Data.Repositories
{
    public interface IWeatherConditionRepository
    {
        Task AddAsync(WeatherCondition weatherCondition, CancellationToken cancellationToken = default);
        Task<List<WeatherCondition>> GetWeatherHistoryAsync(string country, string city, DateTime? fromTime, DateTime? toTime, CancellationToken cancellationToken = default);
    }
}