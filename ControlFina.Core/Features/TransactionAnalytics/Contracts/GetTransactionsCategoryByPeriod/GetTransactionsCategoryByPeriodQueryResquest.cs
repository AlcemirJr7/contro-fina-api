namespace ControlFina.Core.Features.TransactionAnalytics.Contracts.GetTransactionCategoryByPeriod;

public sealed class GetTransactionsCategoryByPeriodQueryResquest
{
    public int Days { get; set; } = 30;
    public bool? DebitsOnly { get; set; } = true;
}
