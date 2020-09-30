using System;

namespace Rovecode.Assistant.Facade.Domain.Common
{
    public interface IDatabaseModernEntity : IDatabaseEntity
    {
        Version MinVersion { get; set; }

        DateTime CreatedTime { get; set; }
        DateTime? LastModifiedTime { get; set; }
    }
}
