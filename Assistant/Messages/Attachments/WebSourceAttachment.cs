using System;
using System.ComponentModel.DataAnnotations;
using Assistant.Messages.Enums;

namespace Assistant.Messages.Attachments
{
    public abstract class WebSourceAttachment : Attachment
    {
        //[Required]
        public WebSource Source { get; set; }
    }
}
