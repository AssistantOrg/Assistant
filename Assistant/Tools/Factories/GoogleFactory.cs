using System;
using Rovecode.Assistant.Facade.Ferry.Contexts;

namespace Rovecode.Assistant.Tools.Factories
{
    public class GoogleFactory
    {
        private ICommandContext _context;

        public GoogleFactory(ICommandContext context)
        {
            _context = context;
        }

        public Builders.Google.SearchLinkAttachmentBuilder BuildSearchLinkAttachment()
        {
            return new Builders.Google.SearchLinkAttachmentBuilder(_context);
        }
    }
}
