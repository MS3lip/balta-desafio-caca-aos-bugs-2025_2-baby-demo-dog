using BugStore.Contexts.SharedContext.UseCases.Abstractions;

namespace BugStore.Contexts.Products.UseCases.GetById;

public record Query(Guid Id) : IQuery<Response>;

