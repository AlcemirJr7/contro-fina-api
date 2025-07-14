namespace ControlFina.Core.Features.TransactionAnalytics.Contracts.GetRevenueLastAndCurrentMonth;

public sealed class GetRevenueLastAndCurrentMonthQueryResponse
{
    public DateTime FirstOfMonth { get; set; }
    public decimal RevenueValue { get; set; }
    public decimal LastRevenueValue { get; set; }
    public decimal DiffLastRevenueValue { get; set; }
    public decimal PercLastRevenue { get; set; }
}
