using System;
using System.Collections.Generic;

namespace Rovecode.Assistant.Facade.Domain.Application
{
    public interface IApplicationAppInfo
    {
        public Version Version { get; set; }

        public string AppName { get; set; }

        public string TargetLanguage { get; set; }

        public IEnumerable<IEnumerable<string>> ExecuteAssistantKeys { get; set; }
    }
}
