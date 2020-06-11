using System;

namespace Models.Exceptions
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