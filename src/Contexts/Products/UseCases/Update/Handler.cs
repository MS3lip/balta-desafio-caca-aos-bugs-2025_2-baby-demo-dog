using BugStore.Contexts.Products.Repositories;
using BugStore.Contexts.SharedContext.UseCases.Abstractions;
using BugStore.Contexts.SharedContext.UseCases.Results;

namespace BugStore.Contexts.Products.UseCases.Update;

public class Handler(IProductRepository repository) : ICommandHandler<Command, Response>
{
    public async Task<Result<Response>> HandleAsync(Command request, CancellationToken cancellationToken = default)
    {
        var product = await repository.GetByIdAsync(request.Id, cancellationToken);
        if (product is null)
            return Result.Failure<Response>(new Error("404", "Product not found."));

        product.Title = request.Title;
        product.Description = request.Description;
        product.Slug = request.Slug;
        product.Price = request.Price;

        await repository.UpdateAsync(product, cancellationToken);       
        
        return Result.Success(new Response(product.Id, product.Title, product.Description, product.Slug, request.Price));
    }
}