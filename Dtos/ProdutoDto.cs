namespace ApiProdutos.Dtos
{
    public class ProdutoDto
    {
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public double Preco { get; set; }
        public int CategoriaId { get; set; }
    }
}
