using ControlFina.Core.Abstractions.Results;
using ControlFina.Core.Features.TransactionAnalytics.Contracts.GetTransactionDailyByPeriod;
using ControlFina.Core.Features.TransactionAnalytics.Repositories;

namespace ControlFina.Core.Features.TransactionAnalytics.Contracts.GetTransactionsDailyByPeriod;

public class GetTransactionsDailyByPeriodQueryHandler : IGetTransactionsDailyByPeriodQueryHandler
{
    private readonly ITransactionAnalyticsQueryRepository _query;
    public GetTransactionsDailyByPeriodQueryHandler(ITransactionAnalyticsQueryRepository query)
    {
        _query = query ?? throw new ArgumentNullException(nameof(query));
    }

    public async Task<Result> Handle(GetTransactionsDailyByPeriodQueryResquest query, CancellationToken cancellationToken)
    {
        var result = await _query.GetTransactionsDailyByPeriodAsync(query.Days, query.DebitsOnly ?? false, cancellationToken);

        return Result.Success(result);
    }
}
