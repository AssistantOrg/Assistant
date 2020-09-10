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

        public IAssistantMessage TryExcuteCommands(IEnumerable<ICommandFindResult> commands);

        public Task<IEnumerable<ICommandFindResult>> FindCommandsAsync(IAssistantContext context);

        public Task<IAssistantMessage> TryExcuteCommandsAsync(IEnumerable<ICommandFindResult> commands);
    }
}
