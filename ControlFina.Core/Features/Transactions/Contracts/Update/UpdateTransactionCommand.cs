using ControlFina.Core.Abstractions.Handlers;

namespace ControlFina.Core.Features.Transactions.Contracts.Update;

public sealed class UpdateTransactionCommand : ICommand<TransactionResponse>
{
    public Guid Id { get; set; }
    public DateTime TransacationDate { get; set; }
    public Guid CategoryId { get; set; }
    public decimal Value { get; set; }
    public string Observation { get; set; } = string.Empty;
    public bool IsDebit { get; set; }
}
