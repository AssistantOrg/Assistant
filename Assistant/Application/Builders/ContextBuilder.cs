using System;
using Rovecode.Assistant.Facade.Application.Builders;
using Rovecode.Assistant.Facade.Ferry.Contexts;

namespace Rovecode.Assistant.Application.Builders
{
    public abstract class ContextBuilder<T> : Builder<T>, IContextBuilder<T>
    {
        protected ICommandContext _context;

        public ContextBuilder(ICommandContext context)
        {
            _context = context;
        }
    }
}
