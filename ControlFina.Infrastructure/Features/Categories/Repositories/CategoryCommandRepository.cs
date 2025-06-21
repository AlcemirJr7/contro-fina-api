using ControlFina.Core.Features.Categories.Entities;
using ControlFina.Core.Features.Categories.Repositories;
using ControlFina.Infrastructure.Abstractions;
using ControlFina.Infrastructure.Database;

namespace ControlFina.Infrastructure.Features.Categories.Repositories;

public class CategoryCommandRepository : CommandRepository<Category>, ICategoryCommandRepository
{
    public CategoryCommandRepository(AppDbContext context) : base(context) { }
}
