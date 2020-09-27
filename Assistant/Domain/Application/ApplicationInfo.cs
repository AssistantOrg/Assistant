using System;
using Rovecode.Assistant.Facade.Domain.Application;

namespace Rovecode.Assistant.Domain.Application
{
    public class ApplicationInfo : IApplicationInfo
    {
        public IApplicationAppInfo Application { get; set; }

        public IApplicationBingInfo Bing { get; set; }

        public IApplicationDatabaseInfo Database { get; set; }
    }
}
