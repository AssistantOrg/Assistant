using System;
using Rovecode.Assistant.Facade.Domain.Configurations;

namespace Rovecode.Assistant.Domain.Configurations
{
    public class ConfigurationInfo : IConfigurationInfo
    {
        public IConfigurationApplicationInfo Application { get; set; }

        public IConfigurationBingInfo Bing { get; set; }

        public IConfigurationDatabaseInfo Database { get; set; }
    }
}
