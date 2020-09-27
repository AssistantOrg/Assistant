using System;
using MongoDB.Bson;
using Rovecode.Assistant.Facade.Domain.Common;

namespace Rovecode.Assistant.Facade.Domain.Persistence
{
    public interface IStorageServiceEntity<T> : IDatabaseModernEntiry
    {
        public ObjectId UserId { get; set; }

        public string CommandPath { get; set; }

        public T Data { get; set; }
    }
}
