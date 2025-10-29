using BugStore.Contexts.Customers.Entities;

namespace BugStore.Contexts.Customers.Repositories
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>?> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Customer?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    }
}
