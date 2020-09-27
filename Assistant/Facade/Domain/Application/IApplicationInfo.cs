using System;

namespace Rovecode.Assistant.Facade.Domain.Application
{
    public interface IApplicationInfo
    {
        public IApplicationAppInfo Application { get; set; }

        public IApplicationBingInfo Bing { get; set; }

        public IApplicationDatabaseInfo Database { get; set; }
    }
}
