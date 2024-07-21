using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using nopCommerceApi.Entities.Usable;
using System.Reflection.Emit;

namespace nopCommerceApi.Entities.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");

            builder.HasIndex(e => new { e.Deleted, e.VendorId, e.ProductTypeId, e.ManageInventoryMethodId, e.MinStockQuantity, e.UseMultipleWarehouses }, "IX_GetLowStockProducts");

            builder.HasIndex(e => new { e.Deleted, e.Id }, "IX_Product_Delete_Id");

            builder.HasIndex(e => new { e.Published, e.Deleted }, "IX_Product_Deleted_and_Published");

            builder.HasIndex(e => e.LimitedToStores, "IX_Product_LimitedToStores");

            builder.HasIndex(e => e.Name, "IX_Product_Name");

            builder.HasIndex(e => e.ParentGroupedProductId, "IX_Product_ParentGroupedProductId");

            builder.HasIndex(e => new { e.Price, e.AvailableStartDateTimeUtc, e.AvailableEndDateTimeUtc, e.Published, e.Deleted }, "IX_Product_PriceDatesEtc");

            builder.HasIndex(e => e.Published, "IX_Product_Published");

            builder.HasIndex(e => e.ShowOnHomepage, "IX_Product_ShowOnHomepage");

            builder.HasIndex(e => e.SubjectToAcl, "IX_Product_SubjectToAcl");

            builder.HasIndex(e => e.VisibleIndividually, "IX_Product_VisibleIndividually");

            builder.HasIndex(e => new { e.VisibleIndividually, e.Published, e.Deleted }, "IX_Product_VisibleIndividually_Published_Deleted_Extended");

            builder.Property(e => e.AdditionalShippingCharge).HasColumnType("decimal(18, 4)");
            builder.Property(e => e.AllowedQuantities).HasMaxLength(1000);
            builder.Property(e => e.AvailableEndDateTimeUtc).HasPrecision(6);
            builder.Property(e => e.AvailableStartDateTimeUtc).HasPrecision(6);
            builder.Property(e => e.BasepriceAmount).HasColumnType("decimal(18, 4)");
            builder.Property(e => e.BasepriceBaseAmount).HasColumnType("decimal(18, 4)");
            builder.Property(e => e.CreatedOnUtc).HasPrecision(6);
            builder.Property(e => e.Gtin).HasMaxLength(400);
            builder.Property(e => e.Height).HasColumnType("decimal(18, 4)");
            builder.Property(e => e.Length).HasColumnType("decimal(18, 4)");
            builder.Property(e => e.ManufacturerPartNumber).HasMaxLength(400);
            builder.Property(e => e.MarkAsNewEndDateTimeUtc).HasPrecision(6);
            builder.Property(e => e.MarkAsNewStartDateTimeUtc).HasPrecision(6);
            builder.Property(e => e.MaximumCustomerEnteredPrice).HasColumnType("decimal(18, 4)");
            builder.Property(e => e.MetaKeywords).HasMaxLength(400);
            builder.Property(e => e.MetaTitle).HasMaxLength(400);
            builder.Property(e => e.MinimumCustomerEnteredPrice).HasColumnType("decimal(18, 4)");
            builder.Property(e => e.Name).HasMaxLength(400);
            builder.Property(e => e.OldPrice).HasColumnType("decimal(18, 4)");
            builder.Property(e => e.OverriddenGiftCardAmount).HasColumnType("decimal(18, 4)");
            builder.Property(e => e.PreOrderAvailabilityStartDateTimeUtc).HasPrecision(6);
            builder.Property(e => e.Price).HasColumnType("decimal(18, 4)");
            builder.Property(e => e.ProductCost).HasColumnType("decimal(18, 4)");
            builder.Property(e => e.RequiredProductIds).HasMaxLength(1000);
            builder.Property(e => e.Sku).HasMaxLength(400);
            builder.Property(e => e.UpdatedOnUtc).HasPrecision(6);
            builder.Property(e => e.Weight).HasColumnType("decimal(18, 4)");
            builder.Property(e => e.Width).HasColumnType("decimal(18, 4)");

            builder.HasMany(d => d.ProductTags).WithMany(p => p.Products)
                .UsingEntity<Dictionary<string, object>>(
                    "ProductProductTagMapping",
                    r => r.HasOne<ProductTag>().WithMany()
                        .HasForeignKey("ProductTagId")
                        .HasConstraintName("FK_Product_ProductTag_Mapping_ProductTag_Id_ProductTag_Id"),
                    l => l.HasOne<Product>().WithMany()
                        .HasForeignKey("ProductId")
                        .HasConstraintName("FK_Product_ProductTag_Mapping_Product_Id_Product_Id"),
                    j =>
                    {
                        j.HasKey("ProductId", "ProductTagId");
                        j.ToTable("Product_ProductTag_Mapping");
                        j.HasIndex(new[] { "ProductTagId" }, "IX_Product_ProductTag_Mapping_ProductTag_Id");
                        j.HasIndex(new[] { "ProductId" }, "IX_Product_ProductTag_Mapping_Product_Id");
                        j.IndexerProperty<int>("ProductId").HasColumnName("Product_Id");
                        j.IndexerProperty<int>("ProductTagId").HasColumnName("ProductTag_Id");
                    });
        }
    }
}
