using System;

namespace Model.Exceptions
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