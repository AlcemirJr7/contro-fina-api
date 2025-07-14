namespace ControlFina.Core.Features.TransactionAnalytics.Contracts.GetExpenseLastAndCurrentMonth;

public sealed class GetExpenseLastAndCurrentMonthQueryResponse
{
    public DateTime FirstOfMonth { get; set; }
    public decimal ExpenseValue { get; set; }
    public decimal LastExpenseValue { get; set; }
    public decimal DiffLastExpenseValue { get; set; }
    public decimal PercLastExpense { get; set; }
}
