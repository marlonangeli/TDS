using Produtos.Domain.Dto;
using Produtos.Domain.Entities;

namespace Produtos.Api.Helpers;

public static class ProdutoHelper
{
    public static List<Produto> GetProdutos()
    {
        return new List<Produto>
        {
            new()
            {
                Id = 1,
                Nome = "Maçã",
                Preco = 2.39m,
                Quantidade = 10
            },
            new()
            {
                Id = 2,
                Nome = "Laranja",
                Preco = 3.89m,
                Quantidade = 20
            },
            new()
            {
                Id = 3,
                Nome = "Pipoca",
                Preco = 6.49m,
                Quantidade = 5
            },
            new()
            {
                Id = 4,
                Nome = "Coca-Cola",
                Preco = 5.99m,
                Quantidade = 15
            },
        };
    }

    public static void Validate(this Produto produto)
    {
        if (produto == null) { throw new ArgumentNullException(nameof(produto)); }
        if (string.IsNullOrWhiteSpace(produto.Nome)) { throw new ArgumentException("Nome não pode ser nulo ou vazio", nameof(produto.Nome)); }
        if (produto.Preco <= 0) { throw new ArgumentException("Preço deve ser maior que zero", nameof(produto.Preco)); }
        if (produto.Quantidade <= 0) { throw new ArgumentException("Quantidade deve ser maior que zero", nameof(produto.Quantidade)); }
    }

    public static void Validate(this UpdateProduto produto)
    {
        if (produto == null) { throw new ArgumentNullException(nameof(produto)); }
        if (string.IsNullOrWhiteSpace(produto.Nome)) { throw new ArgumentException("Nome não pode ser nulo ou vazio", nameof(produto.Nome)); }
        if (produto.Preco <= 0) { throw new ArgumentException("Preço deve ser maior que zero", nameof(produto.Preco)); }
        if (produto.Quantidade <= 0) { throw new ArgumentException("Quantidade deve ser maior que zero", nameof(produto.Quantidade)); }
    }
}