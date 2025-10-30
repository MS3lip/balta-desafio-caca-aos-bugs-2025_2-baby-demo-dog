using BugStore.Contexts.SharedContext.UseCases.Abstractions;

namespace BugStore.Contexts.Customers.UseCases.Delete;

public sealed record Command(Guid Id) : ICommand<Response>;
