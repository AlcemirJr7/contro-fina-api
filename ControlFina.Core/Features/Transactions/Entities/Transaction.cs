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

    public Transaction(DateTime transacationDate, Guid categoryId, decimal value)
    {
        Id = Guid.NewGuid();
        TransacationDate = transacationDate;
        CategoryId = categoryId;
        Value = value;
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    public void Update(DateTime transacationDate, Guid categoryId, decimal value)
    {
        TransacationDate = transacationDate;
        CategoryId = categoryId;
        Value = value;
        UpdatedAt = DateTime.Now;
    }
}
