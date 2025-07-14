using ControlFina.Api.Abstractions;
using ControlFina.Api.Extensions;
using ControlFina.Core.Abstractions.Results;
using ControlFina.Core.Features.TransactionAnalytics.Contracts.GetBiggerTransactionLastAndCurrentMonth;
using ControlFina.Core.Features.TransactionAnalytics.Contracts.GetExpenseLastAndCurrentMonth;
using ControlFina.Core.Features.TransactionAnalytics.Contracts.GetRevenueLastAndCurrentMonth;
using ControlFina.Core.Features.TransactionAnalytics.Contracts.GetRevenueVsExpenseMonthlyByYear;
using ControlFina.Core.Features.TransactionAnalytics.Contracts.GetTransactionCategoryByPeriod;
using ControlFina.Core.Features.TransactionAnalytics.Contracts.GetTransactionDailyByPeriod;
using ControlFina.Core.Features.TransactionAnalytics.Contracts.GetTransactionsCategoryMonthlyByYear;
using ControlFina.Core.Features.TransactionAnalytics.Contracts.GetTransactionsDailyByPeriod;
using Microsoft.AspNetCore.Mvc;

namespace ControlFina.Api.Controllers.TransactionAnalytics
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/transaction-analytics")]

    public class TransactionAnalyticsController : AbstractController
    {
        [HttpGet("get-transactions-category-by-period")]
        [ProducesResponseType(typeof(Result<IEnumerable<GetTransactionsCategoryByPeriodQueryResponse>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Result), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(Result), StatusCodes.Status500InternalServerError)]
        public async Task<IResult> GetTransactionsCategoryByPeriod(
        [FromQuery] GetTransactionsCategoryByPeriodQueryResquest resquest,
        [FromServices] IGetTransactionsCategoryByPeriodQueryHandler handler,
        CancellationToken cancellationToken)
        {
            Result result = await handler.Handle(resquest, cancellationToken);

            return result.Response();
        }

        [HttpGet("get-transactions-daily-by-period")]
        [ProducesResponseType(typeof(Result<IEnumerable<GetTransactionsDailyByPeriodQueryResponse>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Result), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(Result), StatusCodes.Status500InternalServerError)]
        public async Task<IResult> GetTransactionsDailyByPeriod(
        [FromQuery] GetTransactionsDailyByPeriodQueryResquest resquest,
        [FromServices] IGetTransactionsDailyByPeriodQueryHandler handler,
        CancellationToken cancellationToken)
        {
            Result result = await handler.Handle(resquest, cancellationToken);

            return result.Response();
        }

        [HttpGet("get-revenue-expense-monthly-by-year")]
        [ProducesResponseType(typeof(Result<IEnumerable<GetRevenueVsExpenseMonthlyByYearQueryResponse>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Result), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(Result), StatusCodes.Status500InternalServerError)]
        public async Task<IResult> GetRevenueVsExpenseMonthlyByYear(
        [FromQuery] GetRevenueVsExpenseMonthlyByYearQueryRequest resquest,
        [FromServices] IGetRevenueVsExpenseMonthlyByYearQueryHandler handler,
        CancellationToken cancellationToken)
        {
            Result result = await handler.Handle(resquest, cancellationToken);

            return result.Response();
        }

        [HttpGet("get-expense-last-and-current-month")]
        [ProducesResponseType(typeof(Result<IEnumerable<GetExpenseLastAndCurrentMonthQueryResponse>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Result), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(Result), StatusCodes.Status500InternalServerError)]
        public async Task<IResult> GetExpenseLastAndCurrentMonth(
            [FromServices] IGetExpenseLastAndCurrentMonthQueryHandler handler,
            CancellationToken cancellationToken)
        {
            Result result = await handler.Handle(cancellationToken);

            return result.Response();
        }

        [HttpGet("get-revenue-last-and-current-month")]
        [ProducesResponseType(typeof(Result<IEnumerable<GetRevenueLastAndCurrentMonthQueryResponse>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Result), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(Result), StatusCodes.Status500InternalServerError)]
        public async Task<IResult> GetRevenueLastAndCurrentMonth(
            [FromServices] IGetRevenueLastAndCurrentMonthQueryHandler handler,
            CancellationToken cancellationToken)
        {
            Result result = await handler.Handle(cancellationToken);

            return result.Response();
        }

        [HttpGet("get-bigger-revenue-last-current-month")]
        [ProducesResponseType(typeof(Result<IEnumerable<GetBiggerRevenueLastAndCurrentMonthQueryResponse>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Result), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(Result), StatusCodes.Status500InternalServerError)]
        public async Task<IResult> GetBiggerRevenueLastAndCurrentMonth(
            [FromServices] IGetBiggerRevenueLastAndCurrentMonthQueryHandler handler,
            CancellationToken cancellationToken)
        {
            Result result = await handler.Handle(cancellationToken);

            return result.Response();
        }

        [HttpGet("get-transactions-category-monthly-by-year")]
        [ProducesResponseType(typeof(Result<IEnumerable<GetTransactionsCategoryMonthlyByYearQueryResponse>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Result), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(Result), StatusCodes.Status500InternalServerError)]
        public async Task<IResult> GetTransactionsCategoryMonthlyByYear(
            [FromQuery] GetTransactionsCategoryMonthlyByYearQueryRequest resquest,
            [FromServices] IGetTransactionsCategoryMonthlyByYearQueryHandler handler,
            CancellationToken cancellationToken)
        {
            Result result = await handler.Handle(resquest, cancellationToken);

            return result.Response();
        }
    }
}
