namespace ControlFina.Core.Features.TransactionAnalytics.Contracts.GetTransactionsDailyByPeriod;

public sealed class GetTransactionsDailyByPeriodQueryResquest
{
    public int Days { get; set; } = 30;
    public bool? DebitsOnly { get; set; } = true;
}
