using System;

namespace Model.Exceptions
{
    public class AtendenteException : Exception
    {
        public AtendenteException()
        {
            
        }

        public AtendenteException(string msg) :base(msg)
        {
            
        }
    }
}