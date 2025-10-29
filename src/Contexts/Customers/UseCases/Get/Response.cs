using BugStore.Contexts.Customers.Entities;
using BugStore.Contexts.SharedContext.UseCases.Abstractions;

namespace BugStore.Contexts.Customers.UseCases.Get;

public record Response(IEnumerable<Customer>? Customers) : IQueryResponse;