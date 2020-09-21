using System;
using System.Collections.Generic;
using System.Security.Authentication;
using MongoDB.Driver;
using Rovecode.Assistant.Facade.Application.Configurations;
using Rovecode.Assistant.Facade.Domain.Configurations;
using Rovecode.Assistant.Facade.Ferry.Managers;

namespace Assistant.Application.Configurations
{
    public abstract class Configuration : IConfiguration
    {
        public ICommandsManager Manager { get; set; }

        public IMongoDatabase Database { get; set; }

        public IConfigurationInfo Info { get; set; }

        public Configuration()
        {
            ConnectToDB();
        }

        private void ConnectToDB()
        {
            string connectionString = Info.Database.ConnectionLink.ToString();

            MongoClientSettings settings
                = MongoClientSettings.FromUrl(
                    new MongoUrl(connectionString));

            settings.SslSettings = new SslSettings()
            {
                EnabledSslProtocols = SslProtocols.Tls12
            };

            Database = new MongoClient(settings).GetDatabase(Info.Database.Name);
        }
    }
}
