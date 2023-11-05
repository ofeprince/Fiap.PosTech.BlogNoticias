using Fiap.PosTech.BlogNoticias.Api.Interfaces;
using Fiap.PosTech.BlogNoticias.Api.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Fiap.PosTech.BlogNoticias.Api.Services
{
    public class JwtService : IJwtService
    {
        private readonly IConfiguration _configuration;

        public JwtService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GetToken(UsuarioModel usuario)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            string? chave = _configuration.GetSection("JwtSettings").GetSection("Key").Value;
            if (string.IsNullOrEmpty(chave))
            {
                throw new Exception("Sem chave de criptografia");
            }
            byte[] chaveBytes = Encoding.UTF8.GetBytes(chave);

            Claim[] claims = new Claim[]
            {
                new Claim(ClaimTypes.Name, usuario.Nome ?? ""),
                new Claim("OutraClaimQualquer", "ValorDaClaim")
            };

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(15),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(chaveBytes),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
