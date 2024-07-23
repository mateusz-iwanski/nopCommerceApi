using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using nopCommerceApi.Entities.Usable;
using System.Reflection.Emit;

namespace nopCommerceApi.Entities.Configurations
{
    public class AffiliateConfiguration : IEntityTypeConfiguration<Affiliate>
    {
        public void Configure(EntityTypeBuilder<Affiliate> entity)
        {
            entity.ToTable("Affiliate");

            entity.HasIndex(e => e.AddressId, "IX_Affiliate_AddressId");

            entity.HasOne(d => d.Address).WithMany(p => p.Affiliates)
                .HasForeignKey(d => d.AddressId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Affiliate_AddressId_Address_Id");
        }
    }
}
