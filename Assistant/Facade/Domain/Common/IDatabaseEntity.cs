using MongoDB.Bson;

namespace Rovecode.Assistant.Facade.Domain.Common
{
    public interface IDatabaseEntity
    {
        ObjectId Id { get; set; }
    }
}
