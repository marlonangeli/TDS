namespace Produtos.Domain.Dto;

public class UpdateProduto
{
    public string Nome { get; set; } = null!;
    public decimal Preco { get; set; }
    public int Quantidade { get; set; }
}