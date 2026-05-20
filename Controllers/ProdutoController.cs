using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiProdutos.DataContexts;
using ApiProdutos.Models;

namespace ApiProdutos.Controllers
{
    [ApiController]
    [Route("produtos")]
    public class ProdutoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProdutoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] Produto produto)
        {
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();
            return Ok(new { mensagem = "Produto criado com sucesso", produto });
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            var produtos = await _context.Produtos.Include(p => p.Categoria).ToListAsync();
            return Ok(produtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId(int id)
        {
            var produto = await _context.Produtos.Include(p => p.Categoria).FirstOrDefaultAsync(p => p.Id == id);
            if (produto == null)
            {
                return NotFound(new { mensagem = $"Produto com ID {id} não encontrado" });
            }
            return Ok(produto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, [FromBody] Produto produtoAtualizado)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null)
            {
                return NotFound(new { mensagem = $"Produto com ID {id} não encontrado" });
            }

            produto.Nome = produtoAtualizado.Nome;
            produto.Descricao = produtoAtualizado.Descricao;
            produto.Preco = produtoAtualizado.Preco;
            produto.CategoriaId = produtoAtualizado.CategoriaId;

            await _context.SaveChangesAsync();
            return Ok(new { mensagem = $"Produto {id} atualizado", produto });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletar(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null)
            {
                return NotFound(new { mensagem = $"Produto com ID {id} não encontrado" });
            }

            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();
            return Ok(new { mensagem = $"Produto {id} removido" });
        }
    }
}
