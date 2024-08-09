using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using nopCommerceApi.Entities.Usable;
using System.Reflection.Emit;

namespace nopCommerceApi.Entities.Configurations
{
    public class VideoConfiguration : IEntityTypeConfiguration<Video>
    {
        public void Configure(EntityTypeBuilder<Video> entity)
        {
            entity.ToTable("Video");

            entity.Property(e => e.VideoUrl).HasMaxLength(1000);
        }
    }
}
