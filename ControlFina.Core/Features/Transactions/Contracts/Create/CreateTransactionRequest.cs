namespace ControlFina.Core.Features.Transactions.Contracts.Create;

public sealed record CreateTransactionRequest(DateTime TransacationDate, Guid CategoryId, decimal Value);
