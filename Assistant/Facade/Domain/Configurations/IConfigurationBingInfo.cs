using System;

namespace Rovecode.Assistant.Facade.Domain.Configurations
{
    public interface IConfigurationBingInfo
    {
        Uri Link { get; set; }
        string Token { get; set; }
    }
}
