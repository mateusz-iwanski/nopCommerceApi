using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using nopCommerceApi.Entities.Usable;
using System.Reflection.Emit;

namespace nopCommerceApi.Entities.Configurations
{
    public class ProductVideoConfiguration : IEntityTypeConfiguration<ProductVideo>
    {
        public void Configure(EntityTypeBuilder<ProductVideo> entity)
        {
            entity.ToTable("ProductVideo");

            entity.HasIndex(e => e.ProductId, "IX_ProductVideo_ProductId");

            entity.HasIndex(e => e.VideoId, "IX_ProductVideo_VideoId");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductVideos)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_ProductVideo_ProductId_Product_Id");

            entity.HasOne(d => d.Video).WithMany(p => p.ProductVideos)
                .HasForeignKey(d => d.VideoId)
                .HasConstraintName("FK_ProductVideo_VideoId_Video_Id");
        }
    }
}
