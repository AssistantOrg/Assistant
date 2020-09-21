using System;
using Rovecode.Assistant.Facade.Domain.Attachments;

namespace Rovecode.Assistant.Domain.Attachments
{
    public class Attachment : IAttachment
    {
        public string Name { get; }

        public Attachment()
        {
            Name = GetType().Name;
        }
    }
}
