using System;
using System.Collections.Generic;
using Rovecode.Assistant.Facade.Domain.Commands;
using Rovecode.Assistant.Facade.Ferry.Commands;

namespace Rovecode.Assistant.Domain.Commands
{
    public class CommandFindResult : ICommandFindResult
    {
        public Type CommandType { get; set; }

        public IEnumerable<string> ExecuteCommandKey { get; set; }
    }
}
