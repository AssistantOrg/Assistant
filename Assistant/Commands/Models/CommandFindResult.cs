using System;
using System.Collections.Generic;
using Assistant.Facade.Commands;
using Assistant.Facade.Messages;

namespace Assistant.Commands.Models
{
    public class CommandFindResult : ICommandFindResult
    {
        public ICommand Command { get; set; }

        public IEnumerable<string> ExecuteCommandKey { get; set; }
    }
}
