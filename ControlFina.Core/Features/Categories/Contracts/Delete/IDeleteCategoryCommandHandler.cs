using ControlFina.Core.Abstractions.Handlers;

namespace ControlFina.Core.Features.Categories.Contracts.Delete;

public interface IDeleteCategoryCommandHandler : ICommandHandler<DeleteCategoryCommand, CategoryResponse>;
