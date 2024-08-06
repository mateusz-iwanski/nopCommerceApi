using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using nopCommerceApi.Entities.Usable;
using System.Reflection.Emit;

namespace nopCommerceApi.Entities.Configurations
{
    public class UrlRecordConfiguration : IEntityTypeConfiguration<UrlRecord>
    {
        public void Configure(EntityTypeBuilder<UrlRecord> entity)
        {
            entity.ToTable("UrlRecord");

            entity.HasIndex(e => new { e.EntityId, e.EntityName, e.LanguageId, e.IsActive }, "IX_UrlRecord_Custom_1");

            entity.HasIndex(e => e.Slug, "IX_UrlRecord_Slug");

            entity.Property(e => e.EntityName).HasMaxLength(400);
            entity.Property(e => e.Slug).HasMaxLength(400);
        }
    }
}
