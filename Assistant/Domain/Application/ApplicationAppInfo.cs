using System;
using System.Collections.Generic;
using Rovecode.Assistant.Facade.Domain.Application;

namespace Rovecode.Assistant.Domain.Application
{
    public class ApplicationAppInfo : IApplicationAppInfo
    {
        public Version Version { get; set; }

        public string AppName { get; set; }

        public string TargetLanguage { get; set; }

        public IEnumerable<IEnumerable<string>> ExecuteAssistantKeys { get; set; }
    }
}
