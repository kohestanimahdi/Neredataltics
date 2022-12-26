using Microsoft.EntityFrameworkCore;
using Neredataltics.SmartFeatures.Models.Entities.WeatherAggregates;

namespace Neredataltics.SmartFeatures.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }
        protected ApplicationDBContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDBContext).Assembly);
        }

        public DbSet<WeatherCondition> WeatherConditions { get; set; }
    }
}
