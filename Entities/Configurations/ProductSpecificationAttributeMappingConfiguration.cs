using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using nopCommerceApi.Entities.Usable;
using System.Reflection.Emit;

namespace nopCommerceApi.Entities.Configurations
{
    public class ProductSpecificationAttributeMappingConfiguration : IEntityTypeConfiguration<ProductSpecificationAttributeMapping>
    {
        public void Configure(EntityTypeBuilder<ProductSpecificationAttributeMapping> entity)
        {
            entity.ToTable("Product_SpecificationAttribute_Mapping");

            entity.HasIndex(e => e.AllowFiltering, "IX_PSAM_AllowFiltering");

            entity.HasIndex(e => new { e.SpecificationAttributeOptionId, e.AllowFiltering }, "IX_PSAM_SpecificationAttributeOptionId_AllowFiltering");

            entity.HasIndex(e => e.ProductId, "IX_Product_SpecificationAttribute_Mapping_ProductId");

            entity.HasIndex(e => e.SpecificationAttributeOptionId, "IX_Product_SpecificationAttribute_Mapping_SpecificationAttributeOptionId");

            entity.Property(e => e.CustomValue).HasMaxLength(4000);

            entity.HasOne(d => d.Product).WithMany(p => p.ProductSpecificationAttributeMappings)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_Product_SpecificationAttribute_Mapping_ProductId_Product_Id");

            entity.HasOne(d => d.SpecificationAttributeOption).WithMany(p => p.ProductSpecificationAttributeMappings)
                .HasForeignKey(d => d.SpecificationAttributeOptionId)
                .HasConstraintName("FK_Product_SpecificationAttribute_Mapping_SpecificationAttributeOptionId_SpecificationAttributeOption_Id");

        }
    }
}
