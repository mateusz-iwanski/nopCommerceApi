using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using nopCommerceApi.Entities.Usable;

namespace nopCommerceApi.Entities.Configurations
{
    public class StateProvinceConfiguration : IEntityTypeConfiguration<StateProvince>
    {
        public void Configure(EntityTypeBuilder<StateProvince> builder)
        {
            builder.ToTable("StateProvince");

            builder.HasIndex(e => e.CountryId, "IX_StateProvince_CountryId");

            builder.Property(e => e.Abbreviation).HasMaxLength(100);
            builder.Property(e => e.Name).HasMaxLength(100);

            builder.HasOne(d => d.Country).WithMany(p => p.StateProvinces)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("FK_StateProvince_CountryId_Country_Id");
        }
    }
}
