using ControlFina.Core.Abstractions.Results;
using ControlFina.Core.Features.TransactionAnalytics.Repositories;

namespace ControlFina.Core.Features.TransactionAnalytics.Contracts.GetRevenueVsExpenseMonthlyByYear;

public class GetRevenueVsExpenseMonthlyByYearQueryHandler : IGetRevenueVsExpenseMonthlyByYearQueryHandler
{
    private readonly ITransactionAnalyticsQueryRepository _query;
    public GetRevenueVsExpenseMonthlyByYearQueryHandler(ITransactionAnalyticsQueryRepository query)
    {
        _query = query ?? throw new ArgumentNullException(nameof(query));
    }

    public async Task<Result> Handle(GetRevenueVsExpenseMonthlyByYearQueryRequest query, CancellationToken cancellationToken)
    {
        try
        {
            var result = await _query.GetRevenueVsExpenseMonthlyByYearAsync(query.Year, cancellationToken);

            return Result.Success(result);
        }
        catch (Exception)
        {
            var error = new Error(CodeType.BadRequest, "Falha ao buscar dados receita vs despesas.", ErrorType.Failure);
            return Result.Failure(error);
        }
    }
}
