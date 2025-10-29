using BugStore.Contexts.SharedContext.UseCases.Abstractions;

namespace BugStore.Contexts.Customers.UseCases.GetById;

public sealed record Query(Guid Id) : IQuery<Response>;

