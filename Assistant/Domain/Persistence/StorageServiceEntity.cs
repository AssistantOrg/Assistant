using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;
using Rovecode.Assistant.Domain.Common;
using Rovecode.Assistant.Facade.Domain.Persistence;

namespace Rovecode.Assistant.Domain.Persistence
{

    public class StorageServiceEntity<T> : DatabaseEntity, IStorageServiceEntity<T> where T : class
    {
        public ObjectId UserId { get; set; }

        public string CommandPath { get; set; }
        public string DataPath { get; set; }

        public T Data { get; set; }
    }
}
