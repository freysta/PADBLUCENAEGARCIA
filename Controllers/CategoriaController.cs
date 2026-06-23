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
    [Route("v{version:apiVersion}/categorias")]
    public class CategoriaController : ControllerBase
    {
        private readonly CategoriaService _service;

        public CategoriaController(CategoriaService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] CategoriaDto dto)
        {
            var result = await _service.Create(dto);
            return Ok(new { mensagem = "Categoria criada com sucesso", categoria = result });
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            var categorias = await _service.FindAll();
            return Ok(categorias);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId(int id)
        {
            var categoria = await _service.FindById(id);
            if (categoria == null)
                return NotFound(new { mensagem = $"Categoria com ID {id} não encontrada" });

            return Ok(categoria);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, [FromBody] CategoriaDto dto)
        {
            var categoria = await _service.Update(id, dto);
            if (categoria == null)
                return NotFound(new { mensagem = $"Categoria com ID {id} não encontrada" });

            return Ok(new { mensagem = $"Categoria {id} atualizada", categoria });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletar(int id)
        {
            var success = await _service.Delete(id);
            if (!success)
                return NotFound(new { mensagem = $"Categoria com ID {id} não encontrada" });

            return Ok(new { mensagem = $"Categoria {id} removida" });
        }
    }
}
