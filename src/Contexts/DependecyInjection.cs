using Balta.Mediator;
using Balta.Mediator.Abstractions;
using Balta.Mediator.Extensions;
using BugStore.Contexts.Customers.Repositories;
using BugStore.Contexts.Products.Repositories;
using BugStore.Repositories.Customers;
using BugStore.Repositories.Products;

namespace BugStore.Contexts;

public static class DependecyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddTransient<IMediator, Mediator>();
        
        services.AddTransient<ICustomerRepository, CustomerRepository>();
        services.AddTransient<IProductRepository, ProductRepository>();

        services.AddMediator(typeof(Program).Assembly);

        return services;
    }
}

