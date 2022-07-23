using System;

namespace CVirtual.Shared.Exceptions
{
    public class ActionTypeException : Exception
    {
        public ActionTypeException()
        {

        }
        public ActionTypeException(string msg) : base(msg)
        {

        }
    }
}