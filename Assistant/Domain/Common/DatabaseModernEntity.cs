using System;
using MongoDB.Bson.Serialization.Attributes;
using Rovecode.Assistant.Facade.Domain.Common;

namespace Rovecode.Assistant.Domain.Common
{
    public class DatabaseModernEntity : DatabaseEntity, IDatabaseModernEntiry
    {
        public Version MinVersion { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime? LastModifiedTime { get; set; }
    }
}
