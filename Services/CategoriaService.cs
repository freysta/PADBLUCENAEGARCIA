using ApiProdutos.DataContexts;
using ApiProdutos.Dtos;
using ApiProdutos.Dtos.Responses;
using ApiProdutos.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ApiProdutos.Services
{
    public class CategoriaService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CategoriaService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ICollection<CategoriaResponseDto>> FindAll()
        {
            var list = await _context.Categorias.ToListAsync();
            return _mapper.Map<ICollection<CategoriaResponseDto>>(list);
        }

        public async Task<CategoriaResponseDto?> FindById(int id)
        {
            var entity = await _context.Categorias.FindAsync(id);
            return entity == null ? null : _mapper.Map<CategoriaResponseDto>(entity);
        }

        public async Task<CategoriaResponseDto> Create(CategoriaDto dto)
        {
            var entity = _mapper.Map<Categoria>(dto);
            _context.Categorias.Add(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<CategoriaResponseDto>(entity);
        }

        public async Task<CategoriaResponseDto?> Update(int id, CategoriaDto dto)
        {
            var entity = await _context.Categorias.FindAsync(id);
            if (entity == null) return null;

            _mapper.Map(dto, entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<CategoriaResponseDto>(entity);
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await _context.Categorias.FindAsync(id);
            if (entity == null) return false;

            _context.Categorias.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
