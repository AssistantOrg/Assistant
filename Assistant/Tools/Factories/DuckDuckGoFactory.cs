using System;
using Rovecode.Assistant.Facade.Ferry.Contexts;

namespace Rovecode.Assistant.Tools.Factories
{
    public class DuckDuckGoFactory
    {
        private IAssistantContext _context;

        public DuckDuckGoFactory(IAssistantContext context)
        {
            _context = context;
        }

        public Builders.DuckDuckGo.SearchLinkAttachmentBuilder BuildSearchLinkAttachment()
        {
            return new Builders.DuckDuckGo.SearchLinkAttachmentBuilder(_context);
        }
    }
}
