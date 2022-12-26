using Neredataltics.SmartFeatures.Models.Entities.WeatherAggregates;
using Neredataltics.SmartFeatures.Models.Entities.WeatherAggregates.Enums;

namespace Neredataltics.SmartFeatures.Data.DataInitializers
{
    public class WeatherConditionDataInitializer : IDataInitializer
    {
        private readonly ApplicationDBContext _dbContext;

        public WeatherConditionDataInitializer(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        static Random _random = new();
        private int GetRandomTemperature() => _random.Next(-100, 100);
        private WeatherAirConditions GetRandomAirConditions() => (WeatherAirConditions)_random.Next(4);

        public void Initialize()
        {
            if (!_dbContext.WeatherConditions.Any())
            {
                var items = new List<WeatherCondition>();
                for (int i = 0; i < 1000; i++)
                {
                    var temp = GetRandomTemperature();
                    items.Add(new WeatherCondition
                    {
                        AirCondition = GetRandomAirConditions(),
                        City = "Isfahan",
                        Country = "Iran",
                        Temperature = temp,
                        Time = DateTime.Now.AddHours(temp)
                    });
                }

                _dbContext.WeatherConditions.AddRange(items);
                _dbContext.SaveChanges();
            }
        }
    }
}
