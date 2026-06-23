namespace ApiProdutos.Dtos.Responses
{
    public class ProdutoResponseDto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public double Preco { get; set; }
        public int CategoriaId { get; set; }
        public CategoriaResponseDto? Categoria { get; set; }
    }
}
