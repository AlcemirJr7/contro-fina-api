using ControlFina.Core.Abstractions;
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
               .HasColumnType("date")
               .IsRequired();

        builder.Property(h => h.CategoryId)
               .HasColumnName("category_id")
               .IsRequired();

        builder.Property(h => h.Value)
               .HasColumnName("value")
               .IsRequired();

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

        builder.Property(h => h.Observation)
               .HasColumnName("observation")
               .HasMaxLength(TransactionDefinition.OBSERVATION_MAX_LENGTH);

        builder.Property(h => h.IsDebit)
               .HasColumnName("is_debit");

        builder.Property(h => h.FirstOfMonth)
               .HasColumnName("first_of_month")
               .HasColumnType("date");

    }
}
