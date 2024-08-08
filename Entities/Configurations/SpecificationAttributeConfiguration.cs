using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using nopCommerceApi.Entities.Usable;
using System.Reflection.Emit;

namespace nopCommerceApi.Entities.Configurations
{
    public class SpecificationAttributeConfiguration : IEntityTypeConfiguration<SpecificationAttribute>
    {
        public void Configure(EntityTypeBuilder<SpecificationAttribute> entity)
        {
            entity.ToTable("SpecificationAttribute");

            entity.HasIndex(e => e.SpecificationAttributeGroupId, "IX_SpecificationAttribute_SpecificationAttributeGroupId");

            entity.HasOne(d => d.SpecificationAttributeGroup).WithMany(p => p.SpecificationAttributes)
                .HasForeignKey(d => d.SpecificationAttributeGroupId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_SpecificationAttribute_SpecificationAttributeGroupId_SpecificationAttributeGroup_Id");
        }
    }
}
