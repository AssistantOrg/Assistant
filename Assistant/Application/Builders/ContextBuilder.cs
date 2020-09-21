using System;
using Rovecode.Assistant.Facade.Application.Builders;
using Rovecode.Assistant.Facade.Ferry.Contexts;

namespace Assistant.Application.Builders
{
    public abstract class ContextBuilder<T> : Builder<T>, IContextBuilder<T>
    {
        protected IAssistantContext _context;

        public ContextBuilder(IAssistantContext context)
        {
            _context = context;
        }
    }
}
