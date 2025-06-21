using ControlFina.Core.Abstractions.Handlers;

namespace ControlFina.Core.Features.Categories.Contracts.Update;

public interface IUpdateCategoryCommandHandler : ICommandHandler<UpdateCategoryCommand, CategoryResponse>;
