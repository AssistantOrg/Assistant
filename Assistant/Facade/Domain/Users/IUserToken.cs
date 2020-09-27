using System;
using MongoDB.Bson;
using Rovecode.Assistant.Facade.Domain.Common;

namespace Rovecode.Assistant.Facade.Domain.Users
{
    public interface IUserToken : IDatabaseEntity
    {
        public ObjectId UserId { get; set; }

        public string Token { get; set; }
    }
}
