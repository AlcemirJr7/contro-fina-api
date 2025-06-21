using ControlFina.Core.Abstractions.Handlers;

namespace ControlFina.Core.Features.Categories.Contracts.Update;

public sealed class UpdateCategoryCommand : ICommand<CategoryResponse>
{
    public Guid Id;
    public required string Description;
    public bool IsActive;
}
