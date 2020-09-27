using System;
using System.Collections.Generic;
using Rovecode.Assistant.Domain.Attachments;
using Rovecode.Assistant.Facade.Domain.Attachments;
using Rovecode.Assistant.Facade.Ferry.Contexts;

namespace Rovecode.Assistant.Tools.Builders.Yahoo
{
    public class SearchLinkAttachmentBuilder : LinkAttachmentBuilder<SearchLinkAttachmentBuilder>
    {
        public SearchLinkAttachmentBuilder(ICommandContext context)
            : base(context)
        {
            _value = new LinkAttachment()
            {
                Source = Facade.Enums.WebSource.Yahoo
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

        public override ILinkAttachment Build()
        {
            ThrowIfNotValid();

            return _value;
        }
    }
}
