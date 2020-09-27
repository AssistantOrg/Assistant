using System;
using Rovecode.Assistant.Facade.Domain.Application;

namespace Rovecode.Assistant.Domain.Application
{
    public class ApplicationDatabaseInfo : IApplicationDatabaseInfo
    {
        public Uri ConnectionLink { get; set; }
        public string Name { get; set; }
    }
}
