using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using nopCommerceApi.Entities.Usable;
using System.Reflection.Emit;

namespace nopCommerceApi.Entities.Configurations
{
    public class SpecificationAttributeGroupConfiguration : IEntityTypeConfiguration<SpecificationAttributeGroup>
    {
        public void Configure(EntityTypeBuilder<SpecificationAttributeGroup> builder)
        {
            builder.ToTable("SpecificationAttributeGroup");
        }
    }
}
