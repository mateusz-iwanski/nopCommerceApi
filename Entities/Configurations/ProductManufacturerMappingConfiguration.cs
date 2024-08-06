using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using nopCommerceApi.Entities.Usable;
using System.Reflection.Emit;

namespace nopCommerceApi.Entities.Configurations
{
    public class ProductManufacturerMappingConfiguration : IEntityTypeConfiguration<ProductManufacturerMapping>
    {
        public void Configure(EntityTypeBuilder<ProductManufacturerMapping> entity)
        {
            entity.ToTable("Product_Manufacturer_Mapping");

            entity.HasIndex(e => new { e.ProductId, e.IsFeaturedProduct }, "IX_PMM_ProductId_Extended");

            entity.HasIndex(e => new { e.ManufacturerId, e.ProductId }, "IX_PMM_Product_and_Manufacturer");

            entity.HasIndex(e => e.IsFeaturedProduct, "IX_Product_Manufacturer_Mapping_IsFeaturedProduct");

            entity.HasIndex(e => e.ManufacturerId, "IX_Product_Manufacturer_Mapping_ManufacturerId");

            entity.HasIndex(e => e.ProductId, "IX_Product_Manufacturer_Mapping_ProductId");

            entity.HasOne(d => d.Manufacturer).WithMany(p => p.ProductManufacturerMappings)
                .HasForeignKey(d => d.ManufacturerId)
                .HasConstraintName("FK_Product_Manufacturer_Mapping_ManufacturerId_Manufacturer_Id");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductManufacturerMappings)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_Product_Manufacturer_Mapping_ProductId_Product_Id"); 
        }
    }
}
