using System;
using System.Collections.Generic;

namespace Assistant.Facade.Messages
{
    public interface IMessageContext
    {
        public IEnumerable<string> ExcuteAssistantKey { get; set; }

        public IEnumerable<string> ExcuteCommandKey { get; set; }

        public IEnumerable<string> CommandKey { get; set; }

        public IEnumerable<string> TextKey { get; set; }
    }
}
