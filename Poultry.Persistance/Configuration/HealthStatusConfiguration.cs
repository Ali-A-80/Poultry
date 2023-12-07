using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Poultry.Domain.Entities;

namespace Poultry.Persistance.Configuration
{
    public class HealthStatusConfiguration : IEntityTypeConfiguration<HealthStatus>
    {
        public void Configure(EntityTypeBuilder<HealthStatus> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.InsertTime).IsRequired();
            builder.Property(x => x.IsRemoved).IsRequired();
            builder.Property(x => x.BodyTemprature).IsRequired();
            builder.Property(x => x.HealthLevel).IsRequired();
            builder.Property(x => x.CheckupDate).IsRequired();

            builder.HasOne(x => x.Chicken).WithOne(x => x.HealthStatus)
                .HasForeignKey<HealthStatus>(x => x.ChickenId);

            builder.HasQueryFilter(x => !x.IsRemoved);
        }
    }
}
