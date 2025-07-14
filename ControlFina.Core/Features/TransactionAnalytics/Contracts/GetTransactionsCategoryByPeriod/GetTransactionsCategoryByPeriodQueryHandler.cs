using ControlFina.Core.Abstractions.Results;
using ControlFina.Core.Features.TransactionAnalytics.Repositories;

namespace ControlFina.Core.Features.TransactionAnalytics.Contracts.GetTransactionCategoryByPeriod;

public class GetTransactionsCategoryByPeriodQueryHandler : IGetTransactionsCategoryByPeriodQueryHandler
{
    private readonly ITransactionAnalyticsQueryRepository _query;

    public GetTransactionsCategoryByPeriodQueryHandler(ITransactionAnalyticsQueryRepository query)
    {
        _query = query ?? throw new ArgumentNullException(nameof(query));
    }

    public async Task<Result> Handle(GetTransactionsCategoryByPeriodQueryResquest query, CancellationToken cancellationToken)
    {
        var result = await _query.GetTransactionCategoryByPeriodAsync(query.Days, query.DebitsOnly ?? false, cancellationToken);

        return Result.Success(result);
    }
}
