using ApiProdutos.DataContexts;
using ApiProdutos.Dtos;
using ApiProdutos.Dtos.Responses;
using ApiProdutos.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ApiProdutos.Services
{
    public class AvaliacaoService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public AvaliacaoService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ICollection<AvaliacaoResponseDto>> FindAll()
        {
            var list = await _context.Avaliacoes.Include(a => a.Usuario).Include(a => a.Produto).ToListAsync();
            return _mapper.Map<ICollection<AvaliacaoResponseDto>>(list);
        }

        public async Task<AvaliacaoResponseDto?> FindById(int id)
        {
            var entity = await _context.Avaliacoes.Include(a => a.Usuario).Include(a => a.Produto).FirstOrDefaultAsync(a => a.Id == id);
            return entity == null ? null : _mapper.Map<AvaliacaoResponseDto>(entity);
        }

        public async Task<AvaliacaoResponseDto> Create(AvaliacaoDto dto)
        {
            var entity = _mapper.Map<Avaliacao>(dto);
            _context.Avaliacoes.Add(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<AvaliacaoResponseDto>(entity);
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await _context.Avaliacoes.FindAsync(id);
            if (entity == null) return false;

            _context.Avaliacoes.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
