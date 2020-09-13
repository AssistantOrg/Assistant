using System;
using System.Collections.Generic;
using Assistant.Application.Builders;
using Assistant.Application.Exceptions;
using Assistant.Facade.Messages;
using Assistant.Messages.Attachments;

namespace Assistant.Messages.Builders
{
    public abstract class LinkAttachmentBuilder<T> : ContextBuilder<LinkAttachment>
    {
        public LinkAttachmentBuilder(IAssistantContext context)
            : base(context)
        {

        }

        public abstract T SetText(string text);

        public abstract T SetSearchKey(IEnumerable<string> linkKey);

        protected void ThrowIfNotValid()
        {
            if (string.IsNullOrEmpty(_value.Text) || _value.Link == null)
            {
                throw new AssistantException("builder values has bad format or null");
            }
        }
    }
}
