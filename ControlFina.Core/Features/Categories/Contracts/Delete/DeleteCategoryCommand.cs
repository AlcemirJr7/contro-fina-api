using ControlFina.Core.Abstractions.Handlers;

namespace ControlFina.Core.Features.Categories.Contracts.Delete;

public sealed record DeleteCategoryCommand(Guid Id) : ICommand<CategoryResponse>;
