using MongoDB.Driver;
using Rovecode.Assistant.Facade.Domain.Configurations;
using Rovecode.Assistant.Facade.Ferry.Managers;

namespace Rovecode.Assistant.Facade.Application.Configurations
{
    public interface IConfiguration
    {
        ICommandsManager Manager { get; set; }

        IMongoDatabase Database { get; set; }

        IConfigurationInfo Info { get; set; }
    }
}
