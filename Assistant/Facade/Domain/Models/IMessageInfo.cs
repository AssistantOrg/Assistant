using System;
using System.Collections.Generic;

namespace Rovecode.Assistant.Facade.Domain.Models
{
    public interface IMessageInfo
    {
        public IEnumerable<string> ExcuteAssistantKey { get; set; }

        public IEnumerable<string> ExcuteCommandKey { get; set; }

        public IEnumerable<string> CommandKey { get; set; }

        public IEnumerable<string> TextKey { get; set; }
    }
}
