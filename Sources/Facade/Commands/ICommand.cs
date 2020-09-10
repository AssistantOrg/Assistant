using System;
using Assistant.Facade.Messages;

namespace Assistant.Facade.Commands
{
    public interface ICommand
    {
        public ICommandInfo Info { get; }

        public IAssistantMessage Execute(IAssistantContext context);
    }
}
