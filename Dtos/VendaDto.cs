namespace ApiProdutos.Dtos
{
    public class VendaDto
    {
        public int UsuarioId { get; set; }
        public List<ItemVendaDto> Itens { get; set; } = new List<ItemVendaDto>();
    }
}
