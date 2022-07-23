using CVirtual.Shared.Enuns;
using System;
using System.Collections.Generic;
using System.Text;

namespace CVirtual.Shared.Exceptions
{
    public abstract class ExceptionBase : ApplicationException
    {
        private readonly string _DefaultMessage = "Information";
        private readonly string _ErrortMessage = "Error";

        private readonly string _messageInfo;
        private readonly ExceptionInfoType _exceptionType;

        public ExceptionBase() : base()
        {
        }

        public ExceptionBase(string MessageInfo) : base(MessageInfo)
        {
            this._messageInfo = MessageInfo;
        }

        public ExceptionBase(string MessageInfo, ExceptionInfoType ExceptionType) : base(MessageInfo) 
        {
            this._messageInfo = MessageInfo;
            this._exceptionType = ExceptionType;
        }

        public string GetMessageInfo
        {
            get => _messageInfo;
        }

        public string GetMessageType
        {
            get
            {
                switch (_exceptionType)
                {
                    case ExceptionInfoType.InfoMessage: return _DefaultMessage;
                    case ExceptionInfoType.ErrorMessage: return _ErrortMessage;
                    default: return _DefaultMessage;
                }
            }
        }

    }
}
