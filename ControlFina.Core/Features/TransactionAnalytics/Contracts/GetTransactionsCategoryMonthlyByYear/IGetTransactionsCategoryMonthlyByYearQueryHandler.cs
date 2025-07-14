using ControlFina.Core.Abstractions.Handlers;

namespace ControlFina.Core.Features.TransactionAnalytics.Contracts.GetTransactionsCategoryMonthlyByYear;

public interface IGetTransactionsCategoryMonthlyByYearQueryHandler : IQueryHandler<GetTransactionsCategoryMonthlyByYearQueryRequest,
                                                                        IEnumerable<GetTransactionsCategoryMonthlyByYearQueryResponse>>;
