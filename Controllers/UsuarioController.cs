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
    [Route("v{version:apiVersion}/usuarios")]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService _service;

        public UsuarioController(UsuarioService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] UsuarioDto dto)
        {
            var result = await _service.Create(dto);
            return Ok(new { mensagem = "Usuario criado com sucesso", usuario = result });
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            var usuarios = await _service.FindAll();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId(int id)
        {
            var usuario = await _service.FindById(id);
            if (usuario == null)
                return NotFound(new { mensagem = $"Usuario com ID {id} não encontrado" });

            return Ok(usuario);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, [FromBody] UsuarioDto dto)
        {
            var usuario = await _service.Update(id, dto);
            if (usuario == null)
                return NotFound(new { mensagem = $"Usuario com ID {id} não encontrado" });

            return Ok(new { mensagem = $"Usuario {id} atualizado", usuario });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletar(int id)
        {
            var success = await _service.Delete(id);
            if (!success)
                return NotFound(new { mensagem = $"Usuario com ID {id} não encontrado" });

            return Ok(new { mensagem = $"Usuario {id} removido" });
        }
    }
}
