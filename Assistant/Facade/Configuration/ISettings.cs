using System;
using Assistant.Facade.Commands;

namespace Assistant.Facade.Configuration
{
    public interface ISettings
    {
        ICommandsManager Manager { get; set; }

        IOptions Options { get; set; }
    }
}
