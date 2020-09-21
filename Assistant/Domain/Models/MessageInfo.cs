using System;
using System.Collections.Generic;
using Rovecode.Assistant.Facade.Domain.Models;

namespace Rovecode.Assistant.Domain.Models
{
    public class MessageInfo : IMessageInfo
    {
        public IEnumerable<string> ExcuteAssistantKey { get; set; }

        public IEnumerable<string> ExcuteCommandKey { get; set; }

        public IEnumerable<string> CommandKey { get; set; }

        public IEnumerable<string> TextKey { get; set; }
    }
}
