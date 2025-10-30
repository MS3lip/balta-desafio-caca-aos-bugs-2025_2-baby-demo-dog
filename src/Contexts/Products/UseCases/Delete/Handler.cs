using BugStore.Contexts.Products.Repositories;
using BugStore.Contexts.SharedContext.UseCases.Abstractions;
using BugStore.Contexts.SharedContext.UseCases.Results;

namespace BugStore.Contexts.Products.UseCases.Delete;

public class Handler(IProductRepository repository) : ICommandHandler<Command, Response>
{
    public async Task<Result<Response>> HandleAsync(Command request, CancellationToken cancellationToken = default)
    {
        var product = await repository.GetByIdAsync(request.Id, cancellationToken);
        if (product is null)
            return Result.Failure<Response>(new Error("404", "Product not found."));

        await repository.DeleteAsync(product, cancellationToken);

        return Result.Success(new Response(product.Id, product.Title));
    }
}