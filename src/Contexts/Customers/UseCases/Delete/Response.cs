using BugStore.Contexts.SharedContext.UseCases.Abstractions;

namespace BugStore.Contexts.Customers.UseCases.Delete;

public sealed record Response(Guid Id, string Name) : ICommandResponse;