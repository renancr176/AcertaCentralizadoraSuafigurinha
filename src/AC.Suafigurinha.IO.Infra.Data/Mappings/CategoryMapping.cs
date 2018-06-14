using AC.Suafigurinha.IO.Domain.Categories;
using AC.Suafigurinha.IO.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AC.Suafigurinha.IO.Infra.Data.Mappings
{
    public class CategoryMapping : EntityTypeConfiguration<Category>
    {
        public override void Map(EntityTypeBuilder<Category> builder)
        {
            builder.Property(c => c.Name)
                .HasColumnType("VARCHAR(100)")
                .IsRequired();

            builder.Property(c => c.Deleted)
                .HasDefaultValue(false);

            builder.HasMany(c => c.Products)
                .WithOne(p => p.Category)
                .IsRequired(false);

            builder.Ignore(c => c.ValidationResult);

            builder.Ignore(c => c.CascadeMode);

            builder.ToTable("Categories");
        }
    }
}
