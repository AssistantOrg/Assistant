using System;
using MongoDB.Bson;
using Rovecode.Assistant.Facade.Domain.Models;

namespace Rovecode.Assistant.Domain.Models
{
    public class UserInfo : IUserInfo
    {
        public ObjectId Id { get; set; }

        public string Name { get; set; }
    }
}
