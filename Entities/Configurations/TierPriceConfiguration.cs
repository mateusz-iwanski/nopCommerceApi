using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using nopCommerceApi.Entities.Usable;

namespace nopCommerceApi.Entities.Configurations
{
    public class TierPriceConfiguration : IEntityTypeConfiguration<TierPrice>
    {
        public void Configure(EntityTypeBuilder<TierPrice> builder)
        {
            builder.ToTable("TierPrice");

            builder.HasIndex(e => e.CustomerRoleId, "IX_TierPrice_CustomerRoleId");

            builder.HasIndex(e => e.ProductId, "IX_TierPrice_ProductId");

            builder.Property(e => e.EndDateTimeUtc).HasPrecision(6);
            builder.Property(e => e.Price).HasColumnType("decimal(18, 4)");
            builder.Property(e => e.StartDateTimeUtc).HasPrecision(6);

            builder.HasOne(d => d.CustomerRole).WithMany(p => p.TierPrices)
                .HasForeignKey(d => d.CustomerRoleId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_TierPrice_CustomerRoleId_CustomerRole_Id");

            builder.HasOne(d => d.Product).WithMany(p => p.TierPrices)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_TierPrice_ProductId_Product_Id");
        }
    }
}
