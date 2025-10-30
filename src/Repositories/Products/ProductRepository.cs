using BugStore.Contexts.Products.Entities;
using BugStore.Contexts.Products.Repositories;
using BugStore.Data;
using Microsoft.EntityFrameworkCore;

namespace BugStore.Repositories.Products;

public class ProductRepository(AppDbContext context) : IProductRepository
{
    public async Task DeleteAsync(Product product, CancellationToken cancellationToken)
    {
        context.Products.Remove(product);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task<IEnumerable<Product>?> GetAllAsync(CancellationToken cancellationToken = default)
        => await context.Products.AsNoTracking().ToListAsync(cancellationToken);

    public async Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        => await context.Products.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id, cancellationToken);

    public async Task SaveAsync(Product product, CancellationToken cancellationToken)
    {
        await context.Products.AddAsync(product, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(Product product, CancellationToken cancellationToken)
    {
        context.Products.Update(product);
        await context.SaveChangesAsync(cancellationToken);
    }
}

