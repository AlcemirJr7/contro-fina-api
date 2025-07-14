using ControlFina.Core.Abstractions.Handlers;

namespace ControlFina.Core.Features.TransactionAnalytics.Contracts.GetTransactionCategoryByPeriod;

public interface IGetTransactionsCategoryByPeriodQueryHandler : IQueryHandler<GetTransactionsCategoryByPeriodQueryResquest, 
                                                                              IEnumerable<GetTransactionsCategoryByPeriodQueryResponse>>;
