using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using nopCommerceApi.Entities.Usable;
using System.Reflection.Emit;

namespace nopCommerceApi.Entities.Configurations
{

    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {

        public void Configure(EntityTypeBuilder<Order> entity)
        {
            entity.ToTable("Order");

            entity.HasIndex(e => e.BillingAddressId, "IX_Order_BillingAddressId");

            entity.HasIndex(e => e.CreatedOnUtc, "IX_Order_CreatedOnUtc").IsDescending();

            entity.HasIndex(e => e.CustomerId, "IX_Order_CustomerId");

            entity.HasIndex(e => e.PickupAddressId, "IX_Order_PickupAddressId");

            entity.HasIndex(e => e.ShippingAddressId, "IX_Order_ShippingAddressId");

            entity.Property(e => e.CreatedOnUtc).HasPrecision(6);
            entity.Property(e => e.CurrencyRate).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.CustomerIp).HasMaxLength(100);
            entity.Property(e => e.OrderDiscount).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.OrderShippingExclTax).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.OrderShippingInclTax).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.OrderSubTotalDiscountExclTax).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.OrderSubTotalDiscountInclTax).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.OrderSubtotalExclTax).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.OrderSubtotalInclTax).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.OrderTax).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.OrderTotal).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.PaidDateUtc).HasPrecision(6);
            entity.Property(e => e.PaymentMethodAdditionalFeeExclTax).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.PaymentMethodAdditionalFeeInclTax).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.RefundedAmount).HasColumnType("decimal(18, 4)");

            entity.HasOne(d => d.BillingAddress).WithMany(p => p.OrderBillingAddresses)
                .HasForeignKey(d => d.BillingAddressId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_BillingAddressId_Address_Id");

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_CustomerId_Customer_Id");

            entity.HasOne(d => d.PickupAddress).WithMany(p => p.OrderPickupAddresses)
                .HasForeignKey(d => d.PickupAddressId)
                .HasConstraintName("FK_Order_PickupAddressId_Address_Id");

            entity.HasOne(d => d.RewardPointsHistoryEntry).WithMany(p => p.Orders)
                .HasForeignKey(d => d.RewardPointsHistoryEntryId)
                .HasConstraintName("FK_Order_RewardPointsHistoryEntryId_RewardPointsHistory_Id");

            entity.HasOne(d => d.ShippingAddress).WithMany(p => p.OrderShippingAddresses)
                .HasForeignKey(d => d.ShippingAddressId)
                .HasConstraintName("FK_Order_ShippingAddressId_Address_Id");
        }
    }
}
