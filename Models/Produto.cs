namespace ApiProdutos.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public double Preco { get; set; }
        public int CategoriaId { get; set; }

        public Categoria? Categoria { get; set; }
        public ICollection<ItemVenda> Itens { get; set; } = new List<ItemVenda>();
        public ICollection<Avaliacao> Avaliacoes { get; set; } = new List<Avaliacao>();
    }
}
