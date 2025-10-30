using Balta.Mediator.Abstractions;
using BugStore.Contexts;
using BugStore.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(op =>
   op.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddApplication();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/v1/customers", async (IMediator sender) => {
    
    var query = new BugStore.Contexts.Customers.UseCases.Get.Query();
    var result = await sender.SendAsync(query);
    
    return result.IsSuccess
        ? TypedResults.Ok(result.Value)
        : null!;
});

app.MapGet("/v1/customers/{id}", async (
    IMediator sender, 
    Guid id) =>
{
    var query = new BugStore.Contexts.Customers.UseCases.GetById.Query(id);
    var result = await sender.SendAsync(query);

    return result.IsSuccess
       ? TypedResults.Ok(result.Value)
       : null!;
});

app.MapPost("/v1/customers", async (
    IMediator sender,
    BugStore.Contexts.Customers.UseCases.Create.Command request) =>
{
    var result = await sender.SendAsync(request);

    return result.IsSuccess
       ? TypedResults.Created($"Customer {result.Value.Name} [{result.Value.Id}] Criado com sucesso")
       : null!;
});

app.MapPut("/v1/customers/{id}", () => "Hello World!");
app.MapDelete("/v1/customers/{id}", () => "Hello World!");

app.MapGet("/v1/products", () => "Hello World!");
app.MapGet("/v1/products/{id}", () => "Hello World!");
app.MapPost("/v1/products", () => "Hello World!");
app.MapPut("/v1/products/{id}", () => "Hello World!");
app.MapDelete("/v1/products/{id}", () => "Hello World!");

app.MapGet("/v1/orders/{id}", () => "Hello World!");
app.MapPost("/v1/orders", () => "Hello World!");

app.Run();
