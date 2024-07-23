using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using nopCommerceApi.Entities.Usable;

namespace nopCommerceApi.Entities.Configurations
{
    public class ShippingMethodConfiguration : IEntityTypeConfiguration<ShippingMethod>
    {
        public void Configure(EntityTypeBuilder<ShippingMethod> entity)
        {
            entity.ToTable("ShippingMethod");

            entity.Property(e => e.Name).HasMaxLength(400);

            entity.HasMany(d => d.Countries).WithMany(p => p.ShippingMethods)
                .UsingEntity<Dictionary<string, object>>(
                    "ShippingMethodRestriction",
                    r => r.HasOne<Country>().WithMany()
                        .HasForeignKey("CountryId")
                        .HasConstraintName("FK_ShippingMethodRestrictions_Country_Id_Country_Id"),
                    l => l.HasOne<ShippingMethod>().WithMany()
                        .HasForeignKey("ShippingMethodId")
                        .HasConstraintName("FK_ShippingMethodRestrictions_ShippingMethod_Id_ShippingMethod_Id"),
                    j =>
                    {
                        j.HasKey("ShippingMethodId", "CountryId");
                        j.ToTable("ShippingMethodRestrictions");
                        j.HasIndex(new[] { "CountryId" }, "IX_ShippingMethodRestrictions_Country_Id");
                        j.HasIndex(new[] { "ShippingMethodId" }, "IX_ShippingMethodRestrictions_ShippingMethod_Id");
                        j.IndexerProperty<int>("ShippingMethodId").HasColumnName("ShippingMethod_Id");
                        j.IndexerProperty<int>("CountryId").HasColumnName("Country_Id");
                    });
        }
    }
}
