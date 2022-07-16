using CVirtual.Shared.Enuns;
using System;

namespace CVirtual.Shared.Exceptions
{
    public class AtendenteException : ExceptionBase
    {
        public AtendenteException() : base()
        {

        }
        public AtendenteException(string MessageInfo) : base(MessageInfo)
        {

        }

        public AtendenteException(string MessageInfo, ExceptionInfoType ExceptionType) : base(MessageInfo, ExceptionType)
        {

        }
    }
}