using ControlFina.Core.Abstractions.Repositories;
using ControlFina.Core.Abstractions.Results;
using ControlFina.Core.Features.Transactions.Entities;
using ControlFina.Core.Models;

namespace ControlFina.Core.Features.Transactions.Repositories;

public interface ITransactionQueryRepository : IQueryRepository<Transaction>
{
    Task<IEnumerable<Transaction>> GetAllWithCategoryAsync(CancellationToken cancellationToken = default);
    Task<PaginationResult<Transaction>> GetAllWithCategoryPaginedAsync(Pagination pagination, CancellationToken cancellationToken = default);
}

