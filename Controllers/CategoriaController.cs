using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiProdutos.DataContexts;
using ApiProdutos.Models;

namespace ApiProdutos.Controllers
{
    [ApiController]
    [Route("categorias")]
    public class CategoriaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CategoriaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] Categoria categoria)
        {
            _context.Categorias.Add(categoria);
            await _context.SaveChangesAsync();
            return Ok(new { mensagem = "Categoria criada com sucesso", categoria });
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            var categorias = await _context.Categorias.ToListAsync();
            return Ok(categorias);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId(int id)
        {
            var categoria = await _context.Categorias.FindAsync(id);
            if (categoria == null)
            {
                return NotFound(new { mensagem = $"Categoria com ID {id} não encontrada" });
            }
            return Ok(categoria);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, [FromBody] Categoria categoriaAtualizada)
        {
            var categoria = await _context.Categorias.FindAsync(id);
            if (categoria == null)
            {
                return NotFound(new { mensagem = $"Categoria com ID {id} não encontrada" });
            }

            categoria.Nome = categoriaAtualizada.Nome;

            await _context.SaveChangesAsync();
            return Ok(new { mensagem = $"Categoria {id} atualizada", categoria });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletar(int id)
        {
            var categoria = await _context.Categorias.FindAsync(id);
            if (categoria == null)
            {
                return NotFound(new { mensagem = $"Categoria com ID {id} não encontrada" });
            }

            _context.Categorias.Remove(categoria);
            await _context.SaveChangesAsync();
            return Ok(new { mensagem = $"Categoria {id} removida" });
        }
    }
}
