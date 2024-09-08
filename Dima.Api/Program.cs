using Dima.Api.Data;
using Dima.Api.Handlers;
using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Requests.Categories;
using Dima.Core.Responses;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var cnnStr = builder
    .Configuration
    .GetConnectionString("DefaultConnection") ?? string.Empty;

builder.Services.AddDbContext<AppDbContext>( x =>
{
    x.UseSqlServer(cnnStr);
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x => { x.CustomSchemaIds(n => n.FullName); });

builder.Services.AddTransient<ICategoryHandler, CategoryHandler>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapPost(
    pattern: "/v1/categories",
    handler: async (
        CreateCategoryRequest request, 
        ICategoryHandler handler) => await handler.CreateAsync(request))    
    .WithName("Categories: Create")
    .WithSummary("Cria uma nova Categoria")
    .Produces<Response<Category?>>();

app.MapPut( 
        pattern: "/v1/categories/{id}",
        handler: async (  long id,
            UpdateCategoryRequest request, 
            ICategoryHandler handler) =>
        {
            request.Id = id;
            return await handler.UpdateAsync(request);
        })
    .WithName("Categories: Update")
    .WithSummary("Altera uma Categoria")
    .Produces<Response<Category?>>();

app.MapDelete(
    pattern: "/v1/categories/{id}",
    handler: async ( long id,        
        ICategoryHandler handler) =>
    {
        var request = new DeleteCategoryRequest
        {
            Id = id,
            UserId = "teste@teste.com"
        };
       
        return await handler.DeleteAsync(request);
    })
    .WithName("Categories: Delete")
    .WithSummary("Exclui uma Categoria")
    .Produces<Response<Category?>>();

app.MapGet(
    pattern: "/v1/categories/{id}",
    handler: async (long id,
        ICategoryHandler handler) =>
    {
        var request = new GetCategoryByIdRequest
        {
            Id = id,
            UserId = "teste2@teste.com"
        };

        return await handler.GetByIdAsync(request);
    })
    .WithName("Categories: Get By Id")
    .WithSummary("Retorna uma Categoria")
    .Produces<Response<Category?>>();

app.MapGet(
    pattern: "/v1/categories",
    handler: async (
        ICategoryHandler handler) =>
    {
        var request = new GetAllCategoriesRequest
        {            
            UserId = "teste2@teste.com"
        };

        return await handler.GetAllAsync(request);
    })
    .WithName("Categories: Get All")
    .WithSummary("Retorna todas as categorias de um usu�rio")
    .Produces<PagedResponse<List<Category>?>>();

app.Run();

