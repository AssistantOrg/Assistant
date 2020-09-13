using System;
using Assistant.Application.Builders;
using Assistant.Application.Exceptions;
using Assistant.Facade.Messages;
using Assistant.Messages.Attachments;

namespace Assistant.Messages.Builders.Bing
{
    public class BingImagesAttachmentBuilder : ContextBuilder<ImagesAttachment>
    {
        public BingImagesAttachmentBuilder(IAssistantContext context)
            : base(context)
        {
            if (context.Options.BingLink == null || string.IsNullOrEmpty(context.Options.BingToken))
            {
                throw new AssistantException("bing token or bing link is null or empty");
            }

            _value = new ImagesAttachment();
        }

        public override ImagesAttachment GetResult()
        {
            throw new NotImplementedException();
        }
    }
}
