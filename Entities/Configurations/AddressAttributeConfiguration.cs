using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace nopCommerceApi.Entities.Configurations
{
    public class AddressAttributeConfiguration : IEntityTypeConfiguration<AddressAttribute>
    {
        public void Configure(EntityTypeBuilder<AddressAttribute> builder)
        {
            builder.ToTable("AddressAttribute");
            builder.Property(e => e.Name).HasMaxLength(400);
        }
    }
}
