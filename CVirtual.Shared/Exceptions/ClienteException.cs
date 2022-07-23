using System;
using CVirtual.Shared.Enuns;

namespace CVirtual.Shared.Exceptions
{
    public class ClienteException : ExceptionBase
    {
        public ClienteException()
        {

        }

        public ClienteException(string MessageInfo) : base(MessageInfo)
        {

        }

        public ClienteException(string MessageInfo, ExceptionInfoType ExceptionType) : base(MessageInfo, ExceptionType)
        {

        }
    }
}