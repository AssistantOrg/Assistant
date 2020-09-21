using System;
using MongoDB.Bson;

namespace Rovecode.Assistant.Facade.Domain.Models
{
    public interface IUserInfo
    {
        public ObjectId Id { get; set; }

        public string Name { get; set; }
    }
}
