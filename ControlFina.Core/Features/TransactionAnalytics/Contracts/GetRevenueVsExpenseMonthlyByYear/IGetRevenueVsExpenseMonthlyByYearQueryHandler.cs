using ControlFina.Core.Abstractions.Handlers;

namespace ControlFina.Core.Features.TransactionAnalytics.Contracts.GetRevenueVsExpenseMonthlyByYear;

public interface IGetRevenueVsExpenseMonthlyByYearQueryHandler : IQueryHandler<GetRevenueVsExpenseMonthlyByYearQueryRequest,
                                                                           IEnumerable<GetRevenueVsExpenseMonthlyByYearQueryResponse>>;
