using BugStore.Contexts.Customers.Entities;
using BugStore.Contexts.Customers.Repositories;
using BugStore.Contexts.SharedContext.UseCases.Abstractions;
using BugStore.Contexts.SharedContext.UseCases.Results;

namespace BugStore.Contexts.Customers.UseCases.Create;

public class Handler(ICustomerRepository repository) : ICommandHandler<Command, Response>
{
    public async Task<Result<Response>> HandleAsync(Command request, CancellationToken cancellationToken = default)
    {
        var customer = new Customer() { 
            Id = Guid.NewGuid(),
            Name = request.Name,
            Email = request.Email,
            Phone = request.Phone,
            BirthDate = request.BirthDate
        };

        await repository.SaveAsync(customer, cancellationToken);

        return Result.Success(new Response(customer.Id, customer.Name, customer.Email, customer.Phone, customer.BirthDate));
    }
}