using System;
using System.Collections.Generic;
using Rovecode.Assistant.Application.Builders;
using Rovecode.Assistant.Application.Exceptions;
using Rovecode.Assistant.Facade.Domain.Attachments;
using Rovecode.Assistant.Facade.Ferry.Contexts;

namespace Rovecode.Assistant.Tools.Builders
{
    public abstract class LinkAttachmentBuilder<T> : ContextBuilder<ILinkAttachment>
    {
        public string Text { get; set; }

        public IEnumerable<string> SearchKey { get; set; }

        public LinkAttachmentBuilder(ICommandContext context)
            : base(context)
        {

        }

        protected void ThrowIfNotValid()
        {
            if (string.IsNullOrEmpty(Text) || SearchKey == null)
            {
                throw new AssistantException("builder values has bad format or null");
            }
        }
    }
}
