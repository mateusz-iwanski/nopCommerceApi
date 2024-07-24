using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using nopCommerceApi.Entities.Usable;
using System.Reflection.Emit;

namespace nopCommerceApi.Entities.Configurations
{
    public class ProductTemplateConfiguration : IEntityTypeConfiguration<ProductTemplate>
    {
        public void Configure(EntityTypeBuilder<ProductTemplate> entity)
        {
            entity.ToTable("ProductTemplate");

            entity.Property(e => e.Name).HasMaxLength(400);
            entity.Property(e => e.ViewPath).HasMaxLength(400);
        }
    }
}
