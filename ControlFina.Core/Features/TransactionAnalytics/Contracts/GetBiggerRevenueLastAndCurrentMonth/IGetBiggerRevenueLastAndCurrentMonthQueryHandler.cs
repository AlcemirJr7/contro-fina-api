using ControlFina.Core.Abstractions.Handlers;

namespace ControlFina.Core.Features.TransactionAnalytics.Contracts.GetBiggerTransactionLastAndCurrentMonth;

public interface IGetBiggerRevenueLastAndCurrentMonthQueryHandler : 
    IQueryHandler<IEnumerable<GetBiggerRevenueLastAndCurrentMonthQueryResponse>>;
