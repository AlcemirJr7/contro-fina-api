using ControlFina.Core.Abstractions.Handlers;

namespace ControlFina.Core.Features.Transactions.Contracts.Create;

public sealed class CreateTransactionCommand : ICommand<TransactionResponse>
{
    public DateTime TransacationDate { get; set; }
    public Guid CategoryId { get; set; }
    public decimal Value { get; set; }
    public string Observation { get; set; } = string.Empty;
    public bool IsDebit { get; set; }
}
