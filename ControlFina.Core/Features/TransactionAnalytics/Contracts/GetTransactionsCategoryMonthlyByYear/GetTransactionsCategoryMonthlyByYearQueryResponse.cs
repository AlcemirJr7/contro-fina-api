namespace ControlFina.Core.Features.TransactionAnalytics.Contracts.GetTransactionsCategoryMonthlyByYear;

public sealed class GetTransactionsCategoryMonthlyByYearQueryResponse
{
    public DateTime FirstOfMonth { get; set; }
    public string Category { get; set; } = string.Empty;
    public decimal SumValue { get; set; }
}
