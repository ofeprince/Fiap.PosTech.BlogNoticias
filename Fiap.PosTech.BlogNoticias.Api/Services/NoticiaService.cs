using Fiap.PosTech.BlogNoticias.Api.Data;
using Fiap.PosTech.BlogNoticias.Api.Data.Dto;
using Fiap.PosTech.BlogNoticias.Api.Exceptions;
using Fiap.PosTech.BlogNoticias.Api.Models;

namespace Fiap.PosTech.BlogNoticias.Api.Services
{
    public class NoticiaService
    {
        private readonly BlogNoticiasDb _blogNoticiasDb;
        public NoticiaService(BlogNoticiasDb bd)
        {
            _blogNoticiasDb = bd;
        }

        public List<NoticiaModel> ListarNoticias()
        {
            return _blogNoticiasDb.Noticias.ToList();
        }

        public NoticiaModel? PegarNoticiaPorId(int id)
        {
            ValidarId(id);
            return _blogNoticiasDb.Noticias.FirstOrDefault(x => x.Id == id);
        }

        public NoticiaModel CriarNoticia(NoticiaDto noticia)
        {
            NoticiaModel noticiaModel = new NoticiaModel();
            noticiaModel.DataPublicacao = noticia.DataPublicacao;
            noticiaModel.Autor = noticia.Autor;
            noticiaModel.Titulo = noticia.Titulo;
            noticiaModel.Conteudo = noticia.Conteudo;

            _blogNoticiasDb.Noticias.Add(noticiaModel);
            _blogNoticiasDb.SaveChanges();

            return noticiaModel;
        }

        private void ValidarId(int id)
        {
            if (id < 0)
            {
                throw new IdNegativoException($"Id não pode ser negativo. Valor informado: {id}");
            }

        }
    }
}
