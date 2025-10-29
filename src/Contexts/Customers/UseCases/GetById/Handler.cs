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
            return Result.Failure<Response>(new Error);

        var customer = result.Value;
        return Result.Success(new Response(customer.Id, customer.Name, customer.Email, customer.Phone, customer.BirthDate));
    }
}
