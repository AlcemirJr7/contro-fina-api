using ControlFina.Core.Features.TransactionAnalytics.Contracts.GetBiggerTransactionLastAndCurrentMonth;
using ControlFina.Core.Features.TransactionAnalytics.Contracts.GetExpenseLastAndCurrentMonth;
using ControlFina.Core.Features.TransactionAnalytics.Contracts.GetRevenueLastAndCurrentMonth;
using ControlFina.Core.Features.TransactionAnalytics.Contracts.GetRevenueVsExpenseMonthlyByYear;
using ControlFina.Core.Features.TransactionAnalytics.Contracts.GetTransactionCategoryByPeriod;
using ControlFina.Core.Features.TransactionAnalytics.Contracts.GetTransactionsCategoryMonthlyByYear;
using ControlFina.Core.Features.TransactionAnalytics.Contracts.GetTransactionsDailyByPeriod;

namespace ControlFina.Core.Features.TransactionAnalytics.Repositories;

public interface ITransactionAnalyticsQueryRepository
{
    Task<IEnumerable<GetTransactionsCategoryByPeriodQueryResponse>> GetTransactionCategoryByPeriodAsync(int days, bool debitsOnly = true, CancellationToken cancellationToken = default);
    Task<IEnumerable<GetTransactionsDailyByPeriodQueryResponse>> GetTransactionsDailyByPeriodAsync(int days, bool debitsOnly = true, CancellationToken cancellationToken = default);
    Task<IEnumerable<GetRevenueVsExpenseMonthlyByYearQueryResponse>> GetRevenueVsExpenseMonthlyByYearAsync(int year, CancellationToken cancellationToken = default);
    Task<IEnumerable<GetExpenseLastAndCurrentMonthQueryResponse>> GetExpenseLastAndCurrentMonthAsync(CancellationToken cancellationToken = default);
    Task<IEnumerable<GetRevenueLastAndCurrentMonthQueryResponse>> GetRevenueLastAndCurrentMonthAsync(CancellationToken cancellationToken = default);
    Task<IEnumerable<GetBiggerRevenueLastAndCurrentMonthQueryResponse>> GetBiggerTransactionLastAndCurrentMonthAsync(CancellationToken cancellationToken = default);
    Task<IEnumerable<GetTransactionsCategoryMonthlyByYearQueryResponse>> GetTransactionsCategoryMonthlyByYearAsync(int year, CancellationToken cancellationToken = default);
}

