using System;
using MongoDB.Bson;
using Rovecode.Assistant.Domain.Common;
using Rovecode.Assistant.Facade.Domain.Persistence;

namespace Rovecode.Assistant.Domain.Persistence
{
    public class StorageServiceEntity<T> : DatabaseModernEntity, IStorageServiceEntity<T>
    {
        public ObjectId UserId { get; set; }

        public string CommandPath { get; set; }

        public T Data { get; set; }
    }
}
