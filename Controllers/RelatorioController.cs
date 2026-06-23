using Microsoft.AspNetCore.Mvc;
using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;

namespace ApiProdutos.Controllers
{
    [Authorize]
    [ApiController]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/relatorios")]
    public class RelatorioController : ControllerBase
    {
        [HttpGet("vendas")]
        public IActionResult GetVendas()
        {
            return Ok(new { mensagem = "Relatório de vendas" });
        }
    }
}
