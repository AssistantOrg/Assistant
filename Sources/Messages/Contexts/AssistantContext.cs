using System;
using System.Linq;
using Assistant.Facade.Messages;

namespace Assistant.Messages.Contexts
{
    public class AssistantContext : IAssistantContext
    {
        public IMessageContext Message { get; set; } = new MessageContext();

        public IUserContext User { get; set; } = new UserContext();
    }
}
