using Fiap.PosTech.BlogNoticias.Api.Models;

namespace Fiap.PosTech.BlogNoticias.Api.Interfaces
{
    public interface IJwtService
    {
        string GetToken(UsuarioModel usuario);
    }
}
