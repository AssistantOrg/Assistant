using System;
using Assistant.Messages.Enums;

namespace Assistant.Messages.Attachments
{
    public class AboutAttachment : Attachment
    {
        public string Title { get; set; }
        public string Subtitle { get; set; }

        public string Text { get; set; }

        public Uri Image { get; set; }

        public WebSource Source { get; set; }

        public Uri Link { get; set; }
    }
}
