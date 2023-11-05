namespace Fiap.PosTech.BlogNoticias.Api.Exceptions
{
    public class IdNegativoException : Exception
    {
        public IdNegativoException() { }

        public IdNegativoException(string message) : base(message) { }

        public IdNegativoException(string message, Exception innerException) : base(message, innerException) { }
    }
}
