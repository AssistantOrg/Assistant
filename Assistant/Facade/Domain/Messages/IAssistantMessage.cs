using System;
using Rovecode.Assistant.Facade.Domain.Attachments;

namespace Rovecode.Assistant.Facade.Domain.Messages
{
    public interface IAssistantMessage
    {
        public string Text { get; set; }

        public IAttachment Attachment { get; set; }
    }
}
