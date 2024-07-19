using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using nopCommerceApi.Entities.Usable;

namespace nopCommerceApi.Entities.Configurations
{
    public class TaxCategoryConfiguration : IEntityTypeConfiguration<TaxCategory>
    {
        public void Configure(EntityTypeBuilder<TaxCategory> builder)
        {
            builder.ToTable("TaxCategory");

            builder.Property(e => e.Name).HasMaxLength(400);
        }
    }
}
