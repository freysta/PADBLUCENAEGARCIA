using ApiProdutos.Dtos;
using ApiProdutos.Dtos.Responses;
using ApiProdutos.Models;
using AutoMapper;

namespace ApiProdutos.Profiles
{
    public class CategoriaProfile : Profile
    {
        public CategoriaProfile()
        {
            CreateMap<Categoria, CategoriaResponseDto>();
            CreateMap<CategoriaDto, Categoria>();
        }
    }
}
