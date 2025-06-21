using ControlFina.Core.Features.Categories.Contracts;
using ControlFina.Core.Features.Categories.Entities;

namespace ControlFina.Core.Features.Categories.Mappings;

internal class CategoryMap
{
    public static CategoryResponse ToResponse(Category category)
    {
        return new CategoryResponse
        {
            Id = category.Id,
            Description = category.Description,
            IsActive = category.IsActive,
            CreatedAt = category.CreatedAt,
            UpdatedAt = category.UpdatedAt
        };
    }

    public static IEnumerable<CategoryResponse> ToResponse(IEnumerable<Category>? categories)
    {
        categories ??= Enumerable.Empty<Category>();

        foreach (var category in categories)
            yield return ToResponse(category);
    }
}
