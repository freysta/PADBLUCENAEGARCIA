namespace ApiProdutos.Dtos.Responses
{
    public class VendaResponseDto
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public int UsuarioId { get; set; }
        public UsuarioResponseDto? Usuario { get; set; }
        public List<ItemVendaResponseDto> Itens { get; set; } = new List<ItemVendaResponseDto>();
    }
}
