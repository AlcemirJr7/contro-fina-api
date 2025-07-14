using ControlFina.Core.Abstractions.Results;
using ControlFina.Core.Features.TransactionAnalytics.Repositories;

namespace ControlFina.Core.Features.TransactionAnalytics.Contracts.GetTransactionsCategoryMonthlyByYear;

public class GetTransactionsCategoryMonthlyByYearQueryHandler : IGetTransactionsCategoryMonthlyByYearQueryHandler
{
    private readonly ITransactionAnalyticsQueryRepository _query;

    public GetTransactionsCategoryMonthlyByYearQueryHandler(ITransactionAnalyticsQueryRepository query)
    {
        _query = query ?? throw new ArgumentNullException(nameof(query));
    }

    public async Task<Result> Handle(GetTransactionsCategoryMonthlyByYearQueryRequest query, CancellationToken cancellationToken)
    {
        var result = await _query.GetTransactionsCategoryMonthlyByYearAsync(query.Year, cancellationToken);

        return Result.Success(result);
    }
}
