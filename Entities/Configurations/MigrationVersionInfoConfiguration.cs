using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using nopCommerceApi.Entities.Usable;

namespace nopCommerceApi.Entities.Configurations
{
    public class MigrationVersionInfoConfiguration : IEntityTypeConfiguration<MigrationVersionInfo>
    {
        public void Configure(EntityTypeBuilder<MigrationVersionInfo> entity)
        {
            entity
                .HasNoKey()
                .ToTable("MigrationVersionInfo");

            entity.HasIndex(e => e.Version, "UC_Version")
                .IsUnique()
                .IsClustered();

            entity.Property(e => e.AppliedOn).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(1024);
        }
    }
}
