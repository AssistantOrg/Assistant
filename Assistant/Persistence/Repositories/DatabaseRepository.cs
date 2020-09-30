using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using Rovecode.Assistant.Facade.Domain.Common;
using Rovecode.Assistant.Facade.Persistence.Repositories;

namespace Rovecode.Assistant.Persistence.Repositories
{
    public class DatabaseRepository<T> : IDatabaseRepository<T> where T : IDatabaseEntity
    {
        private readonly IMongoCollection<T> _collection;

        public DatabaseRepository(IMongoCollection<T> collection)
        {
            _collection = collection;
        }

        public IEnumerable<T> FindMany(FilterDefinition<T> filter, int offset = 0, int count = int.MaxValue)
        {
            return _collection.Find(filter).Skip(offset).Limit(count).ToEnumerable();
        }

        public Task<IEnumerable<T>> FindManyAsync(FilterDefinition<T> filter, int offset = 0, int count = int.MaxValue)
        {
            return Task.Run(() => _collection.Find(filter).Skip(offset).Limit(count).ToEnumerable());
        }

        public T FindOne(FilterDefinition<T> filter, int offset = 0)
        {
            return _collection.Find(filter).Skip(offset).Limit(1).First();
        }

        public Task<T> FindOneAsync(FilterDefinition<T> filter, int offset = 0)
        {
            return _collection.Find(filter).Skip(offset).Limit(1).FirstAsync();
        }

        public void InsertOne(T value)
        {
            _collection.InsertOne(value);
        }

        public Task InsertOneAsync(T value)
        {
            return _collection.InsertOneAsync(value);
        }

        public void DeleteOne(FilterDefinition<T> filter)
        {
            _collection.DeleteOne(filter);
        }

        public Task DeleteOneAsync(FilterDefinition<T> filter)
        {
            return _collection.DeleteOneAsync(filter);
        }

        public void DeleteMany(FilterDefinition<T> filter)
        {
            _collection.DeleteMany(filter);
        }

        public Task DeleteManyAsync(FilterDefinition<T> filter)
        {
            return _collection.DeleteManyAsync(filter);
        }

        public void UpdateOne(FilterDefinition<T> filter, UpdateDefinition<T> update)
        {
            _collection.UpdateOne(filter, update);
        }

        public Task UpdateOneAsync(FilterDefinition<T> filter, UpdateDefinition<T> update)
        {
            return _collection.UpdateOneAsync(filter, update);
        }

        public void ReplaceOne(FilterDefinition<T> filter, T value)
        {
            _collection.ReplaceOne(filter, value);
        }

        public Task ReplaceOneAsync(FilterDefinition<T> filter, T value)
        {
            return _collection.ReplaceOneAsync(filter, value, new ReplaceOptions { IsUpsert = true });
        }

        public bool IsExists(FilterDefinition<T> filter)
        {
            return Count(filter) > 0;
        }

        public Task<bool> IsExistsAsync(FilterDefinition<T> filter)
        {
            return Task.Run(() => Count(filter) > 0);
        }

        public long Count(FilterDefinition<T> filter)
        {
            return _collection.CountDocuments(filter);
        }

        public Task<long> CountAsync(FilterDefinition<T> filter)
        {
            return _collection.CountDocumentsAsync(filter);
        }
    }
}
