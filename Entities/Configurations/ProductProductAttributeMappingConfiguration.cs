using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using nopCommerceApi.Entities.Usable;
using nopCommerceApi.Entities.NotUsable;

namespace nopCommerceApi.Entities.Configurations
{
    public class ProductProductAttributeMappingConfiguration : IEntityTypeConfiguration<ProductProductAttributeMapping>
    {
        public void Configure(EntityTypeBuilder<ProductProductAttributeMapping> entity)
        {
            entity.ToTable("Product_ProductAttribute_Mapping");

            entity.HasIndex(e => e.ProductAttributeId, "IX_Product_ProductAttribute_Mapping_ProductAttributeId");

            entity.HasIndex(e => e.ProductId, "IX_Product_ProductAttribute_Mapping_ProductId");

            entity.HasIndex(e => new { e.ProductId, e.DisplayOrder }, "IX_Product_ProductAttribute_Mapping_ProductId_DisplayOrder");

            entity.HasOne(d => d.ProductAttribute).WithMany(p => p.ProductProductAttributeMappings)
                .HasForeignKey(d => d.ProductAttributeId)
                .HasConstraintName("FK_Product_ProductAttribute_Mapping_ProductAttributeId_ProductAttribute_Id");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductProductAttributeMappings)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_Product_ProductAttribute_Mapping_ProductId_Product_Id");
        }
    }
}
