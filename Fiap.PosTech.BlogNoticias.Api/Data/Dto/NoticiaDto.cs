using System.ComponentModel.DataAnnotations;

namespace Fiap.PosTech.BlogNoticias.Api.Data.Dto
{
    public class NoticiaDto
    {
        [Required]
        public string? Titulo { get; set; }
        [Required]
        public string? Conteudo { get; set; }
        [Required]
        public DateTime DataPublicacao { get; set; }
        [Required]
        public string? Autor { get; set; }
    }
}
