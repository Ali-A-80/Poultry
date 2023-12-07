using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Poultry.Domain.Entities;

namespace Poultry.Persistance.Configuration
{
    public class ChickenConfiguration : IEntityTypeConfiguration<Chicken>
    {
        public void Configure(EntityTypeBuilder<Chicken> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.InsertTime).IsRequired();
            builder.Property(x => x.IsRemoved).IsRequired();
            builder.Property(x => x.Gender).IsRequired();
            builder.Property(x => x.Age).IsRequired();
            builder.Property(x => x.ChickenType).IsRequired();
            builder.Property(x => x.Weight).IsRequired();
            builder.Property(x => x.LayingRate).IsRequired();

            builder.HasQueryFilter(x => !x.IsRemoved);
        }
    }
}
