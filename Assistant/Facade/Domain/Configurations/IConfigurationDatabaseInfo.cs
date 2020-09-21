using System;

namespace Rovecode.Assistant.Facade.Domain.Configurations
{
    public interface IConfigurationDatabaseInfo
    {
        Uri ConnectionLink { get; set; }
        string Name { get; set; }
    }
}
