using System;
using Assistant.Facade.Messages;

namespace Assistant.Facade.Commands
{
    public interface ICommandFindResult
    {
        public ICommand Command { get; set; }

        public IAssistantContext Context { get; set; }
    }
}
