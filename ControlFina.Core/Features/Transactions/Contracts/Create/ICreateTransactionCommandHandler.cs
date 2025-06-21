using ControlFina.Core.Abstractions.Handlers;

namespace ControlFina.Core.Features.Transactions.Contracts.Create;

public interface ICreateTransactionCommandHandler : ICommandHandler<CreateTransactionCommand, TransactionResponse>;
