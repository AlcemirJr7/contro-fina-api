using ControlFina.Core.Abstractions.Results;
using ControlFina.Core.Features.TransactionAnalytics.Repositories;

namespace ControlFina.Core.Features.TransactionAnalytics.Contracts.GetRevenueLastAndCurrentMonth;

public class GetRevenueLastAndCurrentMonthQueryHandler : IGetRevenueLastAndCurrentMonthQueryHandler
{
    private readonly ITransactionAnalyticsQueryRepository _query;
    public GetRevenueLastAndCurrentMonthQueryHandler(ITransactionAnalyticsQueryRepository query)
    {
        _query = query ?? throw new ArgumentNullException(nameof(query));
    }

    public async Task<Result> Handle(CancellationToken cancellationToken)
    {
        var result = await _query.GetRevenueLastAndCurrentMonthAsync(cancellationToken);

        return Result.Success(result);
    }
}
