using BugStore.Contexts.SharedContext.UseCases.Abstractions;

namespace BugStore.Contexts.Customers.UseCases.Update;

public sealed record Command(Guid Id, string Name, string Email, string Phone, DateTime BirthDate) : ICommand<Response>;
