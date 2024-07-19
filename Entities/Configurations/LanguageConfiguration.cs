using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using nopCommerceApi.Entities.Usable;
using System.Reflection.Emit;

namespace nopCommerceApi.Entities.Configurations
{
    public class LanguageConfiguration : IEntityTypeConfiguration<Language>
    {
        public void Configure(EntityTypeBuilder<Language> builder)
        {
            builder.ToTable("Language");

            builder.HasIndex(e => e.DisplayOrder, "IX_Language_DisplayOrder");

            builder.Property(e => e.FlagImageFileName).HasMaxLength(50);
            builder.Property(e => e.LanguageCulture).HasMaxLength(20);
            builder.Property(e => e.Name).HasMaxLength(100);
            builder.Property(e => e.UniqueSeoCode).HasMaxLength(2);
        }
    }
}
