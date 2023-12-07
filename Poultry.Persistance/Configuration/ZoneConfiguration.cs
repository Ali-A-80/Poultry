using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Poultry.Domain.Entities;

namespace Poultry.Persistance.Configuration
{
    public class ZoneConfiguration : IEntityTypeConfiguration<Zone>
    {
        public void Configure(EntityTypeBuilder<Zone> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.InsertTime).IsRequired();
            builder.Property(x => x.IsRemoved).IsRequired();
            builder.Property(x => x.ZoneType).IsRequired();

            builder.HasQueryFilter(x => !x.IsRemoved);
        }
    }
}
