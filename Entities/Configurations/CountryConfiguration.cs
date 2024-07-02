using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace nopCommerceApi.Entities.Configurations
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.ToTable("Country");
            builder.HasIndex(e => e.DisplayOrder, "IX_Country_DisplayOrder");
            builder.Property(e => e.Name).HasMaxLength(100);
            builder.Property(e => e.ThreeLetterIsoCode).HasMaxLength(3);
            builder.Property(e => e.TwoLetterIsoCode).HasMaxLength(2);
        }
    }
}
