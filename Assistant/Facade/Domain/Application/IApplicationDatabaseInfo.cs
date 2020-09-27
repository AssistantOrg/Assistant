using System;

namespace Rovecode.Assistant.Facade.Domain.Application
{
    public interface IApplicationDatabaseInfo
    {
        public Uri ConnectionLink { get; set; }
        public string Name { get; set; }
    }
}
