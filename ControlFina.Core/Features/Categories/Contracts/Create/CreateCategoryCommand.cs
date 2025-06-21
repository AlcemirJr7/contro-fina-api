using ControlFina.Core.Abstractions.Handlers;

namespace ControlFina.Core.Features.Categories.Contracts.Create;

public sealed record CreateCategoryCommand(string Description) : ICommand<CategoryResponse>;
