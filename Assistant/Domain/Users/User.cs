using System;
using Rovecode.Assistant.Domain.Common;
using Rovecode.Assistant.Facade.Domain.Models;

namespace Rovecode.Assistant.Domain.Users
{
    public class User : DatabaseModernEntity, IUser
    {
        public string Login { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
