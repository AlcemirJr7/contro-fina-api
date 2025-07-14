namespace ControlFina.Core.Features.TransactionAnalytics.Contracts.GetTransactionsDailyByPeriod;

public sealed class GetTransactionsDailyByPeriodQueryResponse
{
    public string Category { get; set; } = string.Empty;
    public DateTime TransactionDate { get; set; }
    public decimal SumValue { get; set; }
}
