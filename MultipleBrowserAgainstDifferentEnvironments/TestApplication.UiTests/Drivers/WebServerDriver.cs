using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using TechTalk.SpecRun;
using TestApplication.Web;

namespace TestApplication.UiTests.Drivers
{
    public class WebServerDriver
    {
        private readonly TestRunContext _testRunContext;
        private IHost _host;

        public WebServerDriver(TestRunContext testRunContext)
        {
            _testRunContext = testRunContext;
        }

        public string Hostname { get; private set; }

        public void Start()
        {
            Hostname = $"http://localhost:{GeneratePort()}";

            var hostBuilder = new KestrelHostBuilder();
            var builder = hostBuilder.CreateHostBuilder(new string[]{}, Hostname, Path.Combine(Path.GetDirectoryName(typeof(KestrelHostBuilder).Assembly.Location), "..", "..", "..", "..", "TestApplication.Web","wwwroot"), _testRunContext.TestDirectory);
            _host = builder.Build();
            _host.StartAsync().ConfigureAwait(false);
        }


        public async Task Stop()
        {
            if (_host != null) await _host.StopAsync();
        }

        private int GeneratePort()
        {
            return new Random().Next(5000, 32000);
        }
    }
}