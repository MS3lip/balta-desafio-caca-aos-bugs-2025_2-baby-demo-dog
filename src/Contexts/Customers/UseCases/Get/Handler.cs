using BugStore.Contexts.Customers.Repositories;
using BugStore.Contexts.SharedContext.UseCases.Abstractions;
using BugStore.Contexts.SharedContext.UseCases.Results;

namespace BugStore.Contexts.Customers.UseCases.Get
{
    public class Handler(ICustomerRepository repository) : IQueryHandler<Query, Response>
    {
        public async Task<Result<Response>> HandleAsync(Query request, CancellationToken cancellationToken = default)
        {
            var result = await repository.GetAllAsync(cancellationToken);
            if(result.IsFailure)
                return Result.Failure<Response>(result.Error);

            return Result.Success(new Response(result.Value));
        }
        
    }
}
