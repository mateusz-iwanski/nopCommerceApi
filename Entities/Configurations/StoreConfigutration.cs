using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using nopCommerceApi.Entities.Usable;

namespace nopCommerceApi.Entities.Configurations
{
    public class StoreConfigutration : IEntityTypeConfiguration<Store>
    {

        public void Configure(EntityTypeBuilder<Store> entity)
        {
            entity.ToTable("Store");

            entity.Property(e => e.CompanyAddress).HasMaxLength(1000);
            entity.Property(e => e.CompanyName).HasMaxLength(1000);
            entity.Property(e => e.CompanyPhoneNumber).HasMaxLength(1000);
            entity.Property(e => e.CompanyVat).HasMaxLength(1000);
            entity.Property(e => e.Hosts).HasMaxLength(1000);
            entity.Property(e => e.Name).HasMaxLength(400);
            entity.Property(e => e.Url).HasMaxLength(400);
        }
    }
}
