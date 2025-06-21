using ControlFina.Core.Abstractions.Handlers;

namespace ControlFina.Core.Features.Transactions.Contracts.Update;

public interface IUpdateTransactionCommandHandler : ICommandHandler<UpdateTransactionCommand, TransactionResponse>;
