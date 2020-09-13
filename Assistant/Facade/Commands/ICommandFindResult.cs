using System;
using System.Collections.Generic;
using Assistant.Facade.Messages;

namespace Assistant.Facade.Commands
{
    public interface ICommandFindResult
    {
        public ICommand Command { get; set; }

        public IEnumerable<string> ExecuteCommandKey { get; set; }
    }
}
