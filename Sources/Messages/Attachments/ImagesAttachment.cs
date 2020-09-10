using System;
using System.Collections.Generic;
using Assistant.Messages.Enums;

namespace Assistant.Messages.Attachments
{
    public class ImagesAttachment : Attachment
    {
        public WebSource Source { get; set; }

        public IEnumerable<Uri> Images { get; set; }
    }
}
