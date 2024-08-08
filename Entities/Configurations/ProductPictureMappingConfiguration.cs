using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using nopCommerceApi.Entities.Usable;
using System.Reflection.Emit;
using nopCommerceApi.Entities.NotUsable;

namespace nopCommerceApi.Entities.Configurations
{
    public class ProductPictureMappingConfiguration : IEntityTypeConfiguration<ProductPictureMapping>
    {
        public void Configure(EntityTypeBuilder<ProductPictureMapping> entity)
        {
            entity.ToTable("Product_Picture_Mapping");

            entity.HasIndex(e => e.PictureId, "IX_Product_Picture_Mapping_PictureId");

            entity.HasIndex(e => e.ProductId, "IX_Product_Picture_Mapping_ProductId");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductPictureMappings)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_Product_Picture_Mapping_ProductId_Product_Id");
        }
    }
}
