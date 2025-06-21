using ControlFina.Core.Abstractions.Results;
using ControlFina.Core.Features.Categories.Mappings;
using ControlFina.Core.Features.Categories.Repositories;

namespace ControlFina.Core.Features.Categories.Contracts.Delete;

public class DeleteCategoryCommandHandler : IDeleteCategoryCommandHandler
{
    private readonly ICategoryCommandRepository _command;
    private readonly ICategoryQueryRepository _query;

    public DeleteCategoryCommandHandler(ICategoryCommandRepository command, ICategoryQueryRepository query)
    {
        _command = command;
        _query = query;
    }

    public async Task<Result<CategoryResponse>> Handle(DeleteCategoryCommand command, CancellationToken cancellationToken)
    {
        var category = await _query.GetByIdAsync(command.Id, cancellationToken);

        if (category is null)
            return Result.Failure<CategoryResponse>(Error.NotFound($"Category with id [{command.Id}] not found"));

        _command.Delete(category);

        await _command.Commit();

        var response = CategoryMap.ToResponse(category);

        return Result.Success(response);
    }
}
