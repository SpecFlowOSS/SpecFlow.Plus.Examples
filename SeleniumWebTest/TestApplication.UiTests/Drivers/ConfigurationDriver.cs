using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace TestApplication.UiTests.Drivers
{
    public class ConfigurationDriver
    {
        private const string SeleniumBaseUrlConfigFieldName = "seleniumBaseUrl";
        private readonly Lazy<IConfiguration> _configurationLazy;

        public ConfigurationDriver()
        {
            _configurationLazy = new Lazy<IConfiguration>(GetConfiguration);
        }

        public IConfiguration Configuration => _configurationLazy.Value;

        public string SeleniumBaseUrl => Configuration[SeleniumBaseUrlConfigFieldName];

        private IConfiguration GetConfiguration()
        {
            var configurationBuilder = new ConfigurationBuilder();

            string directoryName = Path.GetDirectoryName(typeof(ConfigurationDriver).Assembly.Location);
            configurationBuilder.AddJsonFile(Path.Combine(directoryName, @"test-appsettings.json"));

            return configurationBuilder.Build();
        }
    }
}
