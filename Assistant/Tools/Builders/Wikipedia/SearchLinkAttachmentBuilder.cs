using System;
using System.Collections.Generic;
using Rovecode.Assistant.Domain.Attachments;
using Rovecode.Assistant.Facade.Domain.Attachments;
using Rovecode.Assistant.Facade.Ferry.Contexts;

namespace Rovecode.Assistant.Tools.Builders.Wikipedia
{
    public class SearchLinkAttachmentBuilder : LinkAttachmentBuilder<SearchLinkAttachmentBuilder>
    {
        public SearchLinkAttachmentBuilder(ICommandContext context)
            : base(context)
        {

        }

        public override ILinkAttachment Build()
        {
            ThrowIfNotValid();

            return new LinkAttachment()
            {
                Source = Facade.Enums.WebSource.Bing,
                Text = Text,
                Link = new Uri($"https://ru.wikipedia.org/w/index.php?search={String.Join("+", SearchKey)}"),
            };
        }
    }
}
