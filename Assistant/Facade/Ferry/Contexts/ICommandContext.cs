using MongoDB.Driver;
using Rovecode.Assistant.Facade.Domain.Messages;
using Rovecode.Assistant.Facade.Domain.Models;

namespace Rovecode.Assistant.Facade.Ferry.Contexts
{
    public interface ICommandContext
    {
        public IReceiveMessage Message { get; set; }

        public IUser User { get; set; }

        public IApplicationContext AppContext { get; set; }

        //public bool IsExecutable { get; }
    }
}
