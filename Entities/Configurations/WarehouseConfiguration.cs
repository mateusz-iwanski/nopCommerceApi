using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using nopCommerceApi.Entities.NotUsable;

namespace nopCommerceApi.Entities.Configurations
{
    public class WarehouseConfiguration : IEntityTypeConfiguration<Warehouse>
    {
        public void Configure(EntityTypeBuilder<Warehouse> entity)
        {
            entity.ToTable("Warehouse");

            entity.Property(e => e.Name).HasMaxLength(400);
        }
    }
}
