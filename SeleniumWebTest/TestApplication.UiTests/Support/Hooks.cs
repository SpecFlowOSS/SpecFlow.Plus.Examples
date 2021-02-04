using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using TechTalk.SpecFlow;
using TestApplication.UiTests.Drivers;
using TestApplication.Web;

namespace TestApplication.UiTests.Support
{
    [Binding]
    public class Hooks
    {
        private static IHost _build;

        [BeforeTestRun]
        public static void StartKestrel(ConfigurationDriver configurationDriver)
        {
            _build = CreateHostBuilder(configurationDriver).Build();
            _build.StartAsync();
        }

        [AfterTestRun]
        public static void StopKestrel()
        {
            _build.StopAsync();
        }

        private static IHostBuilder CreateHostBuilder(ConfigurationDriver configurationDriver)
        {
            return Host.CreateDefaultBuilder()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseKestrel()
                        .UseStartup<Startup>()
                        .UseUrls(configurationDriver.SeleniumBaseUrl);
                });
        }
    }


}
