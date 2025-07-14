namespace ControlFina.Core.Features.TransactionAnalytics.Contracts.GetRevenueVsExpenseMonthlyByYear;

public sealed class GetRevenueVsExpenseMonthlyByYearQueryRequest
{
    public int Year { get; set; } = DateTime.UtcNow.Year;
}
