using System;

namespace Model.Exceptions
{
    public class ClienteException : Exception
    {
        public ClienteException()
        {
            
        }

        public ClienteException(string msg) :base(msg)
        {
            
        }
    }
}