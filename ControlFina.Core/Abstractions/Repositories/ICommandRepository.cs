namespace ControlFina.Core.Abstractions.Repositories;

public interface ICommandRepository<TEntity> : IDisposable where TEntity : class
{
    void Create(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);
    Task<bool> Commit();
    void Rollback();
}