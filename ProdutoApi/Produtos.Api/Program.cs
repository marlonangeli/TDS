using Hellang.Middleware.ProblemDetails;
using Produtos.Api.Extensions;
using Produtos.Api.Helpers;
using Produtos.Domain.Dto;
using Produtos.Domain.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApiProblemDetails();

var produtos = ProdutoHelper.GetProdutos();

builder.Services.AddSingleton(produtos);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseProblemDetails();
//app.UseStatusCodePages();
app.UseHttpsRedirection();

app.MapGet("/produto", () => Results.Ok(produtos)) 
.WithName("GetProdutos")
.Produces(StatusCodes.Status200OK, typeof(List<Produto>));

app.MapGet("/produto/{id}", (int id) =>
{
    var p = produtos.FirstOrDefault(p => p.Id == id);
    if (p == null)
        return Results.NotFound();
    
    return Results.Ok(p);
})
.WithName("GetProduto")
.Produces(StatusCodes.Status200OK, typeof(Produto))
.Produces(StatusCodes.Status404NotFound);

app.MapPost("produto", (CreateProduto produto) =>
{
    var id = produtos.Max(p => p.Id) + 1;
    var novoProduto = new Produto
    {
        Id = id,
        Nome = produto.Nome,
        Preco = produto.Preco,
        Quantidade = produto.Quantidade
    };
    novoProduto.Validate();
    produtos.Add(novoProduto);
    return Results.CreatedAtRoute("CreateProduto", value: novoProduto);
})
.WithName("CreateProduto")
.Produces(StatusCodes.Status201Created, typeof(Produto))
.Produces(StatusCodes.Status400BadRequest);

app.MapPut("produto/{id}", (int id, UpdateProduto produto) =>
{
    produto.Validate();
    var p = produtos.FirstOrDefault(p => p.Id == id);
    if (p == null)
        return Results.NotFound();

    p.Nome = produto.Nome;
    p.Preco = produto.Preco;
    p.Quantidade = produto.Quantidade;
    return Results.NoContent();
})
.WithName("UpdateProduto")
.Produces(StatusCodes.Status204NoContent)
.Produces(StatusCodes.Status400BadRequest)
.Produces(StatusCodes.Status404NotFound);

app.MapDelete("produto/{id}", (int id) =>
{
    var p = produtos.FirstOrDefault(p => p.Id == id);
    if (p == null)
        return Results.NotFound();

    produtos.Remove(p);
    return Results.NoContent();
})
.WithName("DeleteProduto")
.Produces(StatusCodes.Status204NoContent)
.Produces(StatusCodes.Status404NotFound);

app.Run();
