using System;
using System.Collections.Generic;

namespace Rovecode.Assistant.Facade.Domain.Messages
{
    public interface IReceiveMessage
    {
        public IEnumerable<string> ExcuteAssistantKey { get; set; }

        public IEnumerable<string> ExcuteCommandKey { get; set; }

        public IEnumerable<string> CommandKey { get; set; }

        public IEnumerable<string> TextKey { get; set; }
    }
}
