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
    [Route("v{version:apiVersion}/vendas")]
    public class VendaController : ControllerBase
    {
        private readonly VendaService _service;

        public VendaController(VendaService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] VendaDto dto)
        {
            var result = await _service.Create(dto);
            return Ok(new { mensagem = "Venda criada com sucesso", venda = result });
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            var vendas = await _service.FindAll();
            return Ok(vendas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId(int id)
        {
            var venda = await _service.FindById(id);
            if (venda == null)
                return NotFound(new { mensagem = $"Venda com ID {id} não encontrada" });

            return Ok(venda);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletar(int id)
        {
            var success = await _service.Delete(id);
            if (!success)
                return NotFound(new { mensagem = $"Venda com ID {id} não encontrada" });

            return Ok(new { mensagem = $"Venda {id} removida" });
        }
    }
}
