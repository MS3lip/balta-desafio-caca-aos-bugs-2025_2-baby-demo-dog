using BugStore.Contexts.Customers.Entities;
using BugStore.Contexts.Orders.Entitites;
using BugStore.Contexts.Orders.ValueObjects;
using BugStore.Contexts.Products.Entities;
using Microsoft.EntityFrameworkCore;

namespace BugStore.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Customer> Customers { get; set; } = null!;
    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<Order> Orders { get; set; } = null!;
    public DbSet<OrderLine> OrderLines { get; set; } = null!;
}