using System;
using System.Collections.Generic;

namespace Rovecode.Assistant.Facade.Domain.Configurations
{
    public interface IConfigurationApplicationInfo
    {
        Version Version { get; set; }

        string AppName { get; set; }

        string TargetLanguage { get; set; }

        IEnumerable<IEnumerable<string>> ExecuteAssistantKeys { get; set; }
    }
}
