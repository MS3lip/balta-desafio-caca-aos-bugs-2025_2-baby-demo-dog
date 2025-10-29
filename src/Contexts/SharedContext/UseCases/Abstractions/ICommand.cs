using Balta.Mediator.Abstractions;
using BugStore.Contexts.SharedContext.UseCases.Results;

namespace BugStore.Contexts.SharedContext.UseCases.Abstractions;

public interface ICommand : IRequest<Result>, IBaseCommand;

public interface ICommand<TResult> : IRequest<Result<TResult>>, IBaseCommand where TResult : ICommandResponse;

public interface IBaseCommand;