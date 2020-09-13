using System;
using Assistant.Facade.Application;

namespace Assistant.Application.Builders
{
    public abstract class Builder<T> : IBuilder<T>
    {
        protected T _value;

        public abstract T GetResult();
    }
}
