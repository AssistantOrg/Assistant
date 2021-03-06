﻿using System;
using Rovecode.Assistant.Facade.Ferry.Contexts;

namespace Rovecode.Assistant.Tools.Factories
{
    public class YahooFactory
    {
        private ICommandContext _context;

        public YahooFactory(ICommandContext context)
        {
            _context = context;
        }

        public Builders.Yahoo.SearchLinkAttachmentBuilder BuildSearchLinkAttachment()
        {
            return new Builders.Yahoo.SearchLinkAttachmentBuilder(_context);
        }
    }
}
