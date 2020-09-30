using MongoDB.Driver;
using Rovecode.Assistant.Facade.Domain.Application;
using Rovecode.Assistant.Facade.Domain.Persistence;
using Rovecode.Assistant.Facade.Ferry.Invokers;

namespace Rovecode.Assistant.Facade.Ferry.Contexts
{
    public interface IApplicationContext
    {
        ICommandInvoker Manager { get; set; }

        IMongoDatabase Database { get; set; }

        IApplicationInfo Info { get; set; }
    }
}
