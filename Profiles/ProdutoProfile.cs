using ApiProdutos.Dtos;
using ApiProdutos.Dtos.Responses;
using ApiProdutos.Models;
using AutoMapper;

namespace ApiProdutos.Profiles
{
    public class ProdutoProfile : Profile
    {
        public ProdutoProfile()
        {
            CreateMap<Produto, ProdutoResponseDto>();
            CreateMap<ProdutoDto, Produto>();
        }
    }
}
