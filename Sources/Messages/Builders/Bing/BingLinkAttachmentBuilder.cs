using System;
using System.Collections.Generic;
using Assistant.Application.Exceptions;
using Assistant.Facade.Application;
using Assistant.Messages.Attachments;

namespace Assistant.Messages.Builders.Bing
{
    public class BingLinkAttachmentBuilder : IBuilder<LinkAttachment>
    {
        private readonly LinkAttachment _value;

        public BingLinkAttachmentBuilder()
        {
            _value = new LinkAttachment();

            _value.Source = Enums.WebSource.Bing;
        }

        public BingLinkAttachmentBuilder SetText(string text)
        {
            _value.Text = text;
            return this;
        }

        public BingLinkAttachmentBuilder SetSearchKey(IEnumerable<string> linkKey)
        {
            _value.Link = new Uri($"https://www.bing.com/search?q={String.Join("+", linkKey)}");
            return this;
        }

        public LinkAttachment GetResult()
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
