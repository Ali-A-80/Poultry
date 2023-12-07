using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Poultry.Domain.Entities;

namespace Poultry.Persistance.Configuration
{
    public class VentilationSensorConfiguration : IEntityTypeConfiguration<VentilationSensor>
    {
        public void Configure(EntityTypeBuilder<VentilationSensor> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.InsertTime).IsRequired();
            builder.Property(x => x.IsRemoved).IsRequired();
            builder.Property(x => x.VentilationStatus).IsRequired();
            builder.Property(x => x.AirFlow).IsRequired();

            builder.HasOne(x => x.Zone).WithMany(x => x.VentilationSensors)
                .HasForeignKey(x => x.ZoneId);


            builder.HasQueryFilter(x => !x.IsRemoved);
        }
    }
}
