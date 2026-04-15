using Microsoft.AspNetCore.Mvc;

namespace ApiProdutos.Controllers
{
    [ApiController]
    [Route("produtos")]
    public class ProdutoController : ControllerBase
    {
        [HttpPost]
        public IActionResult Criar([FromBody] object produto)
        {
            return Ok(new { mensagem = "Produto criado com sucesso" });
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(new List<object>());
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, [FromBody] object produto)
        {
            return Ok(new { mensagem = $"Produto {id} atualizado" });
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            return Ok(new { mensagem = $"Produto {id} removido" });
        }
    }
}
