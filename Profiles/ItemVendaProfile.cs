using ApiProdutos.Dtos;
using ApiProdutos.Dtos.Responses;
using ApiProdutos.Models;
using AutoMapper;

namespace ApiProdutos.Profiles
{
    public class ItemVendaProfile : Profile
    {
        public ItemVendaProfile()
        {
            CreateMap<ItemVenda, ItemVendaResponseDto>();
            CreateMap<ItemVendaDto, ItemVenda>();
        }
    }
}
