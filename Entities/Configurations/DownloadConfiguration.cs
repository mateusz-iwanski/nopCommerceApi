using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using nopCommerceApi.Entities.Usable;

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
