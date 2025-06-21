using ControlFina.Core.Abstractions.Results;
using ControlFina.Core.Features.Categories.Entities;
using ControlFina.Core.Features.Categories.Mappings;
using ControlFina.Core.Features.Categories.Repositories;

namespace ControlFina.Core.Features.Categories.Contracts.Create;

public sealed class CreateCategoryCommandHandler : ICreateCategoryCommandHandler
{
    private readonly ICategoryCommandRepository _command;

    public CreateCategoryCommandHandler(ICategoryCommandRepository command)
    {
        _command = command ?? throw new ArgumentNullException(nameof(command));
    }

    public async Task<Result<CategoryResponse>> Handle(CreateCategoryCommand command, CancellationToken cancellationToken)
    {
        Category category = new(command.Description);

        _command.Create(category);

        await _command.Commit();

        var response = CategoryMap.ToResponse(category);

        return Result.SuccessCreated(response);
    }
}
