using System;
using Rovecode.Assistant.Facade.Domain.Configurations;

namespace Rovecode.Assistant.Domain.Configurations
{
    public class ConfigurationBingInfo : IConfigurationBingInfo
    {
        public Uri Link { get; set; }
        public string Token { get; set; }
    }
}
