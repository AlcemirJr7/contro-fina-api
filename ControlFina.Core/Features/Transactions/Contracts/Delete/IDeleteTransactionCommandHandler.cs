using ControlFina.Core.Abstractions.Handlers;

namespace ControlFina.Core.Features.Transactions.Contracts.Delete;

public interface IDeleteTransactionCommandHandler : ICommandHandler<DeleteTransactionCommand, TransactionResponse>;
