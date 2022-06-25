using System;

namespace CVirtual.Shared.Exceptions
{
    public class ClienteException : Exception
    {
        public ClienteException()
        {

        }

        public ClienteException(string msg) : base(msg)
        {

        }
    }
}