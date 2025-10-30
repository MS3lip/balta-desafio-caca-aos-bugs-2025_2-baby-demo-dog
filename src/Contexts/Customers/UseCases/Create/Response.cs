using BugStore.Contexts.SharedContext.UseCases.Abstractions;

namespace BugStore.Contexts.Customers.UseCases.Create;
public sealed record Response(Guid Id, string Name, string Email, string Phone, DateTime BirthDate) : ICommandResponse;