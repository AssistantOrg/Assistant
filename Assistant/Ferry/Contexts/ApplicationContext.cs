using System;
using MongoDB.Driver;
using Rovecode.Assistant.Facade.Domain.Application;
using Rovecode.Assistant.Facade.Ferry.Contexts;
using Rovecode.Assistant.Facade.Ferry.Managers;

namespace Rovecode.Assistant.Ferry.Contexts
{
    public class ApplicationContext : IApplicationContext
    {
        public ICommandsManager Manager { get; set; }
        public IMongoDatabase Database { get; set; }
        public IApplicationInfo Info { get; set; }
    }
}
