using ControlFina.Core.Abstractions.Handlers;
using ControlFina.Core.Features.TransactionAnalytics.Contracts.GetTransactionsDailyByPeriod;

namespace ControlFina.Core.Features.TransactionAnalytics.Contracts.GetTransactionDailyByPeriod;
public interface IGetTransactionsDailyByPeriodQueryHandler : IQueryHandler<GetTransactionsDailyByPeriodQueryResquest,
                                                                           IEnumerable<GetTransactionsDailyByPeriodQueryResponse>>;
