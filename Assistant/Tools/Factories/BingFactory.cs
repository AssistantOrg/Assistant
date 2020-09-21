using System;
using Rovecode.Assistant.Facade.Ferry.Contexts;

namespace Rovecode.Assistant.Tools.Factories
{
    public class BingFactory
    {
        private IAssistantContext _context;

        public BingFactory(IAssistantContext context)
        {
            _context = context;
        }

        public Builders.Bing.SearchImagesAttachmentBuilder BuildSearchImagesAttachment()
        {
            return new Builders.Bing.SearchImagesAttachmentBuilder(_context);
        }

        public Builders.Bing.SearchLinkAttachmentBuilder BuildSearchLinkAttachment()
        {
            return new Builders.Bing.SearchLinkAttachmentBuilder(_context);
        }
    }
}
