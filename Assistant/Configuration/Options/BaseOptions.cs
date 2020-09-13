using System;
using System.Collections.Generic;
using Assistant.Facade.Configuration;

namespace Assistant.Configuration.Options
{
    public class BaseOptions : IOptions
    {
        public string Language { get; set; }

        public IEnumerable<IEnumerable<string>> ExecuteAssistantKeys { get; set; }

        public string BingToken { get; set; }
    }
}
