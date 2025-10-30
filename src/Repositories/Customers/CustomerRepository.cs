using BugStore.Contexts.Customers.Entities;
using BugStore.Contexts.Customers.Repositories;
using BugStore.Data;
using Microsoft.EntityFrameworkCore;

namespace BugStore.Repositories.Customers;

public class CustomerRepository(AppDbContext context) : ICustomerRepository
{
    public async Task DeleteAsync(Customer customer,  CancellationToken cancellationToken)
    {
        context.Customers.Remove(customer);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task<IEnumerable<Customer>?> GetAllAsync(CancellationToken cancellationToken = default)
        => await context.Customers.AsNoTracking().ToListAsync(cancellationToken);

    public async Task<Customer?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        => await context.Customers.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id, cancellationToken);

    public async Task SaveAsync(Customer customer, CancellationToken cancellationToken)
    {
        await context.Customers.AddAsync(customer, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(Customer customer, CancellationToken cancellationToken)
    {
        context.Customers.Update(customer);
        await context.SaveChangesAsync(cancellationToken);
    }
}

