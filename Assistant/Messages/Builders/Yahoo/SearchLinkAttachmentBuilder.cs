using System;
using System.Collections.Generic;
using Assistant.Facade.Messages;
using Assistant.Messages.Attachments;

namespace Assistant.Messages.Builders.Yahoo
{
    public class SearchLinkAttachmentBuilder : LinkAttachmentBuilder<SearchLinkAttachmentBuilder>
    {
        public SearchLinkAttachmentBuilder(IAssistantContext context)
            : base(context)
        {
            _value = new LinkAttachment()
            {
                Source = Enums.WebSource.Yahoo
            };
        }

        public override SearchLinkAttachmentBuilder SetText(string text)
        {
            _value.Text = text;
            return this;
        }

        public override SearchLinkAttachmentBuilder SetSearchKey(IEnumerable<string> linkKey)
        {
            _value.Link = new Uri($"https://search.yahoo.com/search?p={String.Join("+", linkKey)}");
            return this;
        }

        public override LinkAttachment GetResult()
        {
            ThrowIfNotValid();

            return _value;
        }
    }
}
