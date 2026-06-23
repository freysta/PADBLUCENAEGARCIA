using ApiProdutos.DataContexts;
using ApiProdutos.Dtos;
using ApiProdutos.Dtos.Responses;
using ApiProdutos.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ApiProdutos.Services
{
    public class VendaService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public VendaService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ICollection<VendaResponseDto>> FindAll()
        {
            var list = await _context.Vendas.Include(v => v.Usuario).Include(v => v.Itens).ThenInclude(i => i.Produto).ToListAsync();
            return _mapper.Map<ICollection<VendaResponseDto>>(list);
        }

        public async Task<VendaResponseDto?> FindById(int id)
        {
            var entity = await _context.Vendas.Include(v => v.Usuario).Include(v => v.Itens).ThenInclude(i => i.Produto).FirstOrDefaultAsync(v => v.Id == id);
            return entity == null ? null : _mapper.Map<VendaResponseDto>(entity);
        }

        public async Task<VendaResponseDto> Create(VendaDto dto)
        {
            var entity = _mapper.Map<Venda>(dto);
            _context.Vendas.Add(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<VendaResponseDto>(entity);
        }
        
        public async Task<bool> Delete(int id)
        {
            var entity = await _context.Vendas.FindAsync(id);
            if (entity == null) return false;

            _context.Vendas.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
