using ControlFina.Core.Abstractions.Handlers;

namespace ControlFina.Core.Features.Categories.Contracts.GetById;

public interface IGetByIdCategoryQueryHandler : IQueryHandler<GetByIdCategoryQuery, IEnumerable<CategoryResponse>>;
