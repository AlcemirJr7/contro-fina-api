using ControlFina.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace ControlFina.Infrastructure.Abstractions;

public abstract class QueryRepository<TEntity> where TEntity : class
{
    private readonly AppDbContext _dbContext;

    public QueryRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<TEntity>?> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _dbContext.Set<TEntity>().ToListAsync();
    }

    public async Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _dbContext.Set<TEntity>().FindAsync(id);
    }

    public void Dispose()
    {
        _dbContext?.Dispose();
    }
}
