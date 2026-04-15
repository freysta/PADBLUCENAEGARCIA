namespace ApiProdutos.Models
{
    public class ItemVenda
    {
        public int Id { get; set; }
        public int VendaId { get; set; }
        public int ProdutoId { get; set; }

        public Venda? Venda { get; set; }
        public Produto? Produto { get; set; }
    }
}
