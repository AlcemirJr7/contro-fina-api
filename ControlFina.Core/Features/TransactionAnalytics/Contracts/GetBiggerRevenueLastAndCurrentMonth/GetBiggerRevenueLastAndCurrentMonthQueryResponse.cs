namespace ControlFina.Core.Features.TransactionAnalytics.Contracts.GetBiggerTransactionLastAndCurrentMonth;

public sealed class GetBiggerRevenueLastAndCurrentMonthQueryResponse
{
    public DateTime FirstOfMonth { get; set; }
    public string Category { get; set; } = string.Empty;
    public decimal Value { get; set; }
    public decimal LastValue { get; set; }
    public decimal DiffValue { get; set; }
    public decimal PercValue { get; set; }
}
