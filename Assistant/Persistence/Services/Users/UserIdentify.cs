using System;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using Rovecode.Assistant.Application.Exceptions;
using Rovecode.Assistant.Application.Helpers;
using Rovecode.Assistant.Domain.Users;
using Rovecode.Assistant.Facade.Ferry.Contexts;
using Rovecode.Assistant.Persistence.Repositories;

namespace Rovecode.Assistant.Persistence.Services.Users
{
    public class UserIdentify
    {
        private readonly DatabaseRepository<User> _userRepository;
        private readonly DatabaseRepository<UserToken> _userTokenRepository;

        public UserIdentify(IApplicationContext configuration)
        {
            _userRepository = new DatabaseRepository<User>(configuration
                .Database.GetCollection<User>("users"));

            _userTokenRepository = new DatabaseRepository<UserToken>(configuration
                .Database.GetCollection<UserToken>("users_tokens"));
        }

        private FilterDefinition<User> BuildIdFilter(User user)
        {
            return BuildIdFilter(user.Id);
        }

        private FilterDefinition<User> BuildIdFilter(ObjectId id)
        {
            return Builders<User>.Filter.Eq("_id", id);
        }

        private FilterDefinition<User> BuildSecretFilter(User user)
        {
            return BuildSecretFilter(user.Secret);
        }

        private FilterDefinition<User> BuildSecretFilter(string secret)
        {
            return Builders<User>.Filter.Eq("Secret", secret);
        }

        private bool IsExistsById(User user)
        {
            return _userRepository.IsExists(BuildIdFilter(user));
        }

        public bool IsExistsBySecret(string secret)
        {
            return _userRepository.IsExists(BuildSecretFilter(secret));
        }

        public async Task CreateAsync(User user)
        {
            if (IsExistsBySecret(user.Secret)) throw new AssistantException();

            await _userRepository.InsertOneAsync(user);
        }

        public async Task DeleteAsync(User user)
        {
            await _userRepository.DeleteOneAsync(BuildIdFilter(user));
        }

        public Task<UserToken> AuthAsync(User user)
        {
            return AuthAsync(user.Secret);
        }

        public async Task<UserToken> AuthAsync(string secret)
        {
            if (string.IsNullOrEmpty(secret))
            {
                throw new AssistantException();
            }

            if (IsExistsBySecret(secret))
            {
                var userBySecret = await _userRepository.FindOneAsync(BuildSecretFilter(secret));

                var token = new UserToken
                {
                    Token = StringHelper.GenerateRandom(24),
                    UserId = userBySecret.Id,
                };

                await _userTokenRepository.InsertOneAsync(token);

                return token;
            }
            else
            {
                throw new AssistantException();
            }
        }

        public Task<User> IdentifyAsync(UserToken token)
        {
            return IdentifyAsync(token.Token);
        }

        public async Task<User> IdentifyAsync(string token)
        {
            var findToken = await _userTokenRepository.FindOneAsync(Builders<UserToken>.Filter.Eq("Token", token));

            var result = await _userRepository.FindOneAsync(BuildIdFilter(findToken.UserId));

            return result;
        }
    }
}
