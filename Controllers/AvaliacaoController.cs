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
    [Route("v{version:apiVersion}/avaliacoes")]
    public class AvaliacaoController : ControllerBase
    {
        private readonly AvaliacaoService _service;

        public AvaliacaoController(AvaliacaoService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] AvaliacaoDto dto)
        {
            var result = await _service.Create(dto);
            return Ok(new { mensagem = "Avaliacao criada com sucesso", avaliacao = result });
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            var avaliacoes = await _service.FindAll();
            return Ok(avaliacoes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId(int id)
        {
            var avaliacao = await _service.FindById(id);
            if (avaliacao == null)
                return NotFound(new { mensagem = $"Avaliacao com ID {id} não encontrada" });

            return Ok(avaliacao);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletar(int id)
        {
            var success = await _service.Delete(id);
            if (!success)
                return NotFound(new { mensagem = $"Avaliacao com ID {id} não encontrada" });

            return Ok(new { mensagem = $"Avaliacao {id} removida" });
        }
    }
}
