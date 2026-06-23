using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ApiProdutos.Dtos;
using Asp.Versioning;
using ApiProdutos.DataContexts;
using Microsoft.EntityFrameworkCore;

namespace ApiProdutos.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/autenticacao")]
    public class AutenticacaoController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly AppDbContext _context;

        public AutenticacaoController(IConfiguration configuration, AppDbContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == loginDto.Email);
            
            if (usuario == null || usuario.Senha != loginDto.Senha)
            {
                return Unauthorized(new { mensagem = "Credenciais inválidas" });
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var keyStr = _configuration["Jwt:Key"] ?? "chave-super-secreta-para-token-jwt-garagem-ford-api";
            var key = Encoding.UTF8.GetBytes(keyStr);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                    new Claim(ClaimTypes.Email, usuario.Email),
                    new Claim(ClaimTypes.Name, usuario.Nome)
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                Issuer = _configuration["Jwt:Issuer"] ?? "GaragemFord",
                Audience = _configuration["Jwt:Audience"] ?? "GaragemFordApi",
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(new { token = tokenHandler.WriteToken(token) });
        }
    }
}
