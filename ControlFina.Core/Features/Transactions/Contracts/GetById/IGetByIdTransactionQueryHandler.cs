using ControlFina.Core.Abstractions.Handlers;

namespace ControlFina.Core.Features.Transactions.Contracts.GetById;

public interface IGetByIdTransactionQueryHandler : IQueryHandler<GetByIdTransactionQuery, TransactionResponse>;
