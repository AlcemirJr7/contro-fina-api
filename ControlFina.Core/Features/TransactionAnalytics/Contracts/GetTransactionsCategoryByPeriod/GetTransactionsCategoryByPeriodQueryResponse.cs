namespace ControlFina.Core.Features.TransactionAnalytics.Contracts.GetTransactionCategoryByPeriod;

public sealed class GetTransactionsCategoryByPeriodQueryResponse
{
    public string Category { get; set; } = string.Empty;
    public decimal SumValue { get; set; }
    public decimal TotalValue { get; set; }
    public decimal PercValue { get; set; }
}
