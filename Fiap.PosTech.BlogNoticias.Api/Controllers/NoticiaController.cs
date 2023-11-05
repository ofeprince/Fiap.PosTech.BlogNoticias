using Fiap.PosTech.BlogNoticias.Api.Data;
using Fiap.PosTech.BlogNoticias.Api.Data.Dto;
using Fiap.PosTech.BlogNoticias.Api.Models;
using Fiap.PosTech.BlogNoticias.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.PosTech.BlogNoticias.Api.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class NoticiaController : ControllerBase
    {
        private readonly NoticiaService _noticiaBusiness;
        public NoticiaController(IConfiguration config)
        {
            string conn = config.GetConnectionString("BlogNoticiasConnection");
            _noticiaBusiness = new NoticiaService(new BlogNoticiasDb(conn));
        }

        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_noticiaBusiness.ListarNoticias());
        }


        [Authorize]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_noticiaBusiness.PegarNoticiaPorId(id));
        }

        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] NoticiaDto noticia)
        {
            try
            {

                NoticiaModel noticiaCriada = _noticiaBusiness.CriarNoticia(noticia);
                return CreatedAtAction(nameof(Get), new { id = noticiaCriada.Id }, noticiaCriada);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

    }
}
