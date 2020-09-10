using System;
using Assistant.Facade.Messages;

namespace Assistant.Messages.Attachments
{
    public class Attachment : IAttachment
    {
        public string Name { get; }

        public Attachment()
        {
            Name = this.GetType().Name;
        }
    }
}
