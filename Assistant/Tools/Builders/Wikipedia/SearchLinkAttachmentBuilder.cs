using System;
using System.Collections.Generic;
using Rovecode.Assistant.Domain.Attachments;
using Rovecode.Assistant.Facade.Domain.Attachments;
using Rovecode.Assistant.Facade.Ferry.Contexts;

namespace Rovecode.Assistant.Tools.Builders.Wikipedia
{
    public class SearchLinkAttachmentBuilder : LinkAttachmentBuilder<SearchLinkAttachmentBuilder>
    {
        public SearchLinkAttachmentBuilder(IAssistantContext context)
            : base(context)
        {
            _value = new LinkAttachment()
            {
                Source = Facade.Enums.WebSource.Wikipedia
            };
        }

        public override SearchLinkAttachmentBuilder SetText(string text)
        {
            _value.Text = text;
            return this;
        }

        public override SearchLinkAttachmentBuilder SetSearchKey(IEnumerable<string> linkKey)
        {
            _value.Link = new Uri($"https://ru.wikipedia.org/w/index.php?search={String.Join("+", linkKey)}");
            return this;
        }

        public override ILinkAttachment Result()
        {
            ThrowIfNotValid();

            return _value;
        }
    }
}
