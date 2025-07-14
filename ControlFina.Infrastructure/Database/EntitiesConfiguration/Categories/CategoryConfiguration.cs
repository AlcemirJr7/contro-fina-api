using ControlFina.Core.Abstractions;
using ControlFina.Core.Features.Categories.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControlFina.Infrastructure.Database.EntitiesConfiguration.Categories;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable(CategoryDefinition.TABLE_NAME);

        builder.HasKey(h => h.Id);

        builder.Property(h => h.Description)
               .HasColumnName("description")
               .IsRequired()
               .HasColumnType("varchar")
               .HasMaxLength(CategoryDefinition.DESCRIPTION_MAX_LENGTH);

        builder.Property(h => h.IsActive)
               .HasColumnName("is_active")
               .IsRequired()
               .HasDefaultValue(true)
               .HasColumnType("boolean");

        builder.Property(h => h.CreatedAt)
               .HasColumnName("created_at")
               .HasColumnType("timestamptz")
               .HasConversion(
                   v => DateTimeBr.ToUtc(v),
                   v => DateTimeBr.FromUtc(v))
               .IsRequired();

        builder.Property(h => h.UpdatedAt)
               .HasColumnName("updated_at")
               .HasColumnType("timestamptz")
               .HasConversion(
                   v => DateTimeBr.ToUtc(v),
                   v => DateTimeBr.FromUtc(v));
    }
}
