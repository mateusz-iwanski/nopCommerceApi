using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using nopCommerceApi.Entities.Usable;
using nopCommerceApi.Entities.NotUsable;
using System.Reflection.Emit;

namespace nopCommerceApi.Entities.Configurations
{
    public class VendorConfiguration : IEntityTypeConfiguration<Vendor>
    {
        public void Configure(EntityTypeBuilder<Vendor> entity)
        {
            entity.ToTable("Vendor");

            entity.Property(e => e.Email).HasMaxLength(400);
            entity.Property(e => e.MetaKeywords).HasMaxLength(400);
            entity.Property(e => e.MetaTitle).HasMaxLength(400);
            entity.Property(e => e.Name).HasMaxLength(400);
            entity.Property(e => e.PageSizeOptions).HasMaxLength(200);
            entity.Property(e => e.PriceFrom).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.PriceTo).HasColumnType("decimal(18, 4)");
        }
    }
}
