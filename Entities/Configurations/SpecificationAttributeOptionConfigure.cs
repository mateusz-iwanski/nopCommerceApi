using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using nopCommerceApi.Entities.Usable;
using System.Reflection.Emit;

namespace nopCommerceApi.Entities.Configurations
{
    public class SpecificationAttributeOptionConfigure : IEntityTypeConfiguration<SpecificationAttributeOption>
    {
        public void Configure(EntityTypeBuilder<SpecificationAttributeOption> entity)
        {
            entity.ToTable("SpecificationAttributeOption");

            entity.HasIndex(e => e.SpecificationAttributeId, "IX_SpecificationAttributeOption_SpecificationAttributeId");

            entity.Property(e => e.ColorSquaresRgb).HasMaxLength(100);

            entity.HasOne(d => d.SpecificationAttribute).WithMany(p => p.SpecificationAttributeOptions)
                .HasForeignKey(d => d.SpecificationAttributeId)
                .HasConstraintName("FK_SpecificationAttributeOption_SpecificationAttributeId_SpecificationAttribute_Id");
        }
    }
}
