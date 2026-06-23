namespace ApiProdutos.Dtos
{
    public class AvaliacaoDto
    {
        public int UsuarioId { get; set; }
        public int ProdutoId { get; set; }
        public int Nota { get; set; }
        public string Comentario { get; set; } = string.Empty;
    }
}
