using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiap.PosTech.BlogNoticias.Api.Models
{
    [Table("Usuario")]
    public class UsuarioModel
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string? Nome { get; set; }
        [Required]
        public string? Senha { get; set; }
        public string? Genero { get; set; }
    }
}
