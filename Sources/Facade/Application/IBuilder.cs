using System;

namespace Assistant.Facade.Application
{
    public interface IBuilder<T>
    {
        public T GetResult();
    }
}
