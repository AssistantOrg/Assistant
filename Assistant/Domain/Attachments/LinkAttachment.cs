using System;
using Rovecode.Assistant.Facade.Domain.Attachments;

namespace Rovecode.Assistant.Domain.Attachments
{
    public class LinkAttachment : WebSourceAttachment, ILinkAttachment
    {
        public Uri Link { get; set; }

        public string Text { get; set; }
    }
}
