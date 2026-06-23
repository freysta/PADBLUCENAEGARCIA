using ApiProdutos.DataContexts;
using ApiProdutos.Dtos;
using ApiProdutos.Dtos.Responses;
using ApiProdutos.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ApiProdutos.Services
{
    public class UsuarioService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public UsuarioService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ICollection<UsuarioResponseDto>> FindAll()
        {
            var list = await _context.Usuarios.ToListAsync();
            return _mapper.Map<ICollection<UsuarioResponseDto>>(list);
        }

        public async Task<UsuarioResponseDto?> FindById(int id)
        {
            var entity = await _context.Usuarios.FindAsync(id);
            return entity == null ? null : _mapper.Map<UsuarioResponseDto>(entity);
        }

        public async Task<UsuarioResponseDto> Create(UsuarioDto dto)
        {
            var entity = _mapper.Map<Usuario>(dto);
            _context.Usuarios.Add(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<UsuarioResponseDto>(entity);
        }

        public async Task<UsuarioResponseDto?> Update(int id, UsuarioDto dto)
        {
            var entity = await _context.Usuarios.FindAsync(id);
            if (entity == null) return null;

            _mapper.Map(dto, entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<UsuarioResponseDto>(entity);
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await _context.Usuarios.FindAsync(id);
            if (entity == null) return false;

            _context.Usuarios.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
