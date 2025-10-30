using BugStore.Contexts.Products.Entities;
using BugStore.Contexts.SharedContext.UseCases.Abstractions;

namespace BugStore.Contexts.Products.UseCases.Get;

public record Response(IEnumerable<Product>? products) : IQueryResponse;