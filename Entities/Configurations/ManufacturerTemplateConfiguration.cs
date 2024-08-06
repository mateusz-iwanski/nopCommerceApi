using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using nopCommerceApi.Entities.Usable;
using System.Reflection.Emit;

namespace nopCommerceApi.Entities.Configurations
{
    public class ManufacturerTemplateConfiguration : IEntityTypeConfiguration<ManufacturerTemplate>
    {
        public void Configure(EntityTypeBuilder<ManufacturerTemplate> entity)
        {
            entity.ToTable("ManufacturerTemplate");

            entity.Property(e => e.Name).HasMaxLength(400);
            entity.Property(e => e.ViewPath).HasMaxLength(400);
        }
    }
}
