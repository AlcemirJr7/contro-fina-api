using ControlFina.Core.Features.Transactions.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControlFina.Infrastructure.Database.EntitiesConfiguration.Transactions;

public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        builder.ToTable(TransactionDefinition.TABLE_NAME);

        builder.HasKey(h => h.Id);

        builder.Property(h => h.TransacationDate)
               .HasColumnName("transacation_date")
               .HasColumnType("timestamp")
               .IsRequired();

        builder.Property(h => h.CategoryId)
               .HasColumnName("category_id")
               .IsRequired();

        builder.Property(h => h.Value)
               .HasColumnName("value")
               .IsRequired();

        builder.Property(h => h.CreatedAt)
               .HasColumnName("created_at")
               .HasColumnType("timestamp");

        builder.Property(h => h.UpdatedAt)
               .HasColumnName("updated_at")
               .HasColumnType("timestamp");

    }
}
