using System;
using System.Collections.Generic;
using Rovecode.Assistant.Facade.Domain.Commands;

namespace Rovecode.Assistant.Domain.Commands
{
    public class CommandInfo : ICommandInfo
    {
        public int Priority { get; set; }

        public IEnumerable<IEnumerable<string>> Keys { get; set; }
    }
}
