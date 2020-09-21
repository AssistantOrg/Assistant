using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Rovecode.Assistant.Facade.Domain.Commands;
using Rovecode.Assistant.Facade.Domain.Messages;
using Rovecode.Assistant.Facade.Ferry.Commands;
using Rovecode.Assistant.Facade.Ferry.Contexts;

namespace Rovecode.Assistant.Facade.Ferry.Managers
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
