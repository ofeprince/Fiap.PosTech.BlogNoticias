using Fiap.PosTech.BlogNoticias.Api.Data;
using Fiap.PosTech.BlogNoticias.Api.Exceptions;
using Fiap.PosTech.BlogNoticias.Api.Models;
using Fiap.PosTech.BlogNoticias.Api.Services;
using Xunit;

namespace Fiap.PosTech.BlogNoticias.Testes
{
    public class NoticiaTeste
    {
        [Theory]
        [InlineData(-1)]
        [InlineData(-15)]
        [InlineData(-34)]
        public void TestarGetIdNegativoDeveRetornarExcecao(int id)
        {
            // Arrange
            string connectionString = "MesmaConnectionStringDoProjetoAPI-BlogNoticiasConnection";
            BlogNoticiasDb db = new BlogNoticiasDb(connectionString);
            NoticiaService noticiaService = new NoticiaService(db);

            // Assert Act
            Assert.Throws<IdNegativoException>(() => noticiaService.PegarNoticiaPorId(id));
        }

        [Fact]
        public void TestarGetRetornandoRegistro()
        {
            //Arrange
            string connectionString = "MesmaConnectionStringDoProjetoAPI-BlogNoticiasConnection";
            BlogNoticiasDb db = new BlogNoticiasDb(connectionString);
            NoticiaService noticiaService = new NoticiaService(db);
            int id = 1;

            //Act
            NoticiaModel? noticia = noticiaService.PegarNoticiaPorId(id);
            //Assert
            Assert.Equal(noticia?.Id, id);

        }

        [Fact]
        public void TestarListarNoticias()
        {
            //Arrange
            string connectionString = "MesmaConnectionStringDoProjetoAPI-BlogNoticiasConnection";
            BlogNoticiasDb db = new BlogNoticiasDb(connectionString);
            NoticiaService noticiaService = new NoticiaService(db);

            //Act
            List<NoticiaModel> listaNoticias = noticiaService.ListarNoticias();

            //Assert
            Assert.NotNull(listaNoticias);
        }
    }
}
