namespace ControlFina.Core.Features.Transactions.Contracts.Update;

public sealed class UpdateTransactionRequest
{
    public DateTime TransacationDate { get; set; }
    public Guid CategoryId { get; set; }
    public decimal Value { get; set; }
}
