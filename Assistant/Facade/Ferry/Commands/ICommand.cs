using System;
using System.Threading.Tasks;
using Rovecode.Assistant.Facade.Domain.Commands;
using Rovecode.Assistant.Facade.Domain.Messages;
using Rovecode.Assistant.Facade.Ferry.Contexts;

namespace Rovecode.Assistant.Facade.Ferry.Commands
{
    public interface ICommand
    {
        public ICommandInfo Info { get; }

        public IDispatchMessage Execute(ICommandContext context);
    }
}
