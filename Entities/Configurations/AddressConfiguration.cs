using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace nopCommerceApi.Entities.Configurations
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Address");
            builder.HasIndex(e => e.CountryId, "IX_Address_CountryId");
            builder.HasIndex(e => e.StateProvinceId, "IX_Address_StateProvinceId");
            builder.Property(e => e.CreatedOnUtc).HasPrecision(6);
            builder.HasOne(d => d.Country).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("FK_Address_CountryId_Country_Id");
            builder.HasOne(d => d.StateProvince).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.StateProvinceId)
                .HasConstraintName("FK_Address_StateProvinceId_StateProvince_Id");
            builder.HasMany(d => d.Customers).WithMany(p => p.Addresses)
                .UsingEntity<Dictionary<string, object>>(
                    "CustomerAddress",
                    r => r.HasOne<Customer>().WithMany()
                        .HasForeignKey("CustomerId")
                        .HasConstraintName("FK_CustomerAddresses_Customer_Id_Customer_Id"),
                    l => l.HasOne<Address>().WithMany()
                        .HasForeignKey("AddressId")
                        .HasConstraintName("FK_CustomerAddresses_Address_Id_Address_Id"),
                    j =>
                    {
                        j.HasKey("AddressId", "CustomerId");
                        j.ToTable("CustomerAddresses");
                        j.HasIndex(new[] { "AddressId" }, "IX_CustomerAddresses_Address_Id");
                        j.HasIndex(new[] { "CustomerId" }, "IX_CustomerAddresses_Customer_Id");
                        j.IndexerProperty<int>("AddressId").HasColumnName("Address_Id");
                        j.IndexerProperty<int>("CustomerId").HasColumnName("Customer_Id");
                    });
        }
    }
}
