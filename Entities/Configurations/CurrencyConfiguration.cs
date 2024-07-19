using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using nopCommerceApi.Entities.Usable;

namespace nopCommerceApi.Entities.Configurations
{
    public class CurrencyConfiguration : IEntityTypeConfiguration<Currency>
    {
        public void Configure(EntityTypeBuilder<Currency> builder)
        {
            builder.ToTable("Currency");

            builder.HasIndex(e => e.DisplayOrder, "IX_Currency_DisplayOrder");

            builder.Property(e => e.CreatedOnUtc).HasPrecision(6);
            builder.Property(e => e.CurrencyCode).HasMaxLength(5);
            builder.Property(e => e.CustomFormatting).HasMaxLength(50);
            builder.Property(e => e.DisplayLocale).HasMaxLength(50);
            builder.Property(e => e.Name).HasMaxLength(50);
            builder.Property(e => e.Rate).HasColumnType("decimal(18, 4)");
            builder.Property(e => e.UpdatedOnUtc).HasPrecision(6);
        }
    }
}
