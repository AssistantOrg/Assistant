using System;
using System.Linq;
using Rovecode.Assistant.Domain.Models;
using Rovecode.Assistant.Domain.Users;
using Rovecode.Assistant.Facade.Domain.Messages;
using Rovecode.Assistant.Facade.Domain.Models;
using Rovecode.Assistant.Facade.Ferry.Contexts;

namespace Rovecode.Assistant.Ferry.Contexts
{
    public class CommandContext : ICommandContext
    {
        public IReceiveMessage Message { get; set; } = new ReceiveMessage();

        public IUser User { get; set; } = new User();

        public IApplicationContext Configuration { get; set; }
    }
}
