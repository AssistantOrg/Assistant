using System;
using Rovecode.Assistant.Facade.Application.Configurations;
using Rovecode.Assistant.Facade.Domain.Models;

namespace Rovecode.Assistant.Facade.Ferry.Contexts
{
    public interface IAssistantContext
    {
        public IMessageInfo Message { get; set; }

        public IUserInfo User { get; set; }

        public IConfiguration Configuration { get; set; }

        public bool IsExecutable { get; }
    }
}
