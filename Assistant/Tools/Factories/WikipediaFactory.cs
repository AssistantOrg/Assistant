using System;
using Rovecode.Assistant.Facade.Ferry.Contexts;

namespace Rovecode.Assistant.Tools.Factories
{
    public class WikipediaFactory
    {
        private IAssistantContext _context;

        public WikipediaFactory(IAssistantContext context)
        {
            _context = context;
        }

        public Builders.Wikipedia.SearchLinkAttachmentBuilder BuildSearchLinkAttachment()
        {
            return new Builders.Wikipedia.SearchLinkAttachmentBuilder(_context);
        }
    }
}
