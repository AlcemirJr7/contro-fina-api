using ControlFina.Api.Abstractions;
using ControlFina.Api.Extensions;
using ControlFina.Core.Abstractions.Results;
using ControlFina.Core.Features.Categories.Contracts;
using ControlFina.Core.Features.Transactions.Contracts.Create;
using ControlFina.Core.Features.Transactions.Contracts.Delete;
using ControlFina.Core.Features.Transactions.Contracts.GetAll;
using ControlFina.Core.Features.Transactions.Contracts.GetById;
using ControlFina.Core.Features.Transactions.Contracts.Update;
using Microsoft.AspNetCore.Mvc;

namespace ControlFina.Api.Controllers.Transaction;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/transaction")]
public class TransactionController : AbstractController
{
    [HttpPost("create")]
    [ProducesResponseType(typeof(Result<CategoryResponse>), StatusCodes.Status201Created)]
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
            Value = request.Value
        }, cancellationToken);

        return result.Response();
    }

    [HttpPut("update/{id:guid}")]
    [ProducesResponseType(typeof(Result<CategoryResponse>), StatusCodes.Status200OK)]
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
        var result = await handler.Handle(new UpdateTransactionCommand
        {
            Id = id,
            TransacationDate = request.TransacationDate,
            CategoryId = request.CategoryId,
            Value = request.Value
        }, cancellationToken);

        return result.Response();
    }

    [HttpDelete("delete/{id:guid}")]
    [ProducesResponseType(typeof(Result<CategoryResponse>), StatusCodes.Status200OK)]
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
    [ProducesResponseType(typeof(Result<CategoryResponse>), StatusCodes.Status200OK)]
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
    [ProducesResponseType(typeof(Result<IEnumerable<CategoryResponse>>), StatusCodes.Status200OK)]
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
}
