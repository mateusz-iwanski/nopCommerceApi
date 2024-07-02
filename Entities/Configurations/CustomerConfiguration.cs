using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace nopCommerceApi.Entities.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customer");

            builder.HasIndex(e => e.BillingAddressId, "IX_Customer_BillingAddress_Id");

            builder.HasIndex(e => e.CreatedOnUtc, "IX_Customer_CreatedOnUtc").IsDescending();

            builder.HasIndex(e => e.CurrencyId, "IX_Customer_CurrencyId");

            builder.HasIndex(e => e.CustomerGuid, "IX_Customer_CustomerGuid");

            builder.HasIndex(e => e.Email, "IX_Customer_Email");

            builder.HasIndex(e => e.LanguageId, "IX_Customer_LanguageId");

            builder.HasIndex(e => e.ShippingAddressId, "IX_Customer_ShippingAddress_Id");

            builder.HasIndex(e => e.SystemName, "IX_Customer_SystemName");

            builder.HasIndex(e => e.Username, "IX_Customer_Username");

            builder.Property(e => e.BillingAddressId).HasColumnName("BillingAddress_Id");
            builder.Property(e => e.CannotLoginUntilDateUtc).HasPrecision(6);
            builder.Property(e => e.City).HasMaxLength(1000);
            builder.Property(e => e.Company).HasMaxLength(1000);
            builder.Property(e => e.County).HasMaxLength(1000);
            builder.Property(e => e.CreatedOnUtc).HasPrecision(6);
            builder.Property(e => e.CustomCustomerAttributesXml).HasColumnName("CustomCustomerAttributesXML");
            builder.Property(e => e.Email).HasMaxLength(1000);
            builder.Property(e => e.EmailToRevalidate).HasMaxLength(1000);
            builder.Property(e => e.Fax).HasMaxLength(1000);
            builder.Property(e => e.FirstName).HasMaxLength(1000);
            builder.Property(e => e.Gender).HasMaxLength(1000);
            builder.Property(e => e.LastActivityDateUtc).HasPrecision(6);
            builder.Property(e => e.LastIpAddress).HasMaxLength(100);
            builder.Property(e => e.LastLoginDateUtc).HasPrecision(6);
            builder.Property(e => e.LastName).HasMaxLength(1000);
            builder.Property(e => e.Phone).HasMaxLength(1000);
            builder.Property(e => e.ShippingAddressId).HasColumnName("ShippingAddress_Id");
            builder.Property(e => e.StreetAddress).HasMaxLength(1000);
            builder.Property(e => e.StreetAddress2).HasMaxLength(1000);
            builder.Property(e => e.SystemName).HasMaxLength(400);
            builder.Property(e => e.TimeZoneId).HasMaxLength(1000);
            builder.Property(e => e.Username).HasMaxLength(1000);
            builder.Property(e => e.VatNumber).HasMaxLength(1000);
            builder.Property(e => e.ZipPostalCode).HasMaxLength(1000);

            builder.HasOne(d => d.BillingAddress).WithMany(p => p.CustomerBillingAddresses)
                .HasForeignKey(d => d.BillingAddressId)
                .HasConstraintName("FK_Customer_BillingAddress_Id_Address_Id");

            builder.HasOne(d => d.Currency).WithMany(p => p.Customers)
                .HasForeignKey(d => d.CurrencyId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_Customer_CurrencyId_Currency_Id");

            builder.HasOne(d => d.Language).WithMany(p => p.Customers)
                .HasForeignKey(d => d.LanguageId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_Customer_LanguageId_Language_Id");

            builder.HasOne(d => d.ShippingAddress).WithMany(p => p.CustomerShippingAddresses)
                .HasForeignKey(d => d.ShippingAddressId)
                .HasConstraintName("FK_Customer_ShippingAddress_Id_Address_Id");

            builder.HasMany(d => d.CustomerRoles).WithMany(p => p.Customers)
                .UsingEntity<Dictionary<string, object>>(
                    "CustomerCustomerRoleMapping",
                    r => r.HasOne<CustomerRole>().WithMany()
                        .HasForeignKey("CustomerRoleId")
                        .HasConstraintName("FK_Customer_CustomerRole_Mapping_CustomerRole_Id_CustomerRole_Id"),
                    l => l.HasOne<Customer>().WithMany()
                        .HasForeignKey("CustomerId")
                        .HasConstraintName("FK_Customer_CustomerRole_Mapping_Customer_Id_Customer_Id"),
                    j =>
                    {
                        j.HasKey("CustomerId", "CustomerRoleId");
                        j.ToTable("Customer_CustomerRole_Mapping");
                        j.HasIndex(new[] { "CustomerRoleId" }, "IX_Customer_CustomerRole_Mapping_CustomerRole_Id");
                        j.HasIndex(new[] { "CustomerId" }, "IX_Customer_CustomerRole_Mapping_Customer_Id");
                        j.IndexerProperty<int>("CustomerId").HasColumnName("Customer_Id");
                        j.IndexerProperty<int>("CustomerRoleId").HasColumnName("CustomerRole_Id");
                    });

            builder.HasOne(c => c.Country)
               .WithMany(c => c.Customers)
               .HasForeignKey(c => c.CountryId)
               .IsRequired(false);

            builder.HasOne(c => c.StateProvince)
                .WithMany(c => c.Customers)
                .HasForeignKey(c => c.StateProvinceId)
                .IsRequired(false);

            builder.HasOne(c => c.Currency)
                .WithMany(c => c.Customers)
                .HasForeignKey(c => c.CurrencyId)
                .IsRequired(false);
        }
    }
}
