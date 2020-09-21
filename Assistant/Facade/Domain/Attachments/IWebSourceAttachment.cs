using System;
using Rovecode.Assistant.Facade.Enums;

namespace Rovecode.Assistant.Facade.Domain.Attachments
{
    public interface IWebSourceAttachment : IAttachment
    {
        public WebSource Source { get; set; }
    }
}
