using Fiap.PosTech.BlogNoticias.Api.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Fiap.PosTech.BlogNoticias.Testes
{
    public class BlogNoticiasDbTeste
    {
        [Fact]
        public void TestarConexaoComBancoDeDados()
        {
            //Arrange
            string connectionString = "MesmaConnectionStringDoProjetoAPI-BlogNoticiasConnection";
            BlogNoticiasDb db = new BlogNoticiasDb(connectionString);
            bool conectado;

            //Act
            try
            {
                conectado = db.Database.CanConnect();
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível conectar a base de dados. " + ex.Message);

            }

            //Assert
            Assert.True(conectado);
        }
    }
}
