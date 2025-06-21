using ControlFina.Core.Abstractions.Results;
using ControlFina.Core.Features.Categories.Mappings;
using ControlFina.Core.Features.Categories.Repositories;

namespace ControlFina.Core.Features.Categories.Contracts.GetAll;

public class GetAllCategoryQueryHandler : IGetAllCategoryQueryHandler
{
    private readonly ICategoryQueryRepository _query;

    public GetAllCategoryQueryHandler(ICategoryQueryRepository query)
    {
        _query = query ?? throw new ArgumentNullException(nameof(query));
    }

    public async Task<Result> Handle(CancellationToken cancellationToken)
    {
        var categories = await _query.GetAllAsync(cancellationToken);

        var response = CategoryMap.ToResponse(categories);

        return Result.Success(response);
    }
}
