using System;
using MongoDB.Bson;
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
        private readonly DatabaseRepository<IStorageServiceEntity<T>> _repository;

        private readonly ICommandContext _context;
        private readonly Type _type;

        private IStorageServiceEntity<T> _model;

        public CommandStorage(ICommandContext context, Type type)
        {
            _context = context;
            _type = type;

            _repository = new DatabaseRepository<IStorageServiceEntity<T>>(
                context.AppContext.Database
                    .GetCollection<IStorageServiceEntity<T>>("storage"));
        }

        public T Data
        {
            get => _model?.Data;
            set => _model.Data = value;
        }

        private FilterDefinition<IStorageServiceEntity<T>> BuildIdAndPathFilter(ObjectId id, string path)
        {
            var userIdFilter = Builders<IStorageServiceEntity<T>>.Filter.Eq("UserId", id);
            var commandPathFilter = Builders<IStorageServiceEntity<T>>.Filter.Eq("CommandPath", path);

            return Builders<IStorageServiceEntity<T>>.Filter.And(userIdFilter, commandPathFilter);
        }

        public void Load()
        {
            var filter = BuildIdAndPathFilter(_context.User.Id, _type.FullName);

            if (_repository.IsExists(filter))
            {
                _model = _repository.FindOne(filter);
            }
        }

        public void Save()
        {
            var filter = BuildIdAndPathFilter(_context.User.Id, _type.FullName);

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
