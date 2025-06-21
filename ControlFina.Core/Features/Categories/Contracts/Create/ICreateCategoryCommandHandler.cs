using ControlFina.Core.Abstractions.Handlers;

namespace ControlFina.Core.Features.Categories.Contracts.Create;

public interface ICreateCategoryCommandHandler : ICommandHandler<CreateCategoryCommand, CategoryResponse>;
