using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using nopCommerceApi.Entities.Usable;

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
