namespace ApiProdutos.Dtos.Responses
{
    public class AvaliacaoResponseDto
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int ProdutoId { get; set; }
        public int Nota { get; set; }
        public string Comentario { get; set; } = string.Empty;
        public UsuarioResponseDto? Usuario { get; set; }
        public ProdutoResponseDto? Produto { get; set; }
    }
}
