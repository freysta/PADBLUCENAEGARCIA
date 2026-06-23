using ApiProdutos.Dtos;
using ApiProdutos.Dtos.Responses;
using ApiProdutos.Models;
using AutoMapper;

namespace ApiProdutos.Profiles
{
    public class AvaliacaoProfile : Profile
    {
        public AvaliacaoProfile()
        {
            CreateMap<Avaliacao, AvaliacaoResponseDto>();
            CreateMap<AvaliacaoDto, Avaliacao>();
        }
    }
}
