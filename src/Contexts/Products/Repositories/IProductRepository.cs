using BugStore.Contexts.Products.Entities;

namespace BugStore.Contexts.Products.Repositories;

public interface IProductRepository
{
    Task<IEnumerable<Product>?> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        
    Task DeleteAsync(Product product, CancellationToken cancellationToken);
    Task SaveAsync(Product product, CancellationToken cancellationToken);
    Task UpdateAsync(Product product, CancellationToken cancellationToken);
}
