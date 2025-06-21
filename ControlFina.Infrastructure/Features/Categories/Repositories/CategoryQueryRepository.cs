using ControlFina.Core.Features.Categories.Entities;
using ControlFina.Core.Features.Categories.Repositories;
using ControlFina.Infrastructure.Abstractions;
using ControlFina.Infrastructure.Database;

namespace ControlFina.Infrastructure.Features.Categories.Repositories;

public class CategoryQueryRepository : QueryRepository<Category>, ICategoryQueryRepository
{
    public CategoryQueryRepository(AppDbContext dbContext) : base(dbContext) { }
}
