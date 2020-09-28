using System;
using Rovecode.Assistant.Application.Attributes;
using Rovecode.Assistant.Domain.Commands;
using Rovecode.Assistant.Domain.Messages;
using Rovecode.Assistant.Domain.Users;
using Rovecode.Assistant.Facade.Domain.Commands;
using Rovecode.Assistant.Facade.Domain.Messages;
using Rovecode.Assistant.Facade.Ferry.Commands;
using Rovecode.Assistant.Facade.Ferry.Contexts;
using Rovecode.Assistant.Persistence.Services.Storages;
using Rovecode.Assistant.Persistence.Services.Users;
using Rovecode.Assistant.Tools.Builders;
using Xunit;

namespace Tests.Common
{
    public class TestModel
    {
        public int Count { get; set; }
    }

    public class StateModel
    {
        public bool IsWalk { get; set; }
    }

    public class TestCommand : ICommand
    {
        [Injection]
        public CommandStorage<TestModel> _storage1 { get; set; }

        [Injection]
        public CommandStorage<StateModel> _storage2 { get; set; }

        public ICommandInfo Info => new CommandInfo
        {
            Priority = 0,
            Keys = new[]
            {
                new[] { "test" },
            },
        };

        public IDispatchMessage Execute(ICommandContext context)
        {
            _storage1.Data.Count++;

            _storage2.Data.IsWalk = !_storage2.Data.IsWalk;

            return new DispatchMessage
            {
                Text = _storage1.Data.Count.ToString()
            };
        }
    }

    public class UnitTest1
    {
        private IApplicationContext BuildConfiguration()
        {
            //var configuration = new Configuration();

            //// adds commands
            //configuration.Manager = new CommandsManager();

            //// set info
            //configuration.Info = new ConfigurationInfo
            //{
            //    Application = new ConfigurationApplicationInfo
            //    {
            //        AppName = "test",
            //        TargetLanguage = "ru",
            //        ExecuteAssistantKeys = new[] { new[] { "khvatov" } },
            //        Version = new Version(0, 0, 1),
            //    },
            //    Database = new ConfigurationDatabaseInfo
            //    {
            //        ConnectionLink = new Uri("mongodb://assistantmongodb:9aTychpSH46dzlC3b5OIjgOpvTfXkaiiuJfDQ09BYvabvlM9hGD0227pUx3LbXCehQ3XYOnITAPB2k1K7l9PUg==@assistantmongodb.mongo.cosmos.azure.com:10255/?ssl=true&replicaSet=globaldb&retrywrites=false&maxIdleTimeMS=120000&appName=@assistantmongodb@"),
            //        Name = "felix",
            //    },
            //    Bing = new ConfigurationBingInfo
            //    {
            //        Link = new Uri("https://felixedu.cognitiveservices.azure.com/"),
            //        Token = "377d85c49d9d4e3284f6cc8604f218ea",
            //    },
            //};

            //// init 
            //configuration.Init();

            //return configuration;

            return null;
        }

        [Fact]
        public async void Test1()
        {
            var configuration = BuildConfiguration();

            var service = new UserIdentify(configuration);

            if (!service.IsExistsBySecret("dina"))
            {
                var user = new User
                {
                    FirstName = "Roman",
                    LastName = "Suslikov",
                    Secret = "dina"
                };

                await service.CreateAsync(user);
            }

            UserToken token = await service.AuthAsync("dina");

            var context = new CommandContextBuilder(configuration)
            {
                Text = "test",
                IdentifyToken = token,
            }.Build();


            await configuration.Manager.RunAsync(context);

            Assert.True(true);
        }
    }
}
