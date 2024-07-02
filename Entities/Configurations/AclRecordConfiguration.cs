using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace nopCommerceApi.Entities.Configurations
{
    public class AclRecordConfiguration : IEntityTypeConfiguration<AclRecord>
    {
        public void Configure(EntityTypeBuilder<AclRecord> builder)
        {
            builder.ToTable("AclRecord");
            builder.HasIndex(e => e.CustomerRoleId, "IX_AclRecord_CustomerRoleId");
            builder.HasIndex(e => new { e.EntityId, e.EntityName }, "IX_AclRecord_EntityId_EntityName");
            builder.Property(e => e.EntityName).HasMaxLength(400);
            builder.HasOne(d => d.CustomerRole).WithMany(p => p.AclRecords)
                .HasForeignKey(d => d.CustomerRoleId)
                .HasConstraintName("FK_AclRecord_CustomerRoleId_CustomerRole_Id");
        }
    }
}
