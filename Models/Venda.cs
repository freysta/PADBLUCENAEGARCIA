namespace ApiProdutos.Models
{
    public class Venda
    {
        public int Id { get; set; }
        public DateTime Data { get; set; } = DateTime.Now;
        public int UsuarioId { get; set; }

        public Usuario? Usuario { get; set; }
        public ICollection<ItemVenda> Itens { get; set; } = new List<ItemVenda>();
    }
}
