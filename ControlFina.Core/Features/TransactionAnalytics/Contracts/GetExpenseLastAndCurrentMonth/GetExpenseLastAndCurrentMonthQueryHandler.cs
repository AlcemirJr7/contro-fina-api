using ControlFina.Core.Abstractions.Results;
using ControlFina.Core.Features.TransactionAnalytics.Repositories;

namespace ControlFina.Core.Features.TransactionAnalytics.Contracts.GetExpenseLastAndCurrentMonth;

public class GetExpenseLastAndCurrentMonthQueryHandler : IGetExpenseLastAndCurrentMonthQueryHandler
{
    private readonly ITransactionAnalyticsQueryRepository _query;
    public GetExpenseLastAndCurrentMonthQueryHandler(ITransactionAnalyticsQueryRepository query)
    {
        _query = query ?? throw new ArgumentNullException(nameof(query));
    }

    public async Task<Result> Handle(CancellationToken cancellationToken)
    {
        var result = await _query.GetExpenseLastAndCurrentMonthAsync(cancellationToken);

        return Result.Success(result);
    }
}
