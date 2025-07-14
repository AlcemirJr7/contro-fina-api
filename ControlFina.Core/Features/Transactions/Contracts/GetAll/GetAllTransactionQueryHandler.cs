using ControlFina.Core.Abstractions.Results;
using ControlFina.Core.Features.Transactions.Mappings;
using ControlFina.Core.Features.Transactions.Repositories;

namespace ControlFina.Core.Features.Transactions.Contracts.GetAll;

public sealed class GetAllTransactionQueryHandler : IGetAllTransactionQueryHandler
{
    private readonly ITransactionQueryRepository _query;

    public GetAllTransactionQueryHandler(ITransactionQueryRepository query)
    {
        _query = query;
    }

    public async Task<Result> Handle(CancellationToken cancellationToken)
    {
        var transactions = await _query.GetAllWithCategoryAsync(cancellationToken);

        var response = TransactionMap.ToResponse(transactions);

        return Result.Success(response);
    }
}
