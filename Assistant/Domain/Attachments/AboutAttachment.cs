using System;
using Rovecode.Assistant.Facade.Domain.Attachments;

namespace Rovecode.Assistant.Domain.Attachments
{
    public class AboutAttachment : WebSourceAttachment, IAboutAttachment
    {
        public string Title { get; set; }
        public string Subtitle { get; set; }

        public string Text { get; set; }

        public IImageInfo Image { get; set; }

        public Uri Link { get; set; }
    }
}
