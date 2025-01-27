using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using nopCommerceApi.Entities.Usable;

namespace nopCommerceApi.Entities.Configurations
{
    public class PictureBinaryConfiguration : IEntityTypeConfiguration<PictureBinary>
    {
        public void Configure(EntityTypeBuilder<PictureBinary> builder)
        {
            builder.ToTable("PictureBinary");

            builder.HasKey(pb => pb.Id)
                   .HasName("PK_PictureBinary");

            builder.Property(pb => pb.Id)
                   .ValueGeneratedOnAdd();

            builder.Property(pb => pb.PictureId)
                   .IsRequired();

            builder.Property(pb => pb.BinaryData)
                   .HasColumnType("varbinary(max)");

            builder.HasIndex(pb => pb.Id)
                   .IsUnique();
        }
    }
}
