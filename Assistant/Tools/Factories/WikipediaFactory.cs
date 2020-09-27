using System;
using Rovecode.Assistant.Facade.Ferry.Contexts;

namespace Rovecode.Assistant.Tools.Factories
{
    public class WikipediaFactory
    {
        private ICommandContext _context;

        public WikipediaFactory(ICommandContext context)
        {
            _context = context;
        }

        public Builders.Wikipedia.SearchLinkAttachmentBuilder BuildSearchLinkAttachment()
        {
            return new Builders.Wikipedia.SearchLinkAttachmentBuilder(_context);
        }
    }
}
