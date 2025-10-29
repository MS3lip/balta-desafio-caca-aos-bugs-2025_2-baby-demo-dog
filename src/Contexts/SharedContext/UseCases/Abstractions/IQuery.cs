using Balta.Mediator.Abstractions;
using BugStore.Contexts.SharedContext.UseCases.Results;

namespace BugStore.Contexts.SharedContext.UseCases.Abstractions;

public interface IQuery<TResponse> : IRequest<Result<TResponse>> where TResponse : IQueryResponse;
