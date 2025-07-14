using ControlFina.Core.Abstractions.Results;
using ControlFina.Core.Features.Transactions.Repositories;
using ControlFina.Core.Models;

namespace ControlFina.Core.Features.Transactions.Contracts.GetPaginated;

public sealed class GetPaginatedTransactionQueryHandler : IGetPaginatedTransactionQueryHandler
{
    private readonly ITransactionQueryRepository _query;

    public GetPaginatedTransactionQueryHandler(ITransactionQueryRepository query)
    {
        _query = query;
    }

    public async Task<Result> Handle(Pagination query, CancellationToken cancellationToken)
    {
        var transactions = await _query.GetAllWithCategoryPaginedAsync(query, cancellationToken);

        return Result.Success(transactions);
    }
}
