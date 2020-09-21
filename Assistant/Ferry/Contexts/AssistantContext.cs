using System;
using System.Linq;
using Rovecode.Assistant.Domain.Models;
using Rovecode.Assistant.Facade.Application.Configurations;
using Rovecode.Assistant.Facade.Domain.Models;
using Rovecode.Assistant.Facade.Ferry.Contexts;

namespace Rovecode.Assistant.Ferry.Contexts
{
    public class AssistantContext : IAssistantContext
    {
        public IMessageInfo Message { get; set; } = new MessageInfo();

        public IUserInfo User { get; set; } = new UserInfo();

        public IConfiguration Configuration { get; set; }

        public bool IsExecutable => Message.ExcuteCommandKey != null && Message.ExcuteCommandKey.Count() > 0;
    }
}
