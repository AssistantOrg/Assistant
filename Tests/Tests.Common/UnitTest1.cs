using System;
using System.Linq;
using System.Reflection;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Rovecode.Assistant.Application.Attributes;
using Rovecode.Assistant.Application.Helpers;
using Rovecode.Assistant.Domain.Application;
using Rovecode.Assistant.Domain.Commands;
using Rovecode.Assistant.Domain.Messages;
using Rovecode.Assistant.Domain.Users;
using Rovecode.Assistant.Facade.Domain.Commands;
using Rovecode.Assistant.Facade.Domain.Messages;
using Rovecode.Assistant.Facade.Ferry.Commands;
using Rovecode.Assistant.Facade.Ferry.Contexts;
using Rovecode.Assistant.Facade.Persistence.Services;
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
        private static int _count;


        public static ICommandInfo Info => new CommandInfo
        {
            Priority = 0,
            Keys = new[]
            {
                new[] { "t" },
            },
        };

        public IDispatchMessage Execute(ICommandContext context)
        {
            _count++;

            return null;

            return new DispatchMessage
            {
                Text = $"test {context.User.FirstName} {context.User.LastName} {context.User.Login} {_count}", //_storage1.Data.Count.ToString()
            };
        }
    }

    public class TestCommand2 : ICommand
    {
        [Injection(IsAuto = true)]
        private readonly CommandStorage<StateModel> _str2;

        private static int _count;
        public static ICommandInfo Info => new CommandInfo
        {
            Priority = 0,
            Keys = new[]
            {
                new[] { "test" },
            },
        };

        public IDispatchMessage Execute(ICommandContext context)
        {
            _count++;

            _str2.Data ??= new StateModel();

            return null;

            return new DispatchMessage
            {
                Text = $"test2 2", //_storage1.Data.Count.ToString()
            };
        }
    }

    public class UnitTest1
    {

        [Fact]
        public void Test0()
        {
            //properties.ForEach(e => System.Activator.CreateInstance(e.PropertyType, new object[] { null, e.PropertyType }));
        }

        [Fact]
        public async void Test1()
        {
            var appCtxBuilder = new ApplicationContextBuilder
            {
                Info = new ApplicationInfo
                {
                    Application = new ApplicationAppInfo
                    {
                        AppName = "test_0.3.2",
                        TargetLanguage = "en",
                        ExecuteAssistantKeys = new[] { new[] { "bot" } },
                        Version = new Version(0, 3, 2),
                    },
                    Database = new ApplicationDatabaseInfo
                    {
                        Name = "felix",
                        ConnectionLink = new Uri("mongodb://assistantmongodb:9aTychpSH46dzlC3b5OIjgOpvTfXkaiiuJfDQ09BYvabvlM9hGD0227pUx3LbXCehQ3XYOnITAPB2k1K7l9PUg==@assistantmongodb.mongo.cosmos.azure.com:10255/?ssl=true&replicaSet=globaldb&retrywrites=false&maxIdleTimeMS=120000&appName=@assistantmongodb@"),
                    },
                    Bing = new ApplicationBingInfo
                    {
                        Link = new Uri("https://felixedu.cognitiveservices.azure.com/"),
                        Token = "377d85c49d9d4e3284f6cc8604f218ea",
                    },
                },
            };

            appCtxBuilder.Invoker.CommandsTypes.Add(typeof(TestCommand));
            appCtxBuilder.Invoker.CommandsTypes.Add(typeof(TestCommand2));
            appCtxBuilder.Invoker.DefaultCommandType = typeof(TestCommand);

            var appCtx = appCtxBuilder.Build();

            var service = new UserIdentify(appCtx);

            var user = new User
            {
                FirstName = "Roman",
                LastName = "Suslikov",
                Login = "dina",
                Password = SecureHelper.SHA512("dina"),
            };

            //await service.CreateAsync(user);

            //UserToken token = await service.AuthAsync(user);

            //ICommandContext commCtx1 = new CommandContextBuilder(appCtx)
            //{
            //    Text = "bot tst",
            //    IdentifyToken = new UserToken { Token = "vEp1xmfLhvG66FA5vCHZd38u" },
            //}.Build();

            ICommandContext commCtx2 = new CommandContextBuilder(appCtx)
            {
                Text = "bot test",
                IdentifyToken = new UserToken { Token = "vEp1xmfLhvG66FA5vCHZd38u" },
            }.Build();

            var resultT = await appCtx.Invoker.RunAsync(commCtx2);

            Console.WriteLine(resultT.ToJson());

            //resultT = await appCtx.Invoker.RunAsync(commCtx2);

            //Console.WriteLine(resultT.ToJson());


            Assert.True(true);
        }
    }
}
