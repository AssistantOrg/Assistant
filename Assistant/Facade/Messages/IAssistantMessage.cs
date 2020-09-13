using System;

namespace Assistant.Facade.Messages
{
    public interface IAssistantMessage
    {
        public string Text { get; set; }

        public IAttachment Attachment { get; set; }
    }
}
