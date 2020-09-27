using MongoDB.Driver;
using Rovecode.Assistant.Facade.Domain.Messages;
using Rovecode.Assistant.Facade.Domain.Models;
using Rovecode.Assistant.Facade.Ferry.Managers;

namespace Rovecode.Assistant.Facade.Ferry.Contexts
{
    public interface ICommandContext
    {
        public IReceiveMessage Message { get; set; }

        public IUser User { get; set; }

        public IApplicationContext Configuration { get; set; }

        //public bool IsExecutable { get; }
    }
}
