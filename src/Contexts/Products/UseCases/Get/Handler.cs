using BugStore.Contexts.Products.Repositories;
using BugStore.Contexts.SharedContext.UseCases.Abstractions;
using BugStore.Contexts.SharedContext.UseCases.Results;

namespace BugStore.Contexts.Products.UseCases.Get
{
    public class Handler(IProductRepository repository) : IQueryHandler<Query, Response>
    {
        public async Task<Result<Response>> HandleAsync(Query request, CancellationToken cancellationToken = default)
        {
            var result = await repository.GetAllAsync(cancellationToken);
            if(result is null)
                return Result.Failure<Response>(Error.NullValue);

            var customers = new Response(result);
            return Result.Success(customers);
        }
        
    }
}
