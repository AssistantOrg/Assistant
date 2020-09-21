using System;
using Rovecode.Assistant.Facade.Domain.Configurations;

namespace Rovecode.Assistant.Domain.Configurations
{
    public class ConfigurationApplicationInfo : IConfigurationApplicationInfo
    {
        public Version Version { get; set; }

        public string AppName { get; set; }

        public string TargetLanguage { get; set; }

        IEnumerable<string> ExecuteAssistantKeys { get; set; }
    }
}
