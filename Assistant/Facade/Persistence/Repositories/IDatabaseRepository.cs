using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using Rovecode.Assistant.Facade.Domain.Common;

namespace Rovecode.Assistant.Facade.Persistence.Repositories
{
    public interface IDatabaseRepository<T> where T : IDatabaseEntity
    {
        public IEnumerable<T> FindMany(FilterDefinition<T> filter, int offset = 0, int count = int.MaxValue);

        public Task<IEnumerable<T>> FindManyAsync(FilterDefinition<T> filter, int offset = 0, int count = int.MaxValue);

        public T FindOne(FilterDefinition<T> filter, int offset = 0);

        public Task<T> FindOneAsync(FilterDefinition<T> filter, int offset = 0);

        public void InsertOne(T value);

        public Task InsertOneAsync(T value);

        public void DeleteOne(FilterDefinition<T> filter);

        public Task DeleteOneAsync(FilterDefinition<T> filter);

        public void DeleteMany(FilterDefinition<T> filter);

        public Task DeleteManyAsync(FilterDefinition<T> filter);

        public void UpdateOne(FilterDefinition<T> filter, UpdateDefinition<T> update);

        public Task UpdateOneAsync(FilterDefinition<T> filter, UpdateDefinition<T> update);

        public void ReplaceOne(FilterDefinition<T> filter, T value);

        public Task ReplaceOneAsync(FilterDefinition<T> filter, T value);

        public bool IsExists(FilterDefinition<T> filter);

        public Task<bool> IsExistsAsync(FilterDefinition<T> filter);

        public long Count(FilterDefinition<T> filter);

        public Task<long> CountAsync(FilterDefinition<T> filter);
    }
}
