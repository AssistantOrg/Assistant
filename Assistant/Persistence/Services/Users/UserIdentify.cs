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

        private FilterDefinition<User> BuildLoginFilter(User user)
        {
            return BuildLoginFilter(user.Login);
        }

        private FilterDefinition<User> BuildLoginFilter(string secret)
        {
            return Builders<User>.Filter.Eq("Login", secret);
        }

        private FilterDefinition<User> BuildPasswordFilter(User user)
        {
            return BuildPasswordFilter(user.Login);
        }

        private FilterDefinition<User> BuildPasswordFilter(string secret)
        {
            return Builders<User>.Filter.Eq("Password", secret);
        }

        public bool IsExistsById(User user)
        {
            return _userRepository.IsExists(BuildIdFilter(user));
        }

        public bool IsExistsByLogin(string secret)
        {
            return _userRepository.IsExists(BuildLoginFilter(secret));
        }

        public async Task CreateAsync(User user)
        {
            if (IsExistsByLogin(user.Login))
            {
                throw new AssistantException();
            }

            await _userRepository.InsertOneAsync(user);
        }

        public async Task DeleteAsync(User user)
        {
            await _userRepository.DeleteOneAsync(BuildIdFilter(user));
        }

        public Task<UserToken> AuthAsync(User user)
        {
            return AuthAsync(user.Login, user.Password);
        }

        public async Task<UserToken> AuthAsync(string login, string passwordSha512)
        {
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(passwordSha512))
            {
                throw new AssistantException();
            }

            if (IsExistsByLogin(login))
            {
                var userBySecret = await _userRepository.FindOneAsync(Builders<User>.Filter
                    .And(BuildLoginFilter(login), BuildPasswordFilter(passwordSha512)));

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
