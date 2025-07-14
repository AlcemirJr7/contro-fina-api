using ControlFina.Core.Abstractions.Results;
using ControlFina.Core.Features.TransactionAnalytics.Repositories;

namespace ControlFina.Core.Features.TransactionAnalytics.Contracts.GetBiggerTransactionLastAndCurrentMonth;

public class GetBiggerRevenueLastAndCurrentMonthQueryHandler : IGetBiggerRevenueLastAndCurrentMonthQueryHandler
{
    private readonly ITransactionAnalyticsQueryRepository _query;
    public GetBiggerRevenueLastAndCurrentMonthQueryHandler(ITransactionAnalyticsQueryRepository query)
    {
        _query = query ?? throw new ArgumentNullException(nameof(query));
    }
    public async Task<Result> Handle(CancellationToken cancellationToken)
    {
        var result = await _query.GetBiggerTransactionLastAndCurrentMonthAsync(cancellationToken);

        return Result.Success(result);
    }
}
