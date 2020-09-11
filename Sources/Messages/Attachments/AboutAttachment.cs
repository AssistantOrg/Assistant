using System;
using System.ComponentModel.DataAnnotations;
using Assistant.Messages.Enums;

namespace Assistant.Messages.Attachments
{
    public class AboutAttachment : WebSourceAttachment
    {
        //[Required]
        public string Title { get; set; }
        public string Subtitle { get; set; }

        //[Required]
        public string Text { get; set; }

        public Uri Image { get; set; }

        public Uri Link { get; set; }
    }
}
