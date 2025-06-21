using ControlFina.Core.Abstractions.Repositories;
using ControlFina.Core.Features.Categories.Entities;

namespace ControlFina.Core.Features.Categories.Repositories;

public interface ICategoryCommandRepository : ICommandRepository<Category>;
