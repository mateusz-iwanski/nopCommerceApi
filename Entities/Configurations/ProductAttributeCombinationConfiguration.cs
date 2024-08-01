using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using nopCommerceApi.Entities.Usable;
using System.Reflection.Emit;

namespace nopCommerceApi.Entities.Configurations
{
    public class ProductAttributeCombinationConfiguration : IEntityTypeConfiguration<ProductAttributeCombination>
    {
        public void Configure(EntityTypeBuilder<ProductAttributeCombination> entity)
        {
            entity.ToTable("ProductAttributeCombination");

            entity.HasIndex(e => e.ProductId, "IX_ProductAttributeCombination_ProductId");

            entity.Property(e => e.Gtin).HasMaxLength(400);
            entity.Property(e => e.ManufacturerPartNumber).HasMaxLength(400);
            entity.Property(e => e.OverriddenPrice).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.Sku).HasMaxLength(400);

            entity.HasOne(d => d.Product).WithMany(p => p.ProductAttributeCombinations)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_ProductAttributeCombination_ProductId_Product_Id");
        }
    }
}
