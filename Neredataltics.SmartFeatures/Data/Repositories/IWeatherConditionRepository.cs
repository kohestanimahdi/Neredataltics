using Neredataltics.SmartFeatures.Models.Entities.WeatherAggregates;

namespace Neredataltics.SmartFeatures.Data.Repositories
{
    public interface IWeatherConditionRepository
    {
        Task AddAsync(WeatherCondition weatherCondition, CancellationToken cancellationToken = default);
    }
}