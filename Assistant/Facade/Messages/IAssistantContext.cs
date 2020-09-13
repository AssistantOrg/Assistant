using System;
using Assistant.Facade.Configuration;

namespace Assistant.Facade.Messages
{
    public interface IAssistantContext
    {
        public IMessageContext Message { get; set; }

        public IUserContext User { get; set; }

        public IOptions Options { get; set; }

        public bool IsExecutable { get; }
    }
}
