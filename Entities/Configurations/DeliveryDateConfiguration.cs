using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using nopCommerceApi.Entities.Usable;

namespace nopCommerceApi.Entities.Configurations
{
    public class DeliveryDateConfiguration : IEntityTypeConfiguration<DeliveryDate>
    {
        public void Configure(EntityTypeBuilder<DeliveryDate> entity)
        {
            entity.ToTable("DeliveryDate");

            entity.Property(e => e.Name).HasMaxLength(400);
        }
    }
}
