namespace ControlFina.Core.Features.TransactionAnalytics.Contracts.GetTransactionsCategoryMonthlyByYear;

public sealed class GetTransactionsCategoryMonthlyByYearQueryRequest
{
    public int Year { get; set; } = DateTime.UtcNow.Year;
}
