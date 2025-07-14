using ControlFina.Core.Abstractions.Handlers;
using ControlFina.Core.Abstractions.Results;
using ControlFina.Core.Models;

namespace ControlFina.Core.Features.Transactions.Contracts.GetPaginated;

public interface IGetPaginatedTransactionQueryHandler : IQueryHandler<Pagination, PaginationResult<TransactionResponse>>
{
}
