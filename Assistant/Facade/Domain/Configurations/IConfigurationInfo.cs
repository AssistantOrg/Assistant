
namespace Rovecode.Assistant.Facade.Domain.Configurations
{
    public interface IConfigurationInfo
    {
        IConfigurationApplicationInfo Application { get; set; }

        IConfigurationBingInfo Bing { get; set; }

        IConfigurationDatabaseInfo Database { get; set; }
    }
}
