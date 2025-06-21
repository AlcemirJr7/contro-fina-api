using ControlFina.Core.Abstractions.Handlers;

namespace ControlFina.Core.Features.Transactions.Contracts.GetAll;

public interface IGetAllTransactionQueryHandler : IQueryHandler<IEnumerable<TransactionResponse>>;
