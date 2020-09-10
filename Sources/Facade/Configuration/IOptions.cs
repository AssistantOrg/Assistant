using System;
using System.Collections.Generic;

namespace Assistant.Facade.Configuration
{
    public interface IOptions
    {
        public string Language { get; set; }

        public IEnumerable<string> ExecuteKey { get; set; }
    }
}
