using BugStore.Contexts.Products.Repositories;
using BugStore.Contexts.Products.Entities;
using BugStore.Contexts.SharedContext.UseCases.Abstractions;
using BugStore.Contexts.SharedContext.UseCases.Results;

namespace BugStore.Contexts.Products.UseCases.Create;

public class Handler(IProductRepository repository) : ICommandHandler<Command, Response>
{
    public async Task<Result<Response>> HandleAsync(Command request, CancellationToken cancellationToken = default)
    {
        var product = new Product() { 
            Id = Guid.NewGuid(),
            Title = request.Title,
            Description = request.Description,
            Slug = request.Slug,
            Price = request.Price
        };

        await repository.SaveAsync(product, cancellationToken);

        return Result.Success(new Response(product.Id, product.Title, product.Description, product.Slug, product.Price));
    }
}