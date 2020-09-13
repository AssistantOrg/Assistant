using System;
using Assistant.Application.Builders;
using Assistant.Facade.Messages;
using Assistant.Messages.Attachments;

namespace Assistant.Messages.Builders.Bing
{
    public class BingImagesAttachmentBuilder : ContextBuilder<ImagesAttachment>
    {
        public BingImagesAttachmentBuilder(IAssistantContext context)
            : base(context)
        {
            _value = new ImagesAttachment();
        }

        public override ImagesAttachment GetResult()
        {
            throw new NotImplementedException();
        }
    }
}
