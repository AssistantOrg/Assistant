using System;
using Rovecode.Assistant.Facade.Ferry.Contexts;

namespace Rovecode.Assistant.Tools.Factories
{
    public class BingFactory
    {
        private ICommandContext _context;

        public BingFactory(ICommandContext context)
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
