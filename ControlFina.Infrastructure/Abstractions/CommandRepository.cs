using ControlFina.Infrastructure.Database;

namespace ControlFina.Infrastructure.Abstractions;

public abstract class CommandRepository<TEntity> where TEntity : class
{
    private readonly AppDbContext _dbContext;

    public CommandRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Create(TEntity entity)
    {
        _dbContext.Set<TEntity>().Add(entity);
    }

    public void Delete(TEntity entity)
    {
        _dbContext.Set<TEntity>().Remove(entity);
    }

    public void Update(TEntity entity)
    {
        _dbContext.Set<TEntity>().Update(entity);
    }

    public async Task<bool> Commit()
    {
        return await _dbContext.SaveChangesAsync() != -1 ? true : false;
    }

    public void Rollback()
    {
        _dbContext.ChangeTracker.Entries().ToList().ForEach(entry => entry.Reload());
    }

    public void Dispose()
    {
        _dbContext?.Dispose();
    }
}
