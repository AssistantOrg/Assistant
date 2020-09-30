using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using Rovecode.Assistant.Domain.Common;
using Rovecode.Assistant.Domain.Persistence;
using Rovecode.Assistant.Facade.Domain.Common;
using Rovecode.Assistant.Facade.Domain.Persistence;
using Rovecode.Assistant.Facade.Ferry.Contexts;
using Rovecode.Assistant.Facade.Persistence.Services;
using Rovecode.Assistant.Persistence.Repositories;

namespace Rovecode.Assistant.Persistence.Services.Storages 
{
    public class CommandStorage<T> : IStorageService<T> where T : class
    {
        private readonly DatabaseRepository<StorageServiceEntity<T>> _repository;

        private readonly ICommandContext _context;
        private readonly Type _type;

        private StorageServiceEntity<T> _model;

        private static IMongoCollection<StorageServiceEntity<T>> _lsctl;

        public CommandStorage(ICommandContext context, Type type)
        {
            _context = context;
            _type = type;

            if (_lsctl == null)
            {
                _lsctl = context.AppContext.Database
                    .GetCollection<StorageServiceEntity<T>>("storages");
            }

            _repository = new DatabaseRepository<StorageServiceEntity<T>>(_lsctl);
        }

        public T Data
        {
            get => _model.Data;
            set => _model.Data = value;
        }

        private FilterDefinition<StorageServiceEntity<T>> BuildIdAndPathFilter(ObjectId id, string path, string datapath)
        {
            var userIdFilter = Builders<StorageServiceEntity<T>>.Filter.Eq("UserId", id);
            var commandPathFilter = Builders<StorageServiceEntity<T>>.Filter.Eq("CommandPath", path);
            var dataPathFilter = Builders<StorageServiceEntity<T>>.Filter.Eq("DataPath", datapath);

            return Builders<StorageServiceEntity<T>>.Filter.And(userIdFilter, commandPathFilter, dataPathFilter);
        }

        public void Load()
        {
            var filter = BuildIdAndPathFilter(_context.User.Id, _type.FullName, typeof(T).FullName);

            if (_repository.IsExists(filter))
            {
                _model = _repository.FindOne(filter);
            }
            else
            {
                _model = new StorageServiceEntity<T>
                {
                    Id = ObjectId.GenerateNewId(),
                    CommandPath = _type.FullName,
                    UserId = _context.User.Id,
                    DataPath = typeof(T).FullName,
                };
            }

        }

        public void Save()
        {
            var filter = BuildIdAndPathFilter(_context.User.Id, _type.FullName, typeof(T).FullName);

            if (_repository.IsExists(filter))
            {
                if (_model?.Data == null)
                {
                    _repository.DeleteOne(filter);
                }
                else
                {
                    _repository.ReplaceOne(filter, _model);
                }
            }
            else
            {
                if (_model?.Data != null)
                {
                    _repository.InsertOne(_model);
                }
            }
        }
    }
}
