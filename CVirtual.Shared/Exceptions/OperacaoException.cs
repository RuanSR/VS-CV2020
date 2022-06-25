using System;

namespace CVirtual.Shared.Exceptions
{
    public class OperacaoException : Exception
    {
        public OperacaoException()
        {

        }
        public OperacaoException(string msg) : base(msg)
        {

        }
    }
}