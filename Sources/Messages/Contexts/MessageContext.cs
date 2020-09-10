using System;
using System.Collections.Generic;
using Assistant.Facade.Messages;

namespace Assistant.Messages.Contexts
{
    public class MessageContext : IMessageContext
    {
        public IEnumerable<string> ExcuteAssistantKey { get; set; }

        public IEnumerable<string> ExcuteCommandKey { get; set; }

        public IEnumerable<string> CommandKey { get; set; }

        public IEnumerable<string> TextKey { get; set; }

        public override string ToString()
        {
            return string.Join(" ", TextKey);
        }
    }
}
