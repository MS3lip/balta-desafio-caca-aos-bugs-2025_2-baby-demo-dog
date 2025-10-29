using Balta.Mediator.Abstractions;
using BugStore.Contexts.SharedContext.UseCases.Results;

namespace BugStore.Contexts.SharedContext.UseCases.Abstractions;

public interface ICommandHandler<in TCommand> : IHandler<TCommand, Result> where TCommand : ICommand
{
}

public interface ICommandHandler<in TCommand, TResponse> : IHandler<TCommand, Result<TResponse>>
    where TCommand : ICommand<TResponse>
    where TResponse : ICommandResponse
{
}