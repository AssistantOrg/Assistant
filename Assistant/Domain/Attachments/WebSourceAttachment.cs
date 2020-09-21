using System;
using Rovecode.Assistant.Facade.Domain.Attachments;
using Rovecode.Assistant.Facade.Enums;

namespace Rovecode.Assistant.Domain.Attachments
{
    public class WebSourceAttachment : Attachment, IWebSourceAttachment
    {
        public WebSource Source { get; set; }
    }
}
