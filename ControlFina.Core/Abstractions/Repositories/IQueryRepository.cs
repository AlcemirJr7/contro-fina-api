namespace ControlFina.Core.Abstractions.Repositories;

public interface IQueryRepository<TEntity> where TEntity : class
{
    Task<IEnumerable<TEntity>?> GetAllAsync(CancellationToken cancellationToken);
    Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
}

