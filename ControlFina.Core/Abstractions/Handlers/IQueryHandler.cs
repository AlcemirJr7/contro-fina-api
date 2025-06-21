using ControlFina.Core.Abstractions.Results;

namespace ControlFina.Core.Abstractions.Handlers;

public interface IQueryHandler<TResponse>
    where TResponse : class
{
    Task<Result> Handle(CancellationToken cancellationToken);
}

public interface IQueryHandler<in TQuery, TResponse>
    where TResponse : class
{
    Task<Result> Handle(TQuery query, CancellationToken cancellationToken);
}
