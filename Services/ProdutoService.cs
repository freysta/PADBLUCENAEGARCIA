using ApiProdutos.DataContexts;
using ApiProdutos.Dtos;
using ApiProdutos.Dtos.Responses;
using ApiProdutos.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ApiProdutos.Services
{
    public class ProdutoService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ProdutoService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ICollection<ProdutoResponseDto>> FindAll()
        {
            var list = await _context.Produtos.Include(p => p.Categoria).ToListAsync();
            return _mapper.Map<ICollection<ProdutoResponseDto>>(list);
        }

        public async Task<ProdutoResponseDto?> FindById(int id)
        {
            var entity = await _context.Produtos.Include(p => p.Categoria).FirstOrDefaultAsync(p => p.Id == id);
            return entity == null ? null : _mapper.Map<ProdutoResponseDto>(entity);
        }

        public async Task<ProdutoResponseDto> Create(ProdutoDto dto)
        {
            var entity = _mapper.Map<Produto>(dto);
            _context.Produtos.Add(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProdutoResponseDto>(entity);
        }

        public async Task<ProdutoResponseDto?> Update(int id, ProdutoDto dto)
        {
            var entity = await _context.Produtos.FindAsync(id);
            if (entity == null) return null;

            _mapper.Map(dto, entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProdutoResponseDto>(entity);
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await _context.Produtos.FindAsync(id);
            if (entity == null) return false;

            _context.Produtos.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
