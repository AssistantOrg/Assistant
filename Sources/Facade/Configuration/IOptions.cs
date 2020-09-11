using System;
using System.Collections.Generic;

namespace Assistant.Facade.Configuration
{
    public interface IOptions
    {
        public string Language { get; set; }

        public IEnumerable<IEnumerable<string>> ExecuteAssistantKeys { get; set; }
    }
}
