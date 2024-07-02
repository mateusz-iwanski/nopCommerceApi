using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace nopCommerceApi.Entities.Configurations
{
    public class CustomerRoleConfiguration : IEntityTypeConfiguration<CustomerRole>
    {
        public void Configure(EntityTypeBuilder<CustomerRole> builder)
        {
            builder.ToTable("CustomerRole");

            builder.Property(e => e.Name).HasMaxLength(255);
            builder.Property(e => e.SystemName).HasMaxLength(255);
        }
    }
}
