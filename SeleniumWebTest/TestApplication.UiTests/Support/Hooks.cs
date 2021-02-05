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
        private static IHost _host;

        [BeforeTestRun]
        public static void StartKestrel(ConfigurationDriver configurationDriver)
        {
            _host = CreateHostBuilder(configurationDriver).Build();
            _host.StartAsync();
        }

        [AfterTestRun]
        public static void StopKestrel()
        {
            _host.Dispose();
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
