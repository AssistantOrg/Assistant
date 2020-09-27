using System;
using System.Security.Authentication;
using MongoDB.Driver;
using Rovecode.Assistant.Application.Builders;
using Rovecode.Assistant.Domain.Application;
using Rovecode.Assistant.Facade.Domain.Application;
using Rovecode.Assistant.Facade.Ferry.Contexts;
using Rovecode.Assistant.Facade.Ferry.Managers;
using Rovecode.Assistant.Ferry.Contexts;
using Rovecode.Assistant.Ferry.Managers;

namespace Rovecode.Assistant.Tools.Builders
{
    public class ApplicationContextBuilder : Builder<IApplicationContext>
    {
        public IApplicationInfo Info { get; set; }

        public ICommandsManager Manager { get; }

        public ApplicationContextBuilder()
        {
            Manager = new CommandsManager();

            // TODO: rm . x}
            var appContextBuilder = new ApplicationContextBuilder
            {
                Info = new ApplicationInfo
                {
                    Application = new ApplicationAppInfo
                    {
                        AppName = "test",
                        TargetLanguage = "ru",
                        ExecuteAssistantKeys = new[] { new[] { "bot" } },
                        Version = new Version(0, 1, 0),
                    },
                    Database = new ApplicationDatabaseInfo
                    {
                        ConnectionLink = new Uri(""),
                        Name = "test"
                    },
                },
            };

            appContextBuilder.Manager.DefaultCommand = null;

            appContextBuilder.Manager.Commands.Add(null);
            appContextBuilder.Manager.Commands.Add(null);
            appContextBuilder.Manager.Commands.Add(null);
            appContextBuilder.Manager.Commands.Add(null);
            appContextBuilder.Manager.Commands.Add(null);

            var appContext = appContextBuilder.Build();

            var commandContextBuilder = new CommandContextBuilder
            {
                Identifier = "test_323245235235235" /* auth code there */,
                AppContext = appContext,
                Text = "bot Hello",
            };

            var commandContext = commandContextBuilder.Build();
        }

        public override IApplicationContext Build()
        {
            return new ApplicationContext
            {
                Info = Info,
                Manager = Manager,
                Database = ConnectToDB(Info.Database.ConnectionLink.ToString()),
            };
        }

        private IMongoDatabase ConnectToDB(string conn)
        {
            MongoClientSettings settings
                = MongoClientSettings.FromUrl(
                    new MongoUrl(conn));

            settings.SslSettings = new SslSettings()
            {
                EnabledSslProtocols = SslProtocols.Tls12
            };

            return new MongoClient(settings)
                .GetDatabase(Info.Database.Name);
        }
    }
}
