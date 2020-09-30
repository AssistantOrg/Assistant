using System;
using System.Security.Authentication;
using MongoDB.Driver;
using Rovecode.Assistant.Application.Builders;
using Rovecode.Assistant.Domain.Application;
using Rovecode.Assistant.Domain.Users;
using Rovecode.Assistant.Facade.Domain.Application;
using Rovecode.Assistant.Facade.Domain.Messages;
using Rovecode.Assistant.Facade.Ferry.Contexts;
using Rovecode.Assistant.Facade.Ferry.Invokers;
using Rovecode.Assistant.Ferry.Contexts;
using Rovecode.Assistant.Ferry.Invokers;
using Rovecode.Assistant.Persistence.Services.Users;

namespace Rovecode.Assistant.Tools.Builders
{
    public class ApplicationContextBuilder : Builder<IApplicationContext>
    {
        public IApplicationInfo Info { get; set; }

        public ICommandInvoker Invoker { get; }

        public ApplicationContextBuilder()
        {
            Invoker = new CommandInvoker();

            //// TODO: rm . x}

            //// When: App start Do: create app context
            //var appContextBuilder = new ApplicationContextBuilder
            //{
            //    Info = new ApplicationInfo
            //    {
            //        Application = new ApplicationAppInfo
            //        {
            //            AppName = "test",
            //            TargetLanguage = "ru",
            //            ExecuteAssistantKeys = new[] { new[] { "bot" } },
            //            Version = new Version(0, 1, 0),
            //        },
            //        Database = new ApplicationDatabaseInfo
            //        {
            //            ConnectionLink = new Uri(""),
            //            Name = "test"
            //        },
            //        Bing = new ApplicationBingInfo
            //        {
            //            Link = new Uri(""),
            //            Token = "test",
            //        }
            //    },
            //};

            //appContextBuilder.Manager.DefaultCommand = null;

            //appContextBuilder.Manager.Commands.Add(null);
            //appContextBuilder.Manager.Commands.Add(null);
            //appContextBuilder.Manager.Commands.Add(null);
            //appContextBuilder.Manager.Commands.Add(null);
            //appContextBuilder.Manager.Commands.Add(null);

            //IApplicationContext appContext = appContextBuilder.Build();

            //// End

            //// When: App execute command Do: create command context and invoke commands
            //var commandContextBuilder = new CommandContextBuilder
            //{
            //    IdentifyToken = new UserToken { Token = "test_323245235235235" }, /* auth code there */
            //    AppContext = appContext,
            //    Text = "bot Hello roman fefdsg gdfg #$@*( show Pictures 4850dhgfk hlgfhgfmb%$^&$)_#$",
            //};

            //ICommandContext commandContext = commandContextBuilder.Build();

            //IDispatchMessage result = appContext.Manager.RunAsync(commandContext).Result;
        }

        public override IApplicationContext Build()
        {
            return new ApplicationContext
            {
                Info = Info,
                Invoker = Invoker,
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
