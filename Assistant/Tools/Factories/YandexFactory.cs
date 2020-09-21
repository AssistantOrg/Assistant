using System;
using Rovecode.Assistant.Facade.Ferry.Contexts;

namespace Rovecode.Assistant.Tools.Factories
{
    public class YandexFactory
    {
        private IAssistantContext _context;

        public YandexFactory(IAssistantContext context)
        {
            _context = context;
        }

        public Builders.Yandex.SearchLinkAttachmentBuilder BuildSearchLinkAttachment()
        {
            return new Builders.Yandex.SearchLinkAttachmentBuilder(_context);
        }
    }
}
