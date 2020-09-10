using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Assistant.Facade.Messages;

namespace Assistant.Facade.Commands
{
    public interface ICommandsManager
    {
        public List<ICommand> Commands { get; }
        public ICommand DefaultCommand { get; set; }

        public IEnumerable<ICommandFindResult> FindCommands(IAssistantContext context);

        public IAssistantMessage TryExecuteCommands(IAssistantContext context, IEnumerable<ICommandFindResult> commands);

        public IAssistantMessage TryFindAndExecuteCommands(IAssistantContext context);

        public Task<IEnumerable<ICommandFindResult>> FindCommandsAsync(IAssistantContext context);

        public Task<IAssistantMessage> TryExecuteCommandsAsync(IAssistantContext context, IEnumerable<ICommandFindResult> commands);

        public Task<IAssistantMessage> TryFindAndExecuteCommandsAsync(IAssistantContext context);
    }
}
