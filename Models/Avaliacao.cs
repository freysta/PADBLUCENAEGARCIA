namespace ApiProdutos.Models
{
    public class Avaliacao
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int ProdutoId { get; set; }
        public int Nota { get; set; }
        public string Comentario { get; set; } = string.Empty;

        public Usuario? Usuario { get; set; }
        public Produto? Produto { get; set; }
    }
}
