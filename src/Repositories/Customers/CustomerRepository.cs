using BugStore.Contexts.Customers.Entities;
using BugStore.Contexts.Customers.Repositories;
using BugStore.Data;
using Microsoft.EntityFrameworkCore;

namespace BugStore.Repositories.Customers;

public class CustomerRepository(AppDbContext context) : ICustomerRepository
{
    public async Task<IEnumerable<Customer>?> GetAllAsync(CancellationToken cancellationToken = default)
        => await context.Customers.AsNoTracking().ToListAsync(cancellationToken);

    public async Task<Customer?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        => await context.Customers.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
}

