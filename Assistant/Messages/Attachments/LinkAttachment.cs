using System;
using System.ComponentModel.DataAnnotations;
using Assistant.Messages.Enums;

namespace Assistant.Messages.Attachments
{
    public class LinkAttachment : WebSourceAttachment
    {
        //[Required]
        public Uri Link { get; set; }

        public string Text { get; set; }
    }
}
