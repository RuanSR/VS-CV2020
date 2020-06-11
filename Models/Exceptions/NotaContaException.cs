using System;

namespace Models.Exceptions
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