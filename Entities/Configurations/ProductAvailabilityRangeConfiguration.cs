using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using nopCommerceApi.Entities.Usable;
using System.Reflection.Emit;

namespace nopCommerceApi.Entities.Configurations
{
    public class ProductAvailabilityRangeConfiguration : IEntityTypeConfiguration<ProductAvailabilityRange>
    {
        public void Configure(EntityTypeBuilder<ProductAvailabilityRange> entity)
        {
            entity.ToTable("ProductAvailabilityRange");

            entity.Property(e => e.Name).HasMaxLength(400);
        }
    }
}
