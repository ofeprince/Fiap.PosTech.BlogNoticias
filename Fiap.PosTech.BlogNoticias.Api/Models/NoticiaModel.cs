using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Fiap.PosTech.BlogNoticias.Api.Models
{
    [Table("Noticia")]
    public class NoticiaModel
    {
        [Key]
        [Required]
        public int Id { get; set; }
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
