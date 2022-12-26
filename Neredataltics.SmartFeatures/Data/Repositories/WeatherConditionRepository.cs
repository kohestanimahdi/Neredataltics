using Microsoft.EntityFrameworkCore;
using Neredataltics.SmartFeatures.Models.Entities.WeatherAggregates;

namespace Neredataltics.SmartFeatures.Data.Repositories
{
    public class WeatherConditionRepository : IWeatherConditionRepository
    {
        private readonly ApplicationDBContext _dbContext;

        public WeatherConditionRepository(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public Task AddAsync(WeatherCondition weatherCondition, CancellationToken cancellationToken = default)
        {
            _dbContext.WeatherConditions.Add(weatherCondition);
            return _dbContext.SaveChangesAsync(cancellationToken);
        }

        public Task<List<WeatherCondition>> GetWeatherHistoryAsync(string country, string city, DateTime? fromTime, DateTime? toTime, CancellationToken cancellationToken = default)
        {
            var result = _dbContext.WeatherConditions.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(country))
                result = result.Where(i => i.Country == country);

            if (!string.IsNullOrWhiteSpace(city))
                result = result.Where(i => i.City == city);

            if (fromTime.HasValue)
                result = result.Where(i => i.Time >= fromTime.Value);

            if (toTime.HasValue)
                result = result.Where(i => i.Time < toTime.Value);

            return result.ToListAsync(cancellationToken);
        }
    }
}
