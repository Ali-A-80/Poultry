using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Poultry.Domain.Entities;

namespace Poultry.Persistance.Configuration
{
    public class FoodServiceConfiguration : IEntityTypeConfiguration<FoodService>
    {
        public void Configure(EntityTypeBuilder<FoodService> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.InsertTime).IsRequired();
            builder.Property(x => x.IsRemoved).IsRequired();
            builder.Property(x => x.FoodType).IsRequired();
            builder.Property(x => x.Amount).IsRequired();
            builder.HasQueryFilter(x => !x.IsRemoved);
        }
    }
}
