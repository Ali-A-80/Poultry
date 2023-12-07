using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Poultry.Domain.Entities;

namespace Poultry.Persistance.Configuration
{
    public class WeatherConfiguration : IEntityTypeConfiguration<Weather>
    {
        public void Configure(EntityTypeBuilder<Weather> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.InsertTime).IsRequired();
            builder.Property(x => x.IsRemoved).IsRequired();

            builder.HasOne(x => x.Zone).WithOne(x => x.Weather)
                .HasForeignKey<Weather>(x => x.ZoneId);

            builder.HasQueryFilter(x => !x.IsRemoved);
        }
    }
}
