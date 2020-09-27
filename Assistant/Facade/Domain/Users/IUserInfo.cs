using System;
using MongoDB.Bson;
using Rovecode.Assistant.Facade.Domain.Common;

namespace Rovecode.Assistant.Facade.Domain.Models
{
    public interface IUser : IDatabaseEntity
    {
        public string Secret { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
