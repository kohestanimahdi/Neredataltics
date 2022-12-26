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
    }
}
