using Microsoft.AspNetCore.Mvc;

namespace ApiProdutos.Controllers
{
    [ApiController]
    [Route("relatorios")]
    public class RelatorioController : ControllerBase
    {
        [HttpGet("vendas")]
        public IActionResult GetVendas()
        {
            return Ok(new { mensagem = "Relatório de vendas" });
        }
    }
}
