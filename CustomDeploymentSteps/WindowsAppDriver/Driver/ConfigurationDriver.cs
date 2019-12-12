using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace WindowsAppDriver.Driver
{
    public class ConfigurationDriver
    {
        private readonly Lazy<IConfiguration> _configurationLazy;

        public ConfigurationDriver()
        {
            _configurationLazy = new Lazy<IConfiguration>(GetConfiguration);
        }

        public IConfiguration Configuration => _configurationLazy.Value;

        private IConfiguration GetConfiguration()
        {
            var configurationBuilder = new ConfigurationBuilder();

            string directoryName = Path.GetDirectoryName(typeof(ConfigurationDriver).Assembly.Location);
            configurationBuilder.AddJsonFile(Path.Combine(directoryName, @"appsettings.json"));

            return configurationBuilder.Build();
        }
    }
}
