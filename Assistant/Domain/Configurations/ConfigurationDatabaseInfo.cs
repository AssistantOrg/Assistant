using System;
using Rovecode.Assistant.Facade.Domain.Configurations;

namespace Rovecode.Assistant.Domain.Configurations
{
    public class ConfigurationDatabaseInfo : IConfigurationDatabaseInfo
    {
        public Uri ConnectionLink { get; set; }
        public string Name { get; set; }
    }
}
