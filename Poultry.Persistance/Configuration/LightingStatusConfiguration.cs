using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Poultry.Domain.Entities;

namespace Poultry.Persistance.Configuration
{
    public class LightingStatusConfiguration : IEntityTypeConfiguration<LightingStatus>
    {
        public void Configure(EntityTypeBuilder<LightingStatus> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.InsertTime).IsRequired();
            builder.Property(x => x.IsRemoved).IsRequired();
            builder.Property(x => x.LightingStatusType).IsRequired();
            builder.Property(x => x.Amount).IsRequired();


            builder.HasQueryFilter(x => !x.IsRemoved);
        }
    }
}
