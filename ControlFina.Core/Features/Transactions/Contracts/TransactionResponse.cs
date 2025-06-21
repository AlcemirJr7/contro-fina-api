namespace ControlFina.Core.Features.Transactions.Contracts;

public sealed class TransactionResponse
{
    public Guid Id { get; set; }
    public DateTime TransacationDate { get; set; }
    public Guid CategoryId { get; set; }
    public decimal Value { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
