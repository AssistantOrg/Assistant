using System;
using System.Collections.Generic;

namespace Assistant.Facade.Commands
{
    public interface ICommandInfo
    {
        public int Priority { get; set; }

        public IEnumerable<IEnumerable<string>> Keys { get; set; }
    }
}
