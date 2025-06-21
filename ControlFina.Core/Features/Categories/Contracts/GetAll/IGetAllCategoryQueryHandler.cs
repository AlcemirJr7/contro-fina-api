using ControlFina.Core.Abstractions.Handlers;

namespace ControlFina.Core.Features.Categories.Contracts.GetAll;

public interface IGetAllCategoryQueryHandler : IQueryHandler<IEnumerable<CategoryResponse>>;
