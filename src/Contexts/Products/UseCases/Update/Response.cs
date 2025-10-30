using BugStore.Contexts.SharedContext.UseCases.Abstractions;

namespace BugStore.Contexts.Products.UseCases.Update;

public sealed record Response(Guid Id, string Title, string Description, string Slug, decimal Price) : ICommandResponse;