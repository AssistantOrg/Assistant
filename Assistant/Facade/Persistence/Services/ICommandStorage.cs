using System;

namespace Rovecode.Assistant.Facade.Persistence.Services
{
    public interface ICommandStorage<T> : IStorageService<T> where T : class
    {

    }
}
