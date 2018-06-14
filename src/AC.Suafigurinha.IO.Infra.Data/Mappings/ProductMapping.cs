
using AC.Suafigurinha.IO.Domain.Products;
using AC.Suafigurinha.IO.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AC.Suafigurinha.IO.Infra.Data.Mappings
{
    public class ProductMapping : EntityTypeConfiguration<Product>
    {
        public override void Map(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Name)
                .HasColumnType("VARCHAR(100)")
                .IsRequired();

            builder.Property(p => p.Price)
                .IsRequired();

            builder.Property(p => p.HaveQuantity)
                .HasDefaultValue(false)
                .IsRequired();

            builder.Property(p => p.Quantity)
                .HasDefaultValue(0)
                .IsRequired();

            builder.Property(p => p.ShortDescription)
                .HasColumnType("VARCHAR(255)")
                .IsRequired();

            builder.Property(p => p.Description)
                .HasColumnType("VARCHAR(MAX)")
                .IsRequired();

            builder.Property(p => p.IdImage)
                .IsRequired(false);

            builder.Property(p => p.IdGalery)
                .IsRequired(false);

            builder.Property(p => p.IdCategory)
                .IsRequired(false);

            builder.Property(p => p.Deleted)
                .HasDefaultValue(false)
                .IsRequired();

            builder.HasOne(p => p.ThumbNail)
                .WithOne(i => i.Product)
                .IsRequired(false);

            builder.HasOne(p => p.Gallery)
                .WithOne(g => g.Product)
                .IsRequired(false);

            builder.HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.IdCategory)
                .IsRequired(false);

            builder.Ignore(c => c.ValidationResult);

            builder.Ignore(c => c.CascadeMode);

            builder.ToTable("Products");
        }
    }
}
