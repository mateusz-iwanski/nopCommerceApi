using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using nopCommerceApi.Entities.Usable;
using System.Reflection.Emit;

namespace nopCommerceApi.Entities.Configurations
{
    public class CategoryTemplateConfiguration : IEntityTypeConfiguration<CategoryTemplate>
    {
        public void Configure(EntityTypeBuilder<CategoryTemplate> entity)
        {
            entity.ToTable("CategoryTemplate");

            entity.Property(e => e.Name).HasMaxLength(400);
            entity.Property(e => e.ViewPath).HasMaxLength(400);
        }
    }
}
