using System;
using System.Linq;
using Assistant.Facade.Configuration;
using Assistant.Facade.Messages;

namespace Assistant.Messages.Contexts
{
    public class AssistantContext : IAssistantContext
    {
        public IMessageContext Message { get; set; } = new MessageContext();

        public IUserContext User { get; set; } = new UserContext();

        public IOptions Options { get; set; }

        public bool IsExecutable => Message.ExcuteAssistantKey == null;
    }
}
