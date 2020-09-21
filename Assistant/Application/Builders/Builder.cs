using System;
using Rovecode.Assistant.Facade.Application.Builders;

namespace Assistant.Application.Builders
{
    public abstract class Builder<T> : IBuilder<T>
    {
        protected T _value;

        public abstract T Result();
    }
}
