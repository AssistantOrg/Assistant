using System;
using System.Collections.Generic;

namespace Rovecode.Assistant.Facade.Domain.Commands
{
    public interface ICommandInfo
    {
        public int Priority { get; set; }

        public IEnumerable<IEnumerable<string>> Keys { get; set; }
    }
}
