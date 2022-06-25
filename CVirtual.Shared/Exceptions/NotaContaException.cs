using System;

namespace CVirtual.Shared.Exceptions
{
    public class NotaContaException : Exception
    {
        public NotaContaException()
        {

        }
        public NotaContaException(string msg) : base(msg)
        {

        }
    }
}