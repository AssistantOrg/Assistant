using System;
using System.Collections.Generic;
using Assistant.Application.Builders;
using Assistant.Application.Exceptions;
using Assistant.Facade.Application;
using Assistant.Facade.Messages;
using Assistant.Messages.Attachments;

namespace Assistant.Messages.Builders.Google
{
    public class GoogleLinkAttachmentBuilder : ContextBuilder<LinkAttachment>
    {
        public GoogleLinkAttachmentBuilder(IAssistantContext context) : base(context)
        {
            _value = new LinkAttachment()
            {
                Source = Enums.WebSource.Google
            };
        }

        public GoogleLinkAttachmentBuilder SetText(string text)
        {
            _value.Text = text;
            return this;
        }

        public GoogleLinkAttachmentBuilder SetSearchKey(IEnumerable<string> linkKey)
        {
            _value.Link = new Uri($"https://www.google.com/search?q={String.Join("+", linkKey)}");
            return this;
        }

        public override LinkAttachment GetResult()
        {
            if (_value.Text == string.Empty || _value.Text == null
                || _value.Link == null)
            {
                throw new AssistantException("builder not fill well");
            }

            return _value;
        }
    }
}
