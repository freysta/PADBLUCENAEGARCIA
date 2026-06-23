using ApiProdutos.Dtos;
using ApiProdutos.Dtos.Responses;
using ApiProdutos.Models;
using AutoMapper;

namespace ApiProdutos.Profiles
{
    public class VendaProfile : Profile
    {
        public VendaProfile()
        {
            CreateMap<Venda, VendaResponseDto>();
            CreateMap<VendaDto, Venda>();
        }
    }
}
