using ControlFina.Core.Features.Transactions.Contracts;
using ControlFina.Core.Features.Transactions.Entities;

namespace ControlFina.Core.Features.Transactions.Mappings;

internal class TransactionMap
{
    public static TransactionResponse ToResponse(Transaction transaction)
    {
        return new TransactionResponse
        {
            Id = transaction.Id,
            TransacationDate = transaction.TransacationDate,
            CategoryId = transaction.CategoryId,
            Category = transaction.Category,
            Value = transaction.Value,
            CreatedAt = transaction.CreatedAt,
            UpdatedAt = transaction.UpdatedAt,
            Observation = transaction.Observation,
            IsDebit = transaction.IsDebit,
            FirstOfMonth = transaction.FirstOfMonth
        };
    }

    public static IEnumerable<TransactionResponse> ToResponse(IEnumerable<Transaction>? transactions)
    {
        transactions ??= Enumerable.Empty<Transaction>();

        foreach (var transaction in transactions)
            yield return ToResponse(transaction);
    }
}
