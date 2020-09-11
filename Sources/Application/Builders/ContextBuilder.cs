using System;
using Assistant.Facade.Messages;

namespace Assistant.Application.Builders
{
    public abstract class ContextBuilder<T> : Builder<T>
    {
        protected IAssistantContext _context;

        public ContextBuilder(IAssistantContext context)
        {
            _context = context;
        }
    }
}
