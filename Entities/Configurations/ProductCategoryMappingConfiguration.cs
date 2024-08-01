using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using nopCommerceApi.Entities.Usable;
using System.Reflection.Emit;

namespace nopCommerceApi.Entities.Configurations
{
    public class ProductCategoryMappingConfiguration : IEntityTypeConfiguration<ProductCategoryMapping>
    {
        public void Configure(EntityTypeBuilder<ProductCategoryMapping> entity)
        {
            entity.ToTable("Product_Category_Mapping");

            entity.HasIndex(e => new { e.ProductId, e.IsFeaturedProduct }, "IX_PCM_ProductId_Extended");

            entity.HasIndex(e => new { e.CategoryId, e.ProductId }, "IX_PCM_Product_and_Category");

            entity.HasIndex(e => e.CategoryId, "IX_Product_Category_Mapping_CategoryId");

            entity.HasIndex(e => e.IsFeaturedProduct, "IX_Product_Category_Mapping_IsFeaturedProduct");

            entity.HasIndex(e => e.ProductId, "IX_Product_Category_Mapping_ProductId");

            entity.HasOne(d => d.Category).WithMany(p => p.ProductCategoryMappings)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK_Product_Category_Mapping_CategoryId_Category_Id");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductCategoryMappings)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_Product_Category_Mapping_ProductId_Product_Id");
        }
    }
}
