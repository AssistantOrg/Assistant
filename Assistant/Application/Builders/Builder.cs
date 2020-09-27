using System;
using System.Threading.Tasks;
using Rovecode.Assistant.Facade.Application.Builders;

namespace Rovecode.Assistant.Application.Builders
{
    public abstract class Builder<T> : IBuilder<T>
    {
        public abstract T Build();
    }
}
