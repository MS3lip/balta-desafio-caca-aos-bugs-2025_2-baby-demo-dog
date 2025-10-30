using Balta.Mediator.Abstractions;
using BugStore.Contexts;
using BugStore.Data;
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
        ? Results.Ok(result.Value)
        : Results.NotFound();
});

app.MapGet("/v1/customers/{id}", async (
    IMediator sender, 
    Guid id) =>
{
    var query = new BugStore.Contexts.Customers.UseCases.GetById.Query(id);
    var result = await sender.SendAsync(query);

    return result.IsSuccess
       ? Results.Ok(result.Value)
       : Results.NotFound();
});

app.MapPost("/v1/customers", async (
    IMediator sender,
    BugStore.Contexts.Customers.UseCases.Create.Command request) =>
{
    var result = await sender.SendAsync(request);

    return result.IsSuccess
       ? Results.Created($"/v1/customers/{result.Value.Id}", $"Customer: {result.Value.Name} Criado com sucesso")
       : Results.BadRequest();
});

app.MapPut("/v1/customers/{id}", async (
    IMediator sender,
    BugStore.Contexts.Customers.UseCases.Update.Command request,
    Guid id) => 
{
    if (id != request.Id)
        return Results.BadRequest("Idenficação do customer inválido");

    var result = await sender.SendAsync(request);

    return result.IsSuccess
       ? Results.Ok($"Customer: {result.Value.Name} Atualizado com sucesso")
       : Results.BadRequest();
});

app.MapDelete("/v1/customers/{id}", async (
    IMediator sender,
    Guid id) =>
{
    var command = new BugStore.Contexts.Customers.UseCases.Delete.Command(id);
    var result = await sender.SendAsync(command);

    return result.IsSuccess
       ? Results.Ok($"{result.Value.Name} Deletado com sucesso")
       : Results.BadRequest();
});

app.MapGet("/v1/products", async (IMediator sender) => {

    var query = new BugStore.Contexts.Products.UseCases.Get.Query();
    var result = await sender.SendAsync(query);

    return result.IsSuccess
        ? Results.Ok(result.Value)
        : Results.NotFound();
});

app.MapGet("/v1/products/{id}", async (
    IMediator sender,
    Guid id) =>
{
    var query = new BugStore.Contexts.Products.UseCases.GetById.Query(id);
    var result = await sender.SendAsync(query);

    return result.IsSuccess
       ? Results.Ok(result.Value)
       : Results.NotFound();
});

app.MapPost("/v1/products", async (
    IMediator sender,
    BugStore.Contexts.Products.UseCases.Create.Command request) =>
{
    var result = await sender.SendAsync(request);

    return result.IsSuccess
       ? Results.Created($"/v1/products/{result.Value.Id}", $"{result.Value.Title} Criado com sucesso")
       : Results.BadRequest();
});

app.MapPut("/v1/products/{id}", async (
    IMediator sender,
    BugStore.Contexts.Products.UseCases.Update.Command request,
    Guid id) =>
{
    if (id != request.Id)
        return Results.BadRequest("Idenficação do produto inválido");

    var result = await sender.SendAsync(request);

    return result.IsSuccess
       ? Results.Ok($"{result.Value.Title} Atualizado com sucesso")
       : Results.BadRequest();
});

app.MapDelete("/v1/products/{id}", async (
    IMediator sender,
    Guid id) =>
{
    var command = new BugStore.Contexts.Products.UseCases.Delete.Command(id);
    var result = await sender.SendAsync(command);

    return result.IsSuccess
       ? Results.Ok($"{result.Value.Title} Deletado com sucesso")
       : Results.BadRequest();
});

app.MapGet("/v1/orders/{id}", () => "Hello World!");
app.MapPost("/v1/orders", () => "Hello World!");

app.Run();
