using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Rovecode.Assistant.Application.Attributes;
using Rovecode.Assistant.Application.Exceptions;
using Rovecode.Assistant.Domain.Commands;
using Rovecode.Assistant.Facade.Domain.Commands;
using Rovecode.Assistant.Facade.Domain.Messages;
using Rovecode.Assistant.Facade.Ferry.Commands;
using Rovecode.Assistant.Facade.Ferry.Contexts;
using Rovecode.Assistant.Facade.Ferry.Invokers;
using Rovecode.Assistant.Facade.Persistence.Services;

namespace Rovecode.Assistant.Ferry.Invokers
{
    public class CommandInvoker : ICommandInvoker
    {
        public List<Type> Commands { get; } = new List<Type>();
        public Type DefaultCommand { get; set; }

        public Task<IDispatchMessage> RunAsync(ICommandContext context)
        {
            return TryExecuteCommandsAsync(context, FindCommands(context));
        }

        private List<PropertyInfo> ReflectInjectionProperties(Assembly ass)
        {
            return ass.GetTypes()
                .SelectMany(t => t.GetProperties())
                .Where(m => m.GetCustomAttributes(typeof(InjectionAttribute), false).Length > 0
                    && m.PropertyType.GetInterfaces().Any(x =>
                        x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IStorageService<>)))
                         .ToList();
        }

        private InjectionAttribute ReflectInjectionAttribute(PropertyInfo type)
        {
            return (InjectionAttribute)type.GetCustomAttributes(typeof(InjectionAttribute), false)[0];
        }

        private async Task<IDispatchMessage> ReflectionExecuteCommandAsync(Type type, ICommandContext context)
        {
            var command = ReflectCreateCommand(type);

            // get storages injections
            var injectionsProperties
                = ReflectInjectionProperties(Assembly.GetAssembly(command.GetType()));

            // init injection
            injectionsProperties.ForEach(e => e.SetValue(command,
                Activator.CreateInstance(e.PropertyType,
                    new object[] { context, type })));

            // get injections values
            List<dynamic> values = injectionsProperties
                .FindAll(e => ReflectInjectionAttribute(e).IsAuto)
                    .Select(e => e.GetValue(command))
                      .ToList();

            // load injection storages
            values.ForEach(e => e.Load());

            // execute command
            IDispatchMessage result = await Task.FromResult(command.Execute(context));

            // save injection storages
            values.ForEach(e => e.Save());

            return result;
        }

        private async Task<IDispatchMessage> TryExecuteCommandsAsync(ICommandContext context, List<CommandFindResult> commandsFR)
        {
            // sort list by priority
            commandsFR.Sort((a, b)
                => ReflectCommandInfo(b.CommandType).Priority
                    - ReflectCommandInfo(a.CommandType).Priority);

            //get current execute command
            foreach (CommandFindResult current in commandsFR)
            {
                var ctx = context;

                ctx.Message.ExcuteCommandKey = current.ExecuteCommandKey;

                IDispatchMessage message
                    = await ReflectionExecuteCommandAsync(current.CommandType, context);

                if (message != null)
                {
                    return message;
                }
            }

            return null;
        }

        private IEnumerable<CommandFindResult> CommandsTypesToCommandsFindResults()
        {
            return Commands
                .Select(e => new CommandFindResult { CommandType = e });
        }

        private IEnumerable<CommandFindResult> FindCommandMatchesByCtx(List<CommandFindResult> commandsFR, ICommandContext context)
        {
            return commandsFR
                .FindAll(e => ReflectCommandInfo(e.CommandType).Keys
                    .Any(delegate (IEnumerable<string> key)
                    {
                        bool isFind = KeySearchMatchesInCommand(context.Message.CommandKey, key);
                        if (isFind)
                        {
                            e.ExecuteCommandKey = key;
                        }
                        return isFind;
                    }));
        }

        private List<CommandFindResult> FindCommands(ICommandContext context)
        {
            List<CommandFindResult> commandsFR = CommandsTypesToCommandsFindResults().ToList();

            List<CommandFindResult> findResult = FindCommandMatchesByCtx(commandsFR, context).ToList();

            if (findResult.Count == 0 && DefaultCommand != null)
            {
                findResult.ToList().Add(new CommandFindResult
                {
                    CommandType = DefaultCommand,
                    ExecuteCommandKey = new string[] { },
                });
            }

            return findResult;
        }

        protected static bool KeySearchMatchesInCommand(IEnumerable<string> commandKey, IEnumerable<string> key)
        {
            commandKey = commandKey.Distinct();
            key = key.Distinct();

            return commandKey.Count(e => key.Contains(e)) == key.Count();
        }

        private ICommandInfo ReflectCommandInfo(Type type)
        {
            IfNotCommandTypeThrow(type);

            return (ICommandInfo)type
                .GetProperty("Info", BindingFlags.Public | BindingFlags.Static)
                    .GetValue(null, null);
        }

        private ICommand ReflectCreateCommand(Type type)
        {
            IfNotCommandTypeThrow(type);

            return (ICommand)Activator.CreateInstance(type);
        }

        private bool IsCommandType(Type type)
        {
            return typeof(ICommand).IsAssignableFrom(type);
        }

        private void IfNotCommandTypeThrow(Type type)
        {
            if (!IsCommandType(type))
            {
                throw new AssistantException("not command type");
            }
        }

    }
}
