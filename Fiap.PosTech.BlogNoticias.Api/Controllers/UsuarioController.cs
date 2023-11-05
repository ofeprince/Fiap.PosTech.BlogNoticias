using Fiap.PosTech.BlogNoticias.Api.Data;
using Fiap.PosTech.BlogNoticias.Api.Data.Dto;
using Fiap.PosTech.BlogNoticias.Api.Interfaces;
using Fiap.PosTech.BlogNoticias.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.PosTech.BlogNoticias.Api.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService _usuarioBusiness;
        public UsuarioController(IJwtService jwt, IConfiguration config)
        {
            string conn = config.GetConnectionString("BlogNoticiasConnection");
            _usuarioBusiness = new UsuarioService(jwt, new BlogNoticiasDb(conn));
        }

        [HttpPost("auth")]
        public IActionResult Post(UsuarioDto usuario)
        {
            string? token = _usuarioBusiness.Autenticar(usuario);

            if (string.IsNullOrEmpty(token))
            {
                return Unauthorized();
            }
            return Ok(token);
        }
    }
}
