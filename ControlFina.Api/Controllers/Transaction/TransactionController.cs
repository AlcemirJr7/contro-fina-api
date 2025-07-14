using ControlFina.Api.Abstractions;
using ControlFina.Api.Extensions;
using ControlFina.Core.Abstractions.Results;
using ControlFina.Core.Features.Transactions.Contracts;
using ControlFina.Core.Features.Transactions.Contracts.Create;
using ControlFina.Core.Features.Transactions.Contracts.Delete;
using ControlFina.Core.Features.Transactions.Contracts.GetAll;
using ControlFina.Core.Features.Transactions.Contracts.GetById;
using ControlFina.Core.Features.Transactions.Contracts.GetPaginated;
using ControlFina.Core.Features.Transactions.Contracts.Update;
using ControlFina.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace ControlFina.Api.Controllers.Transaction;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/transaction")]
public class TransactionController : AbstractController
{
    [HttpPost("create")]
    [ProducesResponseType(typeof(Result<TransactionResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status500InternalServerError)]
    public async Task<IResult> Create(
        CreateTransactionRequest request,
        [FromServices] ICreateTransactionCommandHandler handler,
        CancellationToken cancellationToken)
    {
        var result = await handler.Handle(new CreateTransactionCommand
        {
            TransacationDate = request.TransacationDate,
            CategoryId = request.CategoryId,
            Value = request.Value,
            Observation = request.Observation,
            IsDebit = request.IsDebit
        }, cancellationToken);

        return result.Response();
    }

    [HttpPut("update/{id:guid}")]
    [ProducesResponseType(typeof(Result<TransactionResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status500InternalServerError)]
    public async Task<IResult> Update(
        Guid id,
        UpdateTransactionRequest request,
        [FromServices] IUpdateTransactionCommandHandler handler,
        CancellationToken cancellationToken)
    {
        request.Id = id;
        var result = await handler.Handle(request, cancellationToken);

        return result.Response();
    }

    [HttpDelete("delete/{id:guid}")]
    [ProducesResponseType(typeof(Result<TransactionResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status500InternalServerError)]
    public async Task<IResult> Delete(
        Guid id,
        [FromServices] IDeleteTransactionCommandHandler handler,
        CancellationToken cancellationToken)
    {
        var result = await handler.Handle(new DeleteTransactionCommand(id), cancellationToken);

        return result.Response();
    }

    [HttpGet("get/{id:guid}")]
    [ProducesResponseType(typeof(Result<TransactionResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status500InternalServerError)]
    public async Task<IResult> GetById(
        Guid id,
        [FromServices] IGetByIdTransactionQueryHandler handler,
        CancellationToken cancellationToken)
    {
        Result result = await handler.Handle(new GetByIdTransactionQuery(id), cancellationToken);

        return result.Response();
    }

    [HttpGet("get-all")]
    [ProducesResponseType(typeof(Result<IEnumerable<TransactionResponse>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status500InternalServerError)]
    public async Task<IResult> GetAll(
        [FromServices] IGetAllTransactionQueryHandler handler,
        CancellationToken cancellationToken)
    {
        Result result = await handler.Handle(cancellationToken);

        return result.Response();
    }

    [HttpGet("get-paginated")]
    [ProducesResponseType(typeof(Result<PaginationResult<TransactionResponse>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status500InternalServerError)]
    public async Task<IResult> GetPaginated(
        [FromQuery] Pagination pagination,
        [FromServices] IGetPaginatedTransactionQueryHandler handler,
        CancellationToken cancellationToken)
    {
        Result result = await handler.Handle(pagination, cancellationToken);

        return result.Response();
    }
}
