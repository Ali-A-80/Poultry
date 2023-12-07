using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Poultry.Domain.Entities;

namespace Poultry.Persistance.Configuration
{
    public class HumiditySensorConfiguration : IEntityTypeConfiguration<HumiditySensor>
    {
        public void Configure(EntityTypeBuilder<HumiditySensor> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.InsertTime).IsRequired();
            builder.Property(x => x.IsRemoved).IsRequired();
            builder.Property(x => x.HumidityStatus).IsRequired();
            builder.Property(x => x.Amount).IsRequired();

            builder.HasOne(x => x.Zone).WithMany(x => x.HumiditySensors)
                .HasForeignKey(x => x.ZoneId);
            

            builder.HasQueryFilter(x => !x.IsRemoved);
        }
    }
}
