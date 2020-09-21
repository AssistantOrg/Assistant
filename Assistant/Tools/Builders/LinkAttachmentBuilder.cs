using System;
using System.Collections.Generic;
using Assistant.Application.Builders;
using Assistant.Application.Exceptions;
using Rovecode.Assistant.Facade.Domain.Attachments;
using Rovecode.Assistant.Facade.Ferry.Contexts;

namespace Rovecode.Assistant.Tools.Builders
{
    public abstract class LinkAttachmentBuilder<T> : ContextBuilder<ILinkAttachment>
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
