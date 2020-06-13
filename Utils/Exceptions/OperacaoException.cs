using System;

namespace Utils.Exceptions
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