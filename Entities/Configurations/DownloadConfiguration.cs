using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using nopCommerceApi.Entities.NotUsable;
using System.Reflection.Emit;

namespace nopCommerceApi.Entities.Configurations
{
    public class DownloadConfiguration : IEntityTypeConfiguration<Download>
    {
        public void Configure(EntityTypeBuilder<Download> entity)
        {
            entity.ToTable("Download");
        }
    }
}
