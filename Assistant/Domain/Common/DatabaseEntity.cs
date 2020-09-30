using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;
using Rovecode.Assistant.Facade.Domain.Common;

namespace Rovecode.Assistant.Domain.Common
{
    public class DatabaseEntity : IDatabaseEntity
    {
        [BsonId]
        public ObjectId Id { get; set; }

        public DatabaseEntity()
        {
            //BsonClassMap.RegisterClassMap<IDatabaseEntity>();
        }
    }
}
