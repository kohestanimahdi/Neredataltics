using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Neredataltics.SmartFeatures.Models.Entities.WeatherAggregates;

namespace Neredataltics.SmartFeatures.Data.EntityTypeConfigurations
{
    public class WeatherConditionEntityTypeConfiguration : IEntityTypeConfiguration<WeatherCondition>
    {
        public void Configure(EntityTypeBuilder<WeatherCondition> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Country).HasMaxLength(255);
            builder.Property(i => i.City).HasMaxLength(255);
        }
    }
}
