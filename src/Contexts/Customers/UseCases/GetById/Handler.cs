using BugStore.Contexts.Customers.Repositories;
using BugStore.Contexts.SharedContext.UseCases.Abstractions;
using BugStore.Contexts.SharedContext.UseCases.Results;

namespace BugStore.Contexts.Customers.UseCases.GetById;

public class Handler(ICustomerRepository repository) : IQueryHandler<Query, Response>
{
    public async Task<Result<Response>> HandleAsync(Query request, CancellationToken cancellationToken = default)
    {
        var result = await repository.GetByIdAsync(request.Id, cancellationToken);
        if (result is null)
            return Result.Failure<Response>(new Error("404", "Customer not found."));

        var customer = new Response(result.Id, result.Name, result.Email, result.Phone, result.BirthDate);
        return Result.Success(customer);
    }
}
