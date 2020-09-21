using System;
using Rovecode.Assistant.Facade.Domain.Commands;
using Rovecode.Assistant.Facade.Domain.Messages;
using Rovecode.Assistant.Facade.Ferry.Contexts;

namespace Rovecode.Assistant.Facade.Ferry.Commands
{
    public interface ICommand
    {
        public ICommandInfo Info { get; }

        public IAssistantMessage Execute(IAssistantContext context);
    }
}
