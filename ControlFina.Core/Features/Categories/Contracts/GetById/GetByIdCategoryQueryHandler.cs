using ControlFina.Core.Abstractions.Results;
using ControlFina.Core.Features.Categories.Repositories;

namespace ControlFina.Core.Features.Categories.Contracts.GetById;

public sealed class GetByIdCategoryQueryHandler : IGetByIdCategoryQueryHandler
{
    private readonly ICategoryQueryRepository _query;

    public GetByIdCategoryQueryHandler(ICategoryQueryRepository query)
    {
        _query = query;
    }

    public async Task<Result> Handle(GetByIdCategoryQuery query, CancellationToken cancellationToken)
    {
        var category = await _query.GetByIdAsync(query.Id, cancellationToken);

        if (category is null)
            return Result.Failure(Error.NotFound($"Category with id [{query.Id}] not found"));

        return Result.Success(category);
    }
}
