using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Rovecode.Assistant.Facade.Domain.Common;

namespace Rovecode.Assistant.Facade.Domain.Persistence
{
    
    public interface IStorageServiceEntity<T> : IDatabaseEntity
    {
        public ObjectId UserId { get; set; }

        public string CommandPath { get; set; }
        public string DataPath { get; set; }

        public T Data { get; set; }
    }
}
