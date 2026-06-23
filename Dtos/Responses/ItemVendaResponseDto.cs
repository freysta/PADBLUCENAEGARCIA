namespace ApiProdutos.Dtos.Responses
{
    public class ItemVendaResponseDto
    {
        public int Id { get; set; }
        public int VendaId { get; set; }
        public int ProdutoId { get; set; }
        public int Quantidade { get; set; }
        public double PrecoUnitario { get; set; }
        public ProdutoResponseDto? Produto { get; set; }
    }
}
