namespace ControlFina.Core.Features.TransactionAnalytics.Contracts.GetRevenueVsExpenseMonthlyByYear;

public sealed class GetRevenueVsExpenseMonthlyByYearQueryResponse
{
    public DateTime FirstOfMonth { get; set; }
    public decimal ExpenseValue { get; set; }
    public decimal RevenueValue { get; set; }
    public decimal RemainingValue { get; set; }
    public decimal PercExpenseValue { get; set; }
}
