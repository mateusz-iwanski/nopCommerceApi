using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using nopCommerceApi.Entities.Usable;
using System.Reflection.Emit;
using nopCommerceApi.Entities.NotUsable;

namespace nopCommerceApi.Entities.Configurations
{
    public class ManufacturerConfiguration : IEntityTypeConfiguration<Manufacturer>
    {
        public void Configure(EntityTypeBuilder<Manufacturer> entity)
        {
            entity.ToTable("Manufacturer");

            entity.HasIndex(e => e.DisplayOrder, "IX_Manufacturer_DisplayOrder");

            entity.HasIndex(e => e.LimitedToStores, "IX_Manufacturer_LimitedToStores");

            entity.HasIndex(e => e.SubjectToAcl, "IX_Manufacturer_SubjectToAcl");

            entity.Property(e => e.CreatedOnUtc).HasPrecision(6);
            entity.Property(e => e.MetaKeywords).HasMaxLength(400);
            entity.Property(e => e.MetaTitle).HasMaxLength(400);
            entity.Property(e => e.Name).HasMaxLength(400);
            entity.Property(e => e.PageSizeOptions).HasMaxLength(200);
            entity.Property(e => e.PriceFrom).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.PriceTo).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.UpdatedOnUtc).HasPrecision(6);
        }
    }
}
