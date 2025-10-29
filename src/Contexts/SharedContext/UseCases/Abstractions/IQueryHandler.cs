using Balta.Mediator.Abstractions;
using BugStore.Contexts.SharedContext.UseCases.Results;

namespace BugStore.Contexts.SharedContext.UseCases.Abstractions;

public interface IQueryHandler<in TQuery, TResponse> : IHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>
    where TResponse : IQueryResponse;