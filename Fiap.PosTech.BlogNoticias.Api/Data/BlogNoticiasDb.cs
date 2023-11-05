using Fiap.PosTech.BlogNoticias.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiap.PosTech.BlogNoticias.Api.Data
{
    public class BlogNoticiasDb : DbContext
    {
        private readonly string? _connectionString;

        public BlogNoticiasDb(DbContextOptions<BlogNoticiasDb> opts) : base(opts)
        {
        }

        public BlogNoticiasDb(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
        

        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<NoticiaModel> Noticias { get; set; }
    }
}
