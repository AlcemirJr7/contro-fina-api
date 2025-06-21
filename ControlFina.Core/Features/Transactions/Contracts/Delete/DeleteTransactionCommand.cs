using ControlFina.Core.Abstractions.Handlers;

namespace ControlFina.Core.Features.Transactions.Contracts.Delete;

public sealed record DeleteTransactionCommand(Guid Id) : ICommand<TransactionResponse>;
