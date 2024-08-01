using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using nopCommerceApi.Entities.Usable;
using System.Reflection.Emit;

namespace nopCommerceApi.Entities.Configurations
{
    public class PictureConfiguration : IEntityTypeConfiguration<Picture>
    {
        public void Configure(EntityTypeBuilder<Picture> entity)
        {
            entity.ToTable("Picture");

            entity.Property(e => e.MimeType).HasMaxLength(40);
            entity.Property(e => e.SeoFilename).HasMaxLength(300);
        }
    }
}
