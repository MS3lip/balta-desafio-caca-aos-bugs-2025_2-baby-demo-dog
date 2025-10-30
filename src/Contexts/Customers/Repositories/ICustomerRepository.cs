using BugStore.Contexts.Customers.Entities;
using BugStore.Contexts.Customers.UseCases.Create;

namespace BugStore.Contexts.Customers.Repositories
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>?> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Customer?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task SaveAsync(Customer customer, CancellationToken cancellationToken);
    }
}
