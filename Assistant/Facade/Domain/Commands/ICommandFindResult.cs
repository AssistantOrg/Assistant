using System;
using System.Collections.Generic;
using Rovecode.Assistant.Facade.Ferry.Commands;

namespace Rovecode.Assistant.Facade.Domain.Commands
{
    public interface ICommandFindResult
    {
        public Type CommandType { get; set; }

        public IEnumerable<string> ExecuteCommandKey { get; set; }
    }
}
