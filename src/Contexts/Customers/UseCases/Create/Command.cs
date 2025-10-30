using BugStore.Contexts.SharedContext.UseCases.Abstractions;

namespace BugStore.Contexts.Customers.UseCases.Create;
public sealed record Command(string Name, string Email, string Phone, DateTime BirthDate) : ICommand<Response>;
