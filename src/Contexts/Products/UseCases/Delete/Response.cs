using BugStore.Contexts.SharedContext.UseCases.Abstractions;

namespace BugStore.Contexts.Products.UseCases.Delete;

public sealed record Response(Guid Id, string Title) : ICommandResponse;