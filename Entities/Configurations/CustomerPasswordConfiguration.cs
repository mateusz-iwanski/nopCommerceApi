using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using nopCommerceApi.Entities.Usable;

namespace nopCommerceApi.Entities.Configurations
{
    public class CustomerPasswordConfiguration : IEntityTypeConfiguration<CustomerPassword>
    {
        public void Configure(EntityTypeBuilder<CustomerPassword> builder)
        {
            builder.ToTable("CustomerPassword");

            builder.HasIndex(e => e.CustomerId, "IX_CustomerPassword_CustomerId");

            builder.Property(e => e.CreatedOnUtc).HasPrecision(6);

            builder.HasOne(d => d.Customer).WithMany(p => p.CustomerPasswords)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_CustomerPassword_CustomerId_Customer_Id");
        }
    }
}
