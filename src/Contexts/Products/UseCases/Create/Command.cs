using BugStore.Contexts.SharedContext.UseCases.Abstractions;

namespace BugStore.Contexts.Products.UseCases.Create;

public sealed record Command(string Title, string Description, string Slug, decimal Price) : ICommand<Response>;
