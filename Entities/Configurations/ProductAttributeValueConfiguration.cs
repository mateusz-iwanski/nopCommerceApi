using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using nopCommerceApi.Entities.NotUsable;
using System.Reflection.Emit;

namespace nopCommerceApi.Entities.Configurations
{
    public class ProductAttributeValueConfiguration : IEntityTypeConfiguration<ProductAttributeValue>
    {
        public void Configure(EntityTypeBuilder<ProductAttributeValue> entity)
        {
            entity.ToTable("ProductAttributeValue");

            entity.HasIndex(e => e.ProductAttributeMappingId, "IX_ProductAttributeValue_ProductAttributeMappingId");

            entity.HasIndex(e => new { e.ProductAttributeMappingId, e.DisplayOrder }, "IX_ProductAttributeValue_ProductAttributeMappingId_DisplayOrder");

            entity.Property(e => e.ColorSquaresRgb).HasMaxLength(100);
            entity.Property(e => e.Cost).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.Name).HasMaxLength(400);
            entity.Property(e => e.PriceAdjustment).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.WeightAdjustment).HasColumnType("decimal(18, 4)");

            entity.HasOne(d => d.ProductAttributeMapping).WithMany(p => p.ProductAttributeValues)
                .HasForeignKey(d => d.ProductAttributeMappingId)
                .HasConstraintName("FK_ProductAttributeValue_ProductAttributeMappingId_Product_ProductAttribute_Mapping_Id");
        }
    }
}
