using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace TestApplication.UiTests.Drivers
{
    public class ConfigurationDriver
    {
        public string SeleniumBaseUrl => Environment.GetEnvironmentVariable("__BaseUrl");
    }
}
