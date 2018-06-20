using AC.Suafigurinha.IO.Infra.Data.Extensions;
using AC.Suafigurinha.IO.Domain.Galleries;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace AC.Suafigurinha.IO.Infra.Data.Mappings
{
    public class GalleryMapping : EntityTypeConfiguration<Gallery>
    {
        public override void Map(EntityTypeBuilder<Gallery> builder)
        {
            builder.Property(g => g.Id)
               .HasColumnName("IdGallery")
               .IsRequired();

            builder.Property(g => g.Name)
                .HasColumnType("VARCHAR(100)")
                .IsRequired();

            builder.HasMany(g => g.Images)
                .WithOne(i => i.Gallery)
                .IsRequired();

            builder.HasOne(g => g.Product)
                .WithOne(p => p.Gallery)
                .IsRequired(false);

            builder.Ignore(g => g.ValidationResult);

            builder.Ignore(g => g.CascadeMode);

            builder.ToTable("Galleries");
        }
    }
}
