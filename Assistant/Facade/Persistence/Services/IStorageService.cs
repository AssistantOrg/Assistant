using System;

namespace Rovecode.Assistant.Facade.Persistence.Services
{
    public interface IStorageService<T> where T : class
    {
        T Data { get; set; }

        void Load();
        void Save();
    }
}
