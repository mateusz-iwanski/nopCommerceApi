using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using nopCommerceApi.Entities.Usable;
using System.Reflection.Emit;

namespace nopCommerceApi.Entities.Configurations
{
    public class ForumsPrivateMessageConfiguration : IEntityTypeConfiguration<ForumsPrivateMessage>
    {
        public void Configure(EntityTypeBuilder<ForumsPrivateMessage> entity)
        {
            entity.ToTable("Forums_PrivateMessage");

            entity.HasIndex(e => e.FromCustomerId, "IX_Forums_PrivateMessage_FromCustomerId");

            entity.HasIndex(e => e.ToCustomerId, "IX_Forums_PrivateMessage_ToCustomerId");

            entity.Property(e => e.CreatedOnUtc).HasPrecision(6);
            entity.Property(e => e.Subject).HasMaxLength(450);

            entity.HasOne(d => d.FromCustomer).WithMany(p => p.ForumsPrivateMessageFromCustomers)
                .HasForeignKey(d => d.FromCustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Forums_PrivateMessage_FromCustomerId_Customer_Id");

            entity.HasOne(d => d.ToCustomer).WithMany(p => p.ForumsPrivateMessageToCustomers)
                .HasForeignKey(d => d.ToCustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Forums_PrivateMessage_ToCustomerId_Customer_Id");
        }
    }
}
