using System;
using Rovecode.Assistant.Domain.Common;
using Rovecode.Assistant.Facade.Domain.Models;

namespace Rovecode.Assistant.Domain.Users
{
    public class User : DatabaseEntity, IUser
    {
        public string Secret { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
