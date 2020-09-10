using System;
using Assistant.Messages.Enums;

namespace Assistant.Messages.Attachments
{
    public class LinkAttachment : Attachment
    {
        public Uri Link { get; set; }

        public WebSource Source { get; set; }

        public string Text { get; set; }
    }
}
