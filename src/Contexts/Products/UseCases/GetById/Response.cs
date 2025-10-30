using BugStore.Contexts.SharedContext.UseCases.Abstractions;

namespace BugStore.Contexts.Products.UseCases.GetById;

public sealed record Response(Guid Id, string Title, string Description, string Slug, decimal Price) : IQueryResponse;