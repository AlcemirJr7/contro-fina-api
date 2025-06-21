using ControlFina.Core.Abstractions.Results;
using ControlFina.Core.Features.Transactions.Repositories;

namespace ControlFina.Core.Features.Transactions.Contracts.GetById;

public sealed class GetByIdTransactionQueryHandler : IGetByIdTransactionQueryHandler
{
    private readonly ITransactionQueryRepository _query;
    public GetByIdTransactionQueryHandler(ITransactionQueryRepository query)
    {
        _query = query;
    }

    public async Task<Result> Handle(GetByIdTransactionQuery query, CancellationToken cancellationToken)
    {
        var transaction = await _query.GetByIdAsync(query.Id, cancellationToken);

        if (transaction is null)
            return Result.Failure(Error.NotFound($"Transaction with id [{query.Id}] not found"));

        return Result.Success(transaction);
    }
}
