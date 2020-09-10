using System;

namespace Assistant.Facade.Messages
{
    public interface IAssistantContext
    {
        public IMessageContext Message { get; set; }

        public IUserContext User { get; set; }
    }
}
