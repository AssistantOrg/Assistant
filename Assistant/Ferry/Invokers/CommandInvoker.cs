using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rovecode.Assistant.Domain.Commands;
using Rovecode.Assistant.Facade.Domain.Commands;
using Rovecode.Assistant.Facade.Domain.Messages;
using Rovecode.Assistant.Facade.Ferry.Commands;
using Rovecode.Assistant.Facade.Ferry.Contexts;
using Rovecode.Assistant.Facade.Ferry.Invokers;

namespace Rovecode.Assistant.Ferry.Invokers
{
    public class CommandInvoker : ICommandInvoker
    {
        public List<ICommand> Commands { get; } = new List<ICommand>();
        public ICommand DefaultCommand { get; set; }

        public Task<IDispatchMessage> RunAsync(ICommandContext context)
        {
            return TryExecuteCommandsAsync(context, FindCommands(context));
        }

        private async Task<IDispatchMessage> TryExecuteCommandsAsync(ICommandContext context, IEnumerable<ICommandFindResult> commands)
        {
            var list = commands.ToList();

            // sort list by priority
            list.Sort((a, b) => b.Command.Info.Priority - a.Command.Info.Priority);

            IDispatchMessage message = null;

            //get current execute command
            foreach (CommandFindResult current in list)
            {
                var ctx = context;
                ctx.Message.ExcuteCommandKey = current.ExecuteCommandKey;
                message = await Task.FromResult(current.Command.Execute(ctx));
                if (message != null)
                {
                    return message;
                }
            }

            message = await Task.FromResult(DefaultCommand?.Execute(context));

            return message;
        }

        private IEnumerable<ICommandFindResult> FindCommands(ICommandContext context)
        {
            List<CommandFindResult> findResult = Commands
                .Select(e => new CommandFindResult { Command = e })
                    .ToList();

            IEnumerable<CommandFindResult> result =
                findResult.FindAll(e => e.Command.Info.Keys
                    .Any(delegate (IEnumerable<string> key) {
                        bool isFind = KeySearchMatchesInCommand(context.Message.CommandKey, key);
                        if (isFind)
                        {
                            e.ExecuteCommandKey = key;
                        }
                        return isFind;
                    }));

            return result;
        }

        private static bool KeySearchMatchesInCommand(IEnumerable<string> commandKey, IEnumerable<string> key)
        {
            commandKey = commandKey.Distinct();
            key = key.Distinct();

            return commandKey.Count(e => key.Contains(e)) == key.Count();
        }
    }
}
