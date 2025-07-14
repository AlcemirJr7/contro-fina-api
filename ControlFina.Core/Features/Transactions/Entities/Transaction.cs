using ControlFina.Core.Abstractions;
using ControlFina.Core.Features.Categories.Entities;

namespace ControlFina.Core.Features.Transactions.Entities;

public sealed class Transaction
{
    public Guid Id { get; private set; }
    public DateTime TransacationDate { get; private set; }
    public Guid CategoryId { get; private set; }
    public Category? Category { get; private set; }
    public decimal Value { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }
    public string Observation { get; private set; } = string.Empty;
    public bool IsDebit { get; private set; }
    public DateTime FirstOfMonth { get; private set; }

    public Transaction(DateTime transacationDate, Guid categoryId, decimal value, string observation, bool isDebit)
    {
        Id = Guid.NewGuid();
        TransacationDate = transacationDate;
        CategoryId = categoryId;
        Value = SetValue(isDebit, value);
        CreatedAt = DateTimeBr.Now;
        UpdatedAt = DateTimeBr.Now;
        Observation = observation;
        IsDebit = isDebit;
        FirstOfMonth = new DateTime(transacationDate.Year, transacationDate.Month, 1);
    }

    public void Update(DateTime transacationDate, Guid categoryId, decimal value, string observation, bool isDebit)
    {
        TransacationDate = transacationDate;
        CategoryId = categoryId;
        Value = SetValue(isDebit, value);
        UpdatedAt = DateTimeBr.Now;
        Observation = observation;
        IsDebit = isDebit;
        FirstOfMonth = new DateTime(transacationDate.Year, transacationDate.Month, 1);
    }

    private decimal SetValue(bool isDebit, decimal value)
    {
        return isDebit ? Math.Abs(value) * -1 : value;
    }
}
