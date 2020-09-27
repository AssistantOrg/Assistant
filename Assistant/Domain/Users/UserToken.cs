using System;
using MongoDB.Bson;
using Rovecode.Assistant.Domain.Common;
using Rovecode.Assistant.Facade.Domain.Users;

namespace Rovecode.Assistant.Domain.Users
{
    public class UserToken : DatabaseEntity, IUserToken
    {
        public ObjectId UserId { get; set; }
        public string Token { get; set; }
    }
}
