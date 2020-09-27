using System;
using Rovecode.Assistant.Facade.Domain.Attachments;
using Rovecode.Assistant.Facade.Domain.Messages;

namespace Rovecode.Assistant.Domain.Messages
{
    public class DispatchMessage : IDispatchMessage
    {
        public string Text { get; set; }

        public IAttachment Attachment { get; set; }
    }
}
