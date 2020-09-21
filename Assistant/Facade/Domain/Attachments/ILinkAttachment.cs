using System;

namespace Rovecode.Assistant.Facade.Domain.Attachments
{
    public interface ILinkAttachment : IWebSourceAttachment
    {
        public Uri Link { get; set; }

        public string Text { get; set; }
    }
}
