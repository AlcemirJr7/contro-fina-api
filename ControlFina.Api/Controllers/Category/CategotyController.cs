using ControlFina.Api.Abstractions;
using ControlFina.Api.Extensions;
using ControlFina.Core.Abstractions.Results;
using ControlFina.Core.Features.Categories.Contracts;
using ControlFina.Core.Features.Categories.Contracts.Create;
using ControlFina.Core.Features.Categories.Contracts.Delete;
using ControlFina.Core.Features.Categories.Contracts.GetAll;
using ControlFina.Core.Features.Categories.Contracts.GetById;
using ControlFina.Core.Features.Categories.Contracts.Update;
using Microsoft.AspNetCore.Mvc;

namespace ControlFina.Api.Controllers.Category;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/category")]
public class CategotyController : AbstractController
{
    [HttpPost("create")]
    [ProducesResponseType(typeof(Result<CategoryResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status500InternalServerError)]
    public async Task<IResult> Create(
        CreateCategoryRequest request,
        [FromServices] ICreateCategoryCommandHandler handler,
        CancellationToken cancellationToken)
    {
        var result = await handler.Handle(new CreateCategoryCommand(request.Description), cancellationToken);

        return result.Response();
    }

    [HttpPut("update/{id:guid}")]
    [ProducesResponseType(typeof(Result<CategoryResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status500InternalServerError)]
    public async Task<IResult> Delete(
        Guid id,
        UpdateCategoryRequest request,
        [FromServices] IUpdateCategoryCommandHandler handler,
        CancellationToken cancellationToken)
    {
        var result = await handler.Handle(new UpdateCategoryCommand {
            Id = id,
            Description = request.Description, 
            IsActive = request.IsActive 
        }
        , cancellationToken);

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
        [FromServices] IDeleteCategoryCommandHandler handler,
        CancellationToken cancellationToken)
    {
        var result = await handler.Handle(new DeleteCategoryCommand(id), cancellationToken);

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
        [FromServices] IGetByIdCategoryQueryHandler handler,
        CancellationToken cancellationToken)
    {
        Result result = await handler.Handle(new GetByIdCategoryQuery(id), cancellationToken);

        return result.Response();
    }

    [HttpGet("get-all")]
    [ProducesResponseType(typeof(Result<IEnumerable<CategoryResponse>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(Result), StatusCodes.Status500InternalServerError)]
    public async Task<IResult> GetAll(
        [FromServices] IGetAllCategoryQueryHandler handler,
        CancellationToken cancellationToken)
    {
        Result result = await handler.Handle(cancellationToken);

        return result.Response();
    }
}
