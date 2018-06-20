using AC.Suafigurinha.IO.Domain.Images;
using AC.Suafigurinha.IO.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AC.Suafigurinha.IO.Infra.Data.Mappings
{
    public class ImageMapping : EntityTypeConfiguration<Image>
    {
        public override void Map(EntityTypeBuilder<Image> builder)
        {
            builder.Property(i => i.Id)
               .HasColumnName("IdImage")
               .IsRequired();

            builder.Property(i => i.Url)
                .HasColumnType("VARCHAR(255)")
                .IsRequired();

            builder.Property(i => i.Order)
                .HasDefaultValue(0);

            builder.Property(i => i.Deleted)
                .HasDefaultValue(false);

            builder.HasOne(i => i.Gallery)
                .WithMany(g => g.Images)
                .HasForeignKey(i => i.IdGallery)
                .IsRequired(false);

            builder.HasOne(i => i.Product)
                .WithOne(p => p.ThumbNail)
                .IsRequired(false);

            builder.Ignore(i => i.ValidationResult);

            builder.Ignore(i => i.CascadeMode);

            builder.ToTable("Images");
        }
    }
}
