using ControlFina.Core.Abstractions.Results;
using ControlFina.Core.Features.Categories.Mappings;
using ControlFina.Core.Features.Categories.Repositories;

namespace ControlFina.Core.Features.Categories.Contracts.Update;

public sealed class UpdateCategoryCommandHandler : IUpdateCategoryCommandHandler
{
    private readonly ICategoryCommandRepository _command;
    private readonly ICategoryQueryRepository _query;

    public UpdateCategoryCommandHandler(ICategoryCommandRepository command, ICategoryQueryRepository query)
    {
        _command = command;
        _query = query;
    }

    public async Task<Result<CategoryResponse>> Handle(UpdateCategoryCommand command, CancellationToken cancellationToken)
    {
        var category = await _query.GetByIdAsync(command.Id, cancellationToken);

        if (category is null)
            return Result.Failure<CategoryResponse>(Error.NotFound($"Category with id [{command.Id}] not found"));

        category.Update(command.Description, command.IsActive);

        _command.Update(category);

        await _command.Commit();

        var response = CategoryMap.ToResponse(category);

        return Result.Success(response);
    }
}

