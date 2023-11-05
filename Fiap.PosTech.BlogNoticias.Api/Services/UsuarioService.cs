using Fiap.PosTech.BlogNoticias.Api.Data;
using Fiap.PosTech.BlogNoticias.Api.Data.Dto;
using Fiap.PosTech.BlogNoticias.Api.Interfaces;
using Fiap.PosTech.BlogNoticias.Api.Models;

namespace Fiap.PosTech.BlogNoticias.Api.Services
{
    public class UsuarioService
    {
        private readonly IJwtService _jwtService;
        private BlogNoticiasDb _blogNoticiasDb;
        public UsuarioService(IJwtService jwt, BlogNoticiasDb bd)
        {
            _jwtService = jwt;
            _blogNoticiasDb = bd;
        }

        public string? Autenticar(UsuarioDto uDto)
        {
            List<UsuarioModel> listaDb = _blogNoticiasDb.Usuarios.ToList();

            UsuarioModel? u = listaDb.FirstOrDefault(x =>
                x.Nome == uDto.Usuario && x.Senha == uDto.Senha);

            if (u != null)
            {
                return _jwtService.GetToken(u);

            }
            else
            {
                return null;
            }
        }
    }
}
