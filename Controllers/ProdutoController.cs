using Microsoft.AspNetCore.Mvc;
using ApiProdutos.Dtos;
using ApiProdutos.Services;
using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;

namespace ApiProdutos.Controllers
{
    [Authorize]
    [ApiController]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/produtos")]
    public class ProdutoController : ControllerBase
    {
        private readonly ProdutoService _service;

        public ProdutoController(ProdutoService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] ProdutoDto dto)
        {
            var result = await _service.Create(dto);
            return Ok(new { mensagem = "Produto criado com sucesso", produto = result });
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            var produtos = await _service.FindAll();
            return Ok(produtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId(int id)
        {
            var produto = await _service.FindById(id);
            if (produto == null)
                return NotFound(new { mensagem = $"Produto com ID {id} não encontrado" });

            return Ok(produto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, [FromBody] ProdutoDto dto)
        {
            var produto = await _service.Update(id, dto);
            if (produto == null)
                return NotFound(new { mensagem = $"Produto com ID {id} não encontrado" });

            return Ok(new { mensagem = $"Produto {id} atualizado", produto });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletar(int id)
        {
            var success = await _service.Delete(id);
            if (!success)
                return NotFound(new { mensagem = $"Produto com ID {id} não encontrado" });

            return Ok(new { mensagem = $"Produto {id} removido" });
        }
    }
}
