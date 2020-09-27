using MongoDB.Driver;
using Rovecode.Assistant.Facade.Domain.Application;
using Rovecode.Assistant.Facade.Ferry.Managers;

namespace Rovecode.Assistant.Facade.Ferry.Contexts
{
    public interface IApplicationContext
    {
        ICommandsManager Manager { get; set; }

        IMongoDatabase Database { get; set; }

        IApplicationInfo Info { get; set; }
    }
}
